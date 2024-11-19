using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using ZeepSDK;
using ZeepSDK.LevelEditor;

namespace RCT
{
    public static class RCTManager
    {
        private static LEV_LevelEditorCentral mCentral;

        //RCT
        private static Material mRCTMaterial;
        private static bool mRCTModeEnabled = false;
        private static Vector3 mStartingPosition = Vector3.zero;
        private static Quaternion mStartingRotation = Quaternion.identity;
        private static List<RCTBlock> mBlockChain = new List<RCTBlock>();

        //The window rect for UIConfigurator.
        public static RectTransform mRCTWindow;
        public static Rect mRCTWindowRect;
        
        //Mouse in rect
        private static bool mouseInRect;
        private static object mLock = new object();

        public static void Initialize()
        {

        }

        public static bool IsEnabled()
        {
            return mRCTModeEnabled;
        }

        public static void DoUpdate()
        {
            if (mCentral == null)
            {
                return;
            }

            HandleKeyboardInput();

            if (mRCTWindowRect.Contains(Event.current.mousePosition))
            {
                if (!mouseInRect)
                {
                    mouseInRect = true;
                    DoMouseBlock(true);
                }
            }
            else
            {
                if (mouseInRect)
                {
                    mouseInRect = false;
                    DoMouseBlock(false);
                }
            }
        }

        public static void DoMouseBlock(bool state)
        {
            if (state)
            {
                LevelEditorApi.BlockMouseInput(mLock);
            }
            else
            {
                LevelEditorApi.UnblockMouseInput(mLock);
            }
        }

        private static void HandleKeyboardInput()
        {
            if (Input.GetKeyDown(Plugin.Instance.rctButton.Value))
            {
                ToggleRCTMode();
            }

            if (mRCTModeEnabled)
            {
                RotateLastBlockWithScroll();

                if (Input.GetKeyDown(Plugin.Instance.deleteChainButton.Value))
                {
                    DeleteChain();
                }

                if (Input.GetKeyDown(Plugin.Instance.solidifyChainButton.Value))
                {
                    SolidifyChain();
                }

                if (Input.GetKeyDown(Plugin.Instance.undoButton.Value))
                {
                    Undo();
                }

                if (Input.GetKeyDown(Plugin.Instance.flipButton.Value))
                {
                    FlipLastBlock();
                }

                if (Input.GetKeyDown(Plugin.Instance.reverseButton.Value))
                {
                    ReverseLastBlock();
                }

                if (Input.GetKeyDown(Plugin.Instance.resetRotationButton.Value))
                {
                    ResetRotationLastBlock();
                }
            }
        }

