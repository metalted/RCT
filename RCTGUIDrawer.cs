using Imui.Controls;
using Imui.Core;
using Toolkist;
using ZeepSDK.UI;

namespace RCT
{
    public class RCTGUIDrawer : IZeepGUIDrawer
    {
        private Plugin _plugin;
        private RCTManager _manager;
        private RCTUIHandler _ui;
        private bool mouseInsideRect;

        public RCTGUIDrawer(Plugin plugin, RCTManager manager, RCTUIHandler ui)
        {
            _plugin = plugin;
            _manager = manager;
            _ui = ui;
        }

        public void OnZeepGUI(ImGui gui)
        {
            bool wasOpen = _ui.WindowIsOpen;

            if(_ui.WindowIsOpen)
            {
                if(gui.BeginWindow("RCT", ref _ui.WindowIsOpen, ref mouseInsideRect, _ui.HandleWindowOpened, _ui.HandleWindowClosed, _ui.MouseEnteredWindowRect, _ui.MouseExitedWindowRect, (250, 300)))
                {
                    if(!_manager.chainStarted)
                    {
                        if (_manager.central.selection.list.Count == 1 && _manager.central.selection.list[0].blockID == Plugin.Instance.rctBlockID.Value && !EditorOperations.IsInGMode(_manager.central))
                        {
                            gui.BeginVertical();
                            if(gui.Button("Start Chain"))
                            {
                                _manager.StartNewChain(_manager.central.selection.list[0]);
                            }
                            gui.EndVertical();
                        }
                        else
                        {
                            gui.BeginVertical();
                            gui.Text($"Place block ID {Plugin.Instance.rctBlockID.Value} where you want the chain to start. Rotate it to the desired starting direction, then select only that block. The [Start Chain] button will appear here once the correct block is selected.", wrap: true); 
                            gui.EndVertical();
                        }
                    }
                    else
                    {
                        DrawRCTWindow(gui);
                    }

                    gui.EndWindow();
                }
            }

            if(wasOpen && !_ui.WindowIsOpen)
            {
                _ui.HandleWindowClosed();
            }
        }

        private void DrawRCTWindow(ImGui gui)
        {
            gui.BeginVertical();

            if(_manager.CurrentChainLength == 0)
            {
                gui.Text("Select parts from the inspector on the right to add them to the chain.", wrap: true);
            }

            if(gui.Button("Exit Chain"))
            {
                _manager.ClearAll();
            }

            if (_manager.CurrentChainLength > 0)
            {
                if (gui.Button("Clear Chain"))
                {
                    _manager.DeleteChain();
                }

                if (gui.Button("Solidify Chain"))
                {
                    _manager.SolidifyChain();
                }

                string undoKey = Plugin.Instance.undoButton.Value != UnityEngine.KeyCode.None ? $" ({Plugin.Instance.undoButton.Value.ToString()})" : "";
                if (gui.Button("Undo" + undoKey))
                {
                    _manager.Undo();
                }
            }

            if(_manager.CurrentChainLength > 1)
            {
                string flipKey = Plugin.Instance.flipButton.Value != UnityEngine.KeyCode.None ? $" ({Plugin.Instance.flipButton.Value.ToString()})" : "";
                if (gui.Button("Flip" + flipKey))
                {
                    _manager.Flip();
                }

                string reverseKey = Plugin.Instance.reverseButton.Value != UnityEngine.KeyCode.None ? $" ({Plugin.Instance.reverseButton.Value.ToString()})" : "";
                if (gui.Button("Reverse" + reverseKey))
                {
                    _manager.Reverse();
                }

                if (gui.Button("Reset Rotation"))
                {
                    _manager.ResetRotation();
                }

                gui.Text("Current Rotation:");
                gui.Text(_manager.GetCurrentRotationText());
            }

            gui.EndVertical();
        }        
    }
}
