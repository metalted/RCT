using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using ZeepSDK;
using ZeepSDK.LevelEditor;
using Toolkist;

namespace RCT
{
    public enum Scene { Editor, Other };

    public class RCTManager
    {
        public Scene CurrentScene;
        public LEV_LevelEditorCentral central = null;

        public bool rctModeActive = false;
        public bool chainStarted = false;
        private Vector3 startingPosition = Vector3.zero;
        private Quaternion startingRotation = Quaternion.identity;
        private List<RCTBlock> blockChain = new List<RCTBlock>();
        private Material rctMaterial;

        public int CurrentChainLength => blockChain.Count;

        public RCTManager()
        {
            CurrentScene = Scene.Other;
            LevelEditorApi.ExitedLevelEditor += ExitedLevelEditor;
        }

        public void Dispose()
        {
            LevelEditorApi.ExitedLevelEditor -= ExitedLevelEditor;
        }

        public void OnUpdate()
        {
            if(central == null)
            {
                return;
            }

            HandleInputs();
        }

        public void HandleInputs()
        {
            if(rctModeActive && chainStarted)
            {
                RotateLastBlockWithScroll();

                if(CurrentChainLength > 0 && Input.GetKeyDown(Plugin.Instance.undoButton.Value))
                {
                    Undo();
                }

                if(CurrentChainLength > 1)
                {
                    if(Input.GetKeyDown(Plugin.Instance.flipButton.Value))
                    {
                        Flip();
                    }

                    if(Input.GetKeyDown(Plugin.Instance.reverseButton.Value))
                    {
                        Reverse();
                    }
                }
            }
        }

        public void StartNewChain(BlockProperties startingBlock)
        {
            if (startingBlock == null)
            {
                return;
            }

            startingPosition = startingBlock.transform.position;
            startingRotation = startingBlock.transform.rotation;

            chainStarted = true;
            rctModeActive = true;

            EditorOperations.DeselectAllBlocks(central);
        }

        public void ClearAll()
        {
            chainStarted = false;
            rctModeActive = false;
            startingPosition = Vector3.zero;
            startingRotation = Quaternion.identity;

            foreach(RCTBlock b in blockChain)
            {
                if(b != null)
                {
                    if(b.gameObject != null)
                    {
                        GameObject.Destroy(b.gameObject);
                    }
                }
            }

            blockChain.Clear();
        }

        public void WindowClosed()
        {
            rctModeActive = false;

            foreach (RCTBlock block in blockChain)
            {
                if (block != null && block.gameObject != null)
                {
                    block.gameObject.SetActive(false);
                }
            }
        }

        public void WindowOpened()
        {
            rctModeActive = chainStarted;

            foreach (RCTBlock block in blockChain)
            {
                if (block != null && block.gameObject != null)
                {
                    block.gameObject.SetActive(true);
                }
            }
        }

        public void EnteredLevelEditor(LEV_LevelEditorCentral central)
        {
            CurrentScene = Scene.Editor;
            this.central = central;
            rctMaterial = MaterialManager.AllMaterials[100].material;
        }

        public void ExitedLevelEditor()
        {
            CurrentScene = Scene.Other;
            Plugin.Instance.UIHandler.CloseWindowAndCleanup();
            central = null;
        }

        public void BlockSelectedInBlockGUI(int blockID)
        {
            if (!chainStarted || !rctModeActive)
            {
                return;
            }

            if (!ConnectionData.Supports(blockID))
            {
                Plugin.Instance.LogScreenMessage("Block " + blockID + " not supported by RCT.", 1.5f);
                return;
            }

            RCTBlock block = CreateRCTBlock(blockID);
            if (block == null)
            {
                return;
            }

            blockChain.Add(block);

            if (blockChain.Count == 1)
            {
                RCTBlock last = GetLastBlock();
                last.transform.position = startingPosition;
                last.transform.rotation = startingRotation;
            }
            else
            {
                AlignLastBlock();
            }
        }