        public static void DoGUI()
        {
            if (mRCTModeEnabled)
            {
                // Calculate the actual Rect in screen space
                Vector2 screenMin = RectTransformUtility.WorldToScreenPoint(null, mRCTWindow.TransformPoint(mRCTWindow.rect.min));
                Vector2 screenMax = RectTransformUtility.WorldToScreenPoint(null, mRCTWindow.TransformPoint(mRCTWindow.rect.max));

                // Convert screen space to GUI space
                float guiYMin = Screen.height - screenMax.y;
                float guiYMax = Screen.height - screenMin.y;
                mRCTWindowRect = new Rect(screenMin.x, guiYMin, screenMax.x - screenMin.x, guiYMax - guiYMin);

                // Draw the main box
                GUI.Box(mRCTWindowRect, "", GUIStyleX.windowBody);

                // Calculate positions within the box relative to its RectTransform                
                float buttonHeight = 25f;
                float padding = 5f;
                float buttonWidth = mRCTWindowRect.width - padding * 2;

                // Starting x and y positions for elements within the box
                float startX = mRCTWindowRect.x;
                float startY = mRCTWindowRect.y; // Move down for title

                // Title position (spanning full width)
                Rect titleRect = new Rect(mRCTWindowRect.x, mRCTWindowRect.y, mRCTWindowRect.width, buttonHeight);
                GUI.Box(titleRect, "RCT Mode", GUIStyleX.windowHeader);

                if(GUI.Button(new Rect(mRCTWindowRect.x + mRCTWindowRect.width - buttonHeight, mRCTWindowRect.y, buttonHeight, buttonHeight), "X", GUIStyleX.windowCloseButton))
                {
                    ToggleRCTMode();
                }

                startY += buttonHeight + padding;
                startX += padding;

                string deleteChainText = "Delete Chain" + (Plugin.Instance.deleteChainButton.Value != KeyCode.None ? (" (" + Plugin.Instance.deleteChainButton.Value.ToString() + ")") : "");
                if (GUI.Button(new Rect(startX, startY, buttonWidth, buttonHeight), deleteChainText, GUIStyleX.windowButton))
                {
                    DeleteChain();
                }

                startY += buttonHeight + padding;

                string solidifyChainText = "Solidify Chain" + (Plugin.Instance.solidifyChainButton.Value != KeyCode.None ? (" (" + Plugin.Instance.solidifyChainButton.Value.ToString() + ")") : "");
                if (GUI.Button(new Rect(startX, startY, buttonWidth, buttonHeight), solidifyChainText, GUIStyleX.windowButton))
                {
                    SolidifyChain();
                }

                startY += buttonHeight + padding;

                string undoText = "Undo" + (Plugin.Instance.undoButton.Value != KeyCode.None ? (" (" + Plugin.Instance.undoButton.Value.ToString() + ")") : "");
                if (GUI.Button(new Rect(startX, startY, buttonWidth, buttonHeight), undoText, GUIStyleX.windowButton))
                {
                    Undo();
                }

                startY += buttonHeight + padding;

                string flipText = "Flip" + (Plugin.Instance.flipButton.Value != KeyCode.None ? (" (" + Plugin.Instance.flipButton.Value.ToString() + ")") : "");
                if (GUI.Button(new Rect(startX, startY, buttonWidth, buttonHeight), flipText, GUIStyleX.windowButton))
                {
                    FlipLastBlock();
                }

                startY += buttonHeight + padding;

                string reverseText = "Reverse" + (Plugin.Instance.reverseButton.Value != KeyCode.None ? (" (" + Plugin.Instance.reverseButton.Value.ToString() + ")") : "");
                if (GUI.Button(new Rect(startX, startY, buttonWidth, buttonHeight), reverseText, GUIStyleX.windowButton))
                {
                    ReverseLastBlock();
                }

                startY += buttonHeight + padding;

                string resetRotationText = "Reset Rotation" + (Plugin.Instance.resetRotationButton.Value != KeyCode.None ? (" (" + Plugin.Instance.resetRotationButton.Value.ToString() + ")") : "");
                if (GUI.Button(new Rect(startX, startY, buttonWidth, buttonHeight), resetRotationText, GUIStyleX.windowButton))
                {
                    ResetRotationLastBlock();
                }

                startY += buttonHeight + padding;

                if (mBlockChain.Count > 1)
                {
                    RCTBlock last = GetLastBlock();
                    float normalizedRotation = (last.rotation % 360 + 360) % 360;

                    GUI.Box(new Rect(startX, startY, buttonWidth, buttonHeight), "Rotation", GUIStyleX.windowButton);
                    startY += buttonHeight;
                    GUI.Box(new Rect(startX, startY, buttonWidth, buttonHeight), normalizedRotation.ToString("F3") + "°", GUIStyleX.windowTimeLabel);
                }
            }
        }

        #region Events
        public static void OnLevelEditor(LEV_LevelEditorCentral central)
        {
            mCentral = central;
            mRCTMaterial = MaterialManager.AllMaterials[100].material;
            mRCTModeEnabled = false;
            mBlockChain.Clear();

            /*Set up the window*/
            // Find the Canvas in the hierarchy of LEV_LevelEditorCentral
            RectTransform canvasRectTransform = central.transform.Find("Canvas").GetComponent<RectTransform>();

            // Create a new GameObject that will act as the window you want to position
            GameObject newWindow = new GameObject("RCTWindow", typeof(RectTransform));

            // Set the new GameObject's parent to be the canvas.
            newWindow.transform.SetParent(canvasRectTransform, false);
            //Make it appear on top.
            newWindow.transform.SetAsFirstSibling();

            // Get the RectTransform component of the new GameObject
            RectTransform pmWindowRectTransform = newWindow.GetComponent<RectTransform>();

            // Optionally, set the RectTransform's properties to desired values
            pmWindowRectTransform.anchorMin = new Vector2(0.5f, 0.5f); // Center anchor
            pmWindowRectTransform.anchorMax = new Vector2(0.5f, 0.5f);
            pmWindowRectTransform.pivot = new Vector2(0.5f, 0.5f);
            pmWindowRectTransform.anchoredPosition = Vector2.zero; // Center position
            pmWindowRectTransform.sizeDelta = new Vector2(200, 270); // Width and height

            // Save the RectTransform.
            mRCTWindow = pmWindowRectTransform;
            //Add it to the configurator.
            ZeepSDK.UI.UIApi.AddToConfigurator(mRCTWindow);
        }

        public static void OnNotLevelEditor()
        {
            mCentral = null;
            mRCTModeEnabled = false;
            mBlockChain.Clear();
            mouseInRect = false;
            DoMouseBlock(false);
        }

