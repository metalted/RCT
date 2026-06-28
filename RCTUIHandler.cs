using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeepSDK.LevelEditor;

namespace RCT
{
    public class RCTUIHandler
    {
        public bool WindowIsOpen = false;
        private bool _mouseIsBlocked = false;
        private readonly object _lock = new object();

        public void OpenWindow()
        {
            WindowIsOpen = true;
        }

        public void CloseWindowAndCleanup()
        {
            WindowIsOpen = false;
            HandleWindowClosed();
        }

        public void HandleWindowClosed()
        {
            if(_mouseIsBlocked)
            {
                _mouseIsBlocked = false;
                LevelEditorApi.UnblockMouseInput(_lock);
            }

            Plugin.Instance.RCTManager.WindowClosed();
        }

        public void HandleWindowOpened()
        {
            Plugin.Instance.RCTManager.WindowOpened();
        }

        public void MouseEnteredWindowRect()
        {
            if(!_mouseIsBlocked)
            {
                LevelEditorApi.BlockMouseInput(_lock);
                _mouseIsBlocked = true;
            }
        }

        public void MouseExitedWindowRect()
        {
            if(_mouseIsBlocked)
            {
                LevelEditorApi.UnblockMouseInput(_lock);
                _mouseIsBlocked = false;
            }
        }
    }
}