        private RCTBlock CreateRCTBlock(int id)
        {
            BlockConnectionPoints connections = ConnectionData.GetBlockConnectionPoints(id);
            if (!connections.valid)
            {
                Debug.LogError("GetBlockConnectionPoints(" + id + ") is invalid. Use ConnectionData.Supports(id) first!");
                return null;
            }

            GameObject block = EditorOperations.CreateGhostBlock(central, id, rctMaterial);
            RCTBlock rct = block.AddComponent<RCTBlock>();
            rct.blockID = id;
            rct.connectionPoints = connections;

            GameObject start = Plugin.Instance.visualizeConnectPoints.Value ? GameObject.CreatePrimitive(PrimitiveType.Cube) : new GameObject("Start");
            Collider startCollider = start.GetComponent<Collider>();
            if (startCollider != null)
            {
                GameObject.Destroy(startCollider);
            }
            start.transform.parent = block.transform;
            start.transform.localPosition = connections.localStartPosition;
            start.transform.localEulerAngles = connections.localStartEuler;
            start.gameObject.name = "Start";
            rct.start = start.transform;

            GameObject end = Plugin.Instance.visualizeConnectPoints.Value ? GameObject.CreatePrimitive(PrimitiveType.Cube) : new GameObject("End");
            Collider endCollider = end.GetComponent<Collider>();
            if (endCollider != null)
            {
                GameObject.Destroy(endCollider);
            }
            end.transform.parent = block.transform;
            end.transform.localPosition = connections.localEndPosition;
            end.transform.localEulerAngles = connections.localEndEuler;
            end.gameObject.name = "End";
            rct.end = end.transform;

            GameObject.DontDestroyOnLoad(rct.gameObject);

            return rct;
        }

        private void AlignLastBlock()
        {
            RCTBlock last = GetLastBlock();
            RCTBlock penultimate = GetPenultimateBlock();

            if (last == null || penultimate == null)
            {
                Debug.LogError("Trying to align blocks but last or penultimate is null!");
                return;
            }

            if (last.isFlipped && last.isReversed && last.connectionPoints.connectionType == ConnectionData.ConnectionType.Curve)
            {
                // Use last.end's local rotation and position
                Quaternion adjustedLocalRotation = last.start.localRotation;
                Vector3 adjustedLocalPosition = last.start.localPosition;

                // Adjust for reversing first (rotate 180 degrees around Y-axis)
                adjustedLocalRotation *= Quaternion.Euler(0, 180f, 0);

                // Adjust for flipping after reversing (negative scale on X-axis)
                adjustedLocalRotation = new Quaternion(
                    -adjustedLocalRotation.x,
                    adjustedLocalRotation.y,
                    -adjustedLocalRotation.z,
                    adjustedLocalRotation.w
                );
                adjustedLocalPosition.x = -adjustedLocalPosition.x;

                // Calculate the new rotation
                last.transform.rotation = penultimate.end.rotation * Quaternion.Inverse(adjustedLocalRotation);

                // Calculate the new position
                Vector3 offset = last.transform.rotation * adjustedLocalPosition;
                last.transform.position = penultimate.end.position - offset;
            }
            else if (last.isFlipped && last.isReversed && last.connectionPoints.connectionType == ConnectionData.ConnectionType.Shift)
            {
                // Use last.end's local rotation and position
                Quaternion adjustedLocalRotation = last.start.localRotation;
                Vector3 adjustedLocalPosition = last.start.localPosition;

                // Adjust for reversing first (rotate 180 degrees around Y-axis)
                //adjustedLocalRotation *= Quaternion.Euler(0, 180f, 0);

                // Adjust for flipping after reversing (negative scale on X-axis)
                adjustedLocalRotation = new Quaternion(
                    -adjustedLocalRotation.x,
                    adjustedLocalRotation.y,
                    -adjustedLocalRotation.z,
                    adjustedLocalRotation.w
                );
                adjustedLocalPosition.x = -adjustedLocalPosition.x;

                // Calculate the new rotation
                last.transform.rotation = penultimate.end.rotation * Quaternion.Inverse(adjustedLocalRotation);

                // Calculate the new position
                Vector3 offset = last.transform.rotation * adjustedLocalPosition;
                last.transform.position = penultimate.end.position - offset;
            }
            else
            {
                //Adjust rotation
                last.transform.rotation = penultimate.end.rotation * Quaternion.Inverse(last.start.localRotation);
                //Adjust position
                Vector3 offset = last.transform.rotation * last.start.localPosition;
                last.transform.localPosition = penultimate.end.position - offset;
            }

            last.rotation = 0f;
        }
        private void RotateLastBlockWithScroll()
        {
            float scrollValue = Input.mouseScrollDelta.y;
            if (scrollValue == 0)
            {
                return;
            }

            if (!central.cam.IsCursorInGameView())
            {
                return;
            }

            if (blockChain.Count < 2)
            {
                return;
            }

            float rotationValue = central.gizmos.list_gridR[central.gizmos.index_gridR] * Mathf.Sign(scrollValue);
            RotateLastBlock(rotationValue);
        }