        public static void BlockSelectedInBlockGUI(int blockID)
        {
            //Check if block is supported.
            if (!ConnectionData.Supports(blockID))
            {
                PlayerManager.Instance.messenger.Log("Block not supported by RCT.", 1f);
                return;
            }

            RCTBlock block = CreateRCTBlock(blockID);
            if (block == null)
            {
                return;
            }

            mBlockChain.Add(block);

            if (mBlockChain.Count == 1)
            {
                GetLastBlock().transform.position = mStartingPosition;
                GetLastBlock().transform.rotation = mStartingRotation;
            }

            if (mBlockChain.Count > 1)
            {
                //AlignTube(blockChain[blockChain.Count - 2].end, blockChain[blockChain.Count - 1].transform, blockChain[blockChain.Count - 1].start);
                AlignLastBlock();
            }
        }
        #endregion

        #region RCT
        private static void ToggleRCTMode()
        {
            //If its enabled, turn it off.
            if (mRCTModeEnabled)
            {
                mRCTModeEnabled = false;

                //Hide all parts of the blockchain.
                if (mBlockChain.Count > 0)
                {
                    foreach (RCTBlock b in mBlockChain)
                    {
                        b.gameObject.SetActive(false);
                    }
                }

                PlayerManager.Instance.messenger.Log("RCT: Off", 1f);
                return;
            }

            //If rct is off, but the blockchain still contains blocks:
            if (mBlockChain.Count > 0)
            {
                mRCTModeEnabled = true;

                //Turn on the block chain.
                foreach (RCTBlock b in mBlockChain)
                {
                    b.gameObject.SetActive(true);
                }

                PlayerManager.Instance.messenger.Log("RCT: On", 1f);
                mCentral.selection.DeselectAllBlocks(false, "");
                return;
            }

            //If the block chain is empty, and one block is selected (current requirement for RCT)
            if (mCentral.selection.list.Count == 1)
            {
                if (mCentral.selection.list[0].blockID == Plugin.Instance.rctBlockID.Value)
                {
                    mRCTModeEnabled = true;
                    mStartingPosition = mCentral.selection.list[0].transform.position;
                    mStartingRotation = mCentral.selection.list[0].transform.rotation;

                    PlayerManager.Instance.messenger.Log("RCT: On", 1f);
                    mCentral.selection.DeselectAllBlocks(false, "");
                }

                //Show a message on screen on how to enable RCT.
                else
                {
                    string blockName = "Error";
                    try
                    {
                        blockName = PlayerManager.Instance.loader.globalBlockList.blocks[Plugin.Instance.rctBlockID.Value].name;
                    }
                    catch { }

                    PlayerManager.Instance.messenger.Log("To enable RCT Mode: \n(1) Deselect all. \n(2) Select block [ID: " + Plugin.Instance.rctBlockID.Value + " | Name: " + blockName + "]. \n(3) Press [" + ((KeyCode)Plugin.Instance.rctButton.Value).ToString() + "]", 8f);
                }
            }
            else
            {
                string blockName = "Error";
                try
                {
                    blockName = PlayerManager.Instance.loader.globalBlockList.blocks[Plugin.Instance.rctBlockID.Value].name;
                }
                catch { }

                PlayerManager.Instance.messenger.Log("To enable RCT Mode: \n(1) Deselect all. \n(2) Select block [ID: " + Plugin.Instance.rctBlockID.Value + " | Name: " + blockName + "]. \n(3) Press [" + ((KeyCode)Plugin.Instance.rctButton.Value).ToString() + "]", 8f);
            }
        }

        private static RCTBlock GetLastBlock()
        {
            if (mBlockChain.Count > 0)
            {
                return mBlockChain[mBlockChain.Count - 1];
            }

            return null;
        }

        private static RCTBlock GetPenultimateBlock()
        {
            if (mBlockChain.Count > 1)
            {
                return mBlockChain[mBlockChain.Count - 2];
            }

            return null;
        }
        #endregion

        #region RCT Actions
        private static RCTBlock CreateRCTBlock(int id)
        {
            BlockConnectionPoints connections = ConnectionData.GetBlockConnectionPoints(id);
            if (!connections.valid)
            {
                Debug.LogError("GetBlockConnectionPoints(" + id + ") is invalid. Use ConnectionData.Supports(id) first!");
                return null;
            }

            //Create the block.
            BlockProperties blockProperties = UnityEngine.Object.Instantiate<BlockProperties>(PlayerManager.Instance.loader.globalBlockList.blocks[id]);
            blockProperties.CreateBlock();
            for (int index = 0; index < blockProperties.propertyScripts.Count; ++index)
            {
                blockProperties.propertyScripts[index].CreateBlock(blockProperties);
            }

            //Set all objects to the rct material
            Properties_RoadPainter component = blockProperties.gameObject.GetComponent<Properties_RoadPainter>();
            foreach (MeshRenderer ren in component.renderers)
            {
                Material[] sharedMaterials = ren.sharedMaterials;
                for (int i = 0; i < sharedMaterials.Length; ++i)
                {
                    sharedMaterials[i] = mRCTMaterial;
                }
                ren.sharedMaterials = sharedMaterials;
            }

            GameObject block = blockProperties.gameObject;

            Utils.RemoveUnwantedComponents(block);
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

            return rct;
        }

