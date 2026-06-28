using Imui.Controls;
using Imui.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeepSDK.UI;

namespace RCT
{
    public class RCTToolbarDrawer : IZeepToolbarDrawer
    {
        private Plugin _plugin;
        private RCTManager _manager;
        private RCTUIHandler _ui;
        
        public RCTToolbarDrawer(Plugin plugin, RCTManager manager, RCTUIHandler ui)
        {
            _plugin = plugin;
            _manager = manager;
            _ui = ui;
        }

        public string MenuTitle => "RCT";

        public void DrawMenuItems(ImGui gui)
        {
            if (_manager.CurrentScene == Scene.Editor)
            {
                if(gui.Menu("Open Window"))
                {
                    _ui.OpenWindow();
                }                
            }
            else
            {
                if (gui.Menu("Requires Level Editor...")) { }
            }
        }
    }
}