        private void RotateLastBlock(float angle)
        {
            RCTBlock last = GetLastBlock();
            RCTBlock penultimate = GetPenultimateBlock();

            if (last == null || penultimate == null)
            {
                Debug.LogError("Trying to rotate last block but last or penultimate is null!");
                return;
            }

            last.transform.RotateAround(penultimate.end.position, penultimate.end.forward, angle);
            last.rotation += angle;
        }
        public void Flip()
        {
            if (blockChain.Count == 1)
            {
                Plugin.Instance.LogScreenMessage("Can't flip first object in chain.", 2f);
                return;
            }

            RCTBlock last = GetLastBlock();
            RCTBlock penultimate = GetPenultimateBlock();

            if (last == null || penultimate == null)
            {
                Debug.LogError("Trying to flip last block but last or penultimate is null!");
                return;
            }

            Vector3 flipped = last.transform.localScale;
            flipped.x *= -1;
            last.transform.localScale = flipped;

            last.isFlipped = !last.isFlipped;

            AlignLastBlock();
        }
        public void Reverse()
        {
            if (blockChain.Count == 1)
            {
                PlayerManager.Instance.messenger.Log("Can't reverse first object in chain.", 2f);
                return;
            }

            RCTBlock last = GetLastBlock();
            RCTBlock penultimate = GetPenultimateBlock();

            if (last == null || penultimate == null)
            {
                Debug.LogError("Trying to reverse last block but last or penultimate is null!");
                return;
            }

            //Switch the connection points
            Transform temp = last.start;
            last.start = last.end;
            last.end = temp;

            //Rotate the endpoints so the look the other way
            last.start.Rotate(0, 180, 0);
            last.end.Rotate(0, 180, 0);

            last.isReversed = !last.isReversed;

            AlignLastBlock();
        }
        public void ResetRotation()
        {
            if (blockChain.Count == 1)
            {
                PlayerManager.Instance.messenger.Log("Can't reset rotation of first object in chain.", 2f);
                return;
            }

            RCTBlock last = GetLastBlock();
            RCTBlock penultimate = GetPenultimateBlock();

            if (last == null || penultimate == null)
            {
                Debug.LogError("Trying to reset rotation of last block but last or penultimate is null!");
                return;
            }

            float currentRotation = last.rotation;
            RotateLastBlock(-currentRotation);
            last.rotation = 0;
        }
        public void Undo()
        {
            RCTBlock last = GetLastBlock();

            if (last == null)
            {
                Debug.LogError("Can't undo without blocks!");
                return;
            }

            //Destroy and remove
            GameObject.Destroy(blockChain[blockChain.Count - 1].gameObject);
            blockChain.RemoveAt(blockChain.Count - 1);
        }
        private RCTBlock GetLastBlock()
        {
            if(blockChain.Count > 0)
            {
                return blockChain[blockChain.Count - 1];
            }

            return null;
        }
        private RCTBlock GetPenultimateBlock()
        {
            if(blockChain.Count > 1)
            {
                return blockChain[blockChain.Count - 2];
            }

            return null;
        }
        public void DeleteChain()
        {
            foreach (RCTBlock b in blockChain)
            {
                if (b != null && b.gameObject != null)
                {
                    GameObject.Destroy(b.gameObject);
                }
            }

            blockChain.Clear();
        }
        public void SolidifyChain() 
        {
            EditorOperations.DeselectAllBlocks(central);

            if(blockChain.Count == 0)
            {
                return;
            }

            List<BlockDescription> blocks = new List<BlockDescription>();
            
            foreach(RCTBlock rct in blockChain)
            {
                BlockDescription description = new BlockDescription(rct.blockID, rct.transform.position, rct.transform.rotation, rct.transform.localScale);
                blocks.Add(description);
            }

            EditorOperations.CreateFromDescriptions(central, blocks);
        }

        public string GetCurrentRotationText() 
        {
            RCTBlock last = GetLastBlock();
            float normalizedRotation = (last.rotation % 360 + 360) % 360;
            return normalizedRotation.ToString("F3") + "°";
        }
    }
}