        private static void AlignLastBlock()
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

        private static void RotateLastBlockWithScroll()
        {
            float scrollValue = Input.mouseScrollDelta.y;
            if (scrollValue == 0)
            {
                return;
            }

            if (!mCentral.cam.IsCursorInGameView())
            {
                return;
            }

            RCTBlock last = GetLastBlock();

            if (last == null)
            {
                return;
            }

            float rotationValue = mCentral.gizmos.list_gridR[mCentral.gizmos.index_gridR] * Mathf.Sign(scrollValue);
            RotateLastBlock(rotationValue);
        }

        private static void RotateLastBlock(float angle)
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

        private static void FlipLastBlock()
        {
            if (mBlockChain.Count == 1)
            {
                PlayerManager.Instance.messenger.Log("Can't flip first object in chain.", 2f);
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

        private static void ReverseLastBlock()
        {
            if (mBlockChain.Count == 1)
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

        private static void ResetRotationLastBlock()
        {
            if (mBlockChain.Count == 1)
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

        private static void Undo()
        {
            RCTBlock last = GetLastBlock();

            if (last == null)
            {
                Debug.LogError("Can't undo without blocks!");
                return;
            }

            //Destroy and remove
            GameObject.Destroy(mBlockChain[mBlockChain.Count - 1].gameObject);
            mBlockChain.RemoveAt(mBlockChain.Count - 1);
        }

        private static void DeleteChain()
        {
            foreach (RCTBlock b in mBlockChain)
            {
                if (b.gameObject != null)
                {
                    GameObject.Destroy(b.gameObject);
                }
            }

            mBlockChain.Clear();
        }

        private static void SolidifyChain()
        {
            mCentral.selection.DeselectAllBlocks(true, "");

            if (mBlockChain.Count == 0)
            {
                return;
            }

            List<string> before = Enumerable.Repeat((string)null, mBlockChain.Count).ToList();

            //Create a list of selections before the creation, which is empty.
            List<string> beforeSelection = new List<string>();

            //Stores the JSON strings of the blocks after creation.
            List<string> after = new List<string>();
            //Stores the selection after creation.
            List<string> afterSelection = new List<string>();

            //Stores the BlockProperties objects of the created blocks.
            List<BlockProperties> blockList = new List<BlockProperties>();

            foreach (RCTBlock block in mBlockChain)
            {
                //Create the actual block at this position and rotation
                BlockProperties blockProperties = UnityEngine.Object.Instantiate<BlockProperties>(PlayerManager.Instance.loader.globalBlockList.blocks[block.blockID]);
                blockProperties.isBeingCreated = true;
                blockProperties.gameObject.name = PlayerManager.Instance.loader.globalBlockList.blocks[block.blockID].name;
                blockProperties.UID = mCentral.manager.GenerateUniqueIDforBlocks(block.blockID.ToString());
                blockProperties.isEditor = true;
                blockProperties.CreateBlock();
                for (int index = 0; index < blockProperties.propertyScripts.Count; ++index)
                {
                    blockProperties.propertyScripts[index].CreateBlock(blockProperties);
                }

                blockProperties.transform.position = block.transform.position;
                blockProperties.transform.rotation = block.transform.rotation;
                blockProperties.transform.localScale = block.transform.localScale;

                after.Add(blockProperties.ConvertBlockToJSON_v15_string());
                blockList.Add(blockProperties);
            }

            afterSelection = mCentral.undoRedo.ConvertSelectionToStringList(blockList);

            //Convert all the before and after data into a Change_Collection.
            Change_Collection collection = mCentral.undoRedo.ConvertBeforeAndAfterListToCollection(
                before, after,
                blockList,
                beforeSelection, afterSelection);

            //Register the creation
            mCentral.validation.BreakLock(collection, "Gizmo6");

            //Select all the created objects.
            mCentral.selection.UndoRedoReselection(blockList);

            if (Plugin.Instance.deleteOnSolidify.Value)
            {
                DeleteChain();
            }
        }
        #endregion
    }
}
