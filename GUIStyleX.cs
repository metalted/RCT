using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace RCT
{
    public static class GUIStyleX
    {
        #region Initialize
        public static GUIStyle windowHeader;
        public static GUIStyle windowBody;
        public static GUIStyle windowButton;
        public static GUIStyle windowTimeLabel;
        public static GUIStyle windowSlider;
        public static GUIStyle windowSliderThumb;
        public static GUIStyle windowCloseButton;

        public static Color32 headerGrey = new Color32(87, 87, 87, 255);
        public static Color32 zeepkistOrange = new Color32(255, 146, 0, 255);
        public static Color32 darkRed = new Color32(137, 0, 0, 255);
        public static Color32 directoryOrange = new Color32(255, 189, 100, 255);
        public static Color32 basicWhite = new Color32(255, 255, 255, 255);
        public static Color32 oddListGrey = new Color32(161, 156, 137, 255);
        public static Color32 evenListGrey = new Color32(144, 128, 109, 255);
        public static Color32 basicGreen = new Color32(0, 255, 0, 255);
        public static Color32 basicRed = new Color32(255, 0, 0, 255);
        public static Color32 hoverOrange = new Color32(255, 201, 128, 255);
        public static Color32 activeYellow = new Color32(255, 225, 0, 255);
        public static Color32 listItemSelected = new Color32(127, 166, 255, 255);
        public static Color32 optionBlue = new Color32(64, 122, 255, 255);
        public static Color32 optionBlueHover = new Color32(128, 166, 255, 255);

        public static Dictionary<string, Texture2D> textures = new Dictionary<string, Texture2D>();
        public static string[] names = new string[] { "HeaderGrey", "ZeepkistOrange", "DarkRed", "DirectoryOrange", "BasicWhite", "OddListGrey", "EvenListGrey", "BasicGreen", "BasicRed", "HoverOrange", "ActiveYellow", "ListItemSelected", "OptionBlue", "OptionBlueHover" };
        public static Color32[] colors = new Color32[] { headerGrey, zeepkistOrange, darkRed, directoryOrange, basicWhite, oddListGrey, evenListGrey, basicGreen, basicRed, hoverOrange, activeYellow, listItemSelected, optionBlue, optionBlueHover };

        public static void Initialize()
        {
            for (int i = 0; i < colors.Length; i++)
            {
                Texture2D tex = new Texture2D(1, 1);
                tex.SetPixel(0, 0, colors[i]);
                tex.Apply();

                textures.Add(names[i], tex);
            }

            windowHeader = new GUIStyle();
            windowHeader.normal.background = textures["HeaderGrey"];
            windowHeader.normal.textColor = Color.white;
            windowHeader.fontStyle = FontStyle.Bold;
            windowHeader.alignment = TextAnchor.MiddleCenter;

            windowBody = new GUIStyle();
            windowBody.normal.background = textures["ZeepkistOrange"];

            windowButton = new GUIStyle();
            windowButton.normal.background = textures["OptionBlue"];
            windowButton.hover.background = textures["OptionBlueHover"];
            windowButton.active.background = textures["ActiveYellow"];
            windowButton.normal.textColor = Color.white;
            windowButton.hover.textColor = Color.white;
            windowButton.active.textColor = Color.white;
            windowButton.fontStyle = FontStyle.Bold;
            windowButton.alignment = TextAnchor.MiddleCenter;

            windowTimeLabel = new GUIStyle();
            windowTimeLabel.normal.background = textures["BasicWhite"];
            windowTimeLabel.normal.textColor = Color.black;
            windowTimeLabel.fontStyle = FontStyle.Bold;
            windowTimeLabel.alignment = TextAnchor.MiddleCenter;

            windowSlider = new GUIStyle();
            windowSlider.normal.background = textures["OddListGrey"];
            windowSlider.fixedHeight = 10f;

            windowSliderThumb = new GUIStyle();
            windowSliderThumb.normal.background = textures["OptionBlue"];
            windowSliderThumb.hover.background = textures["OptionBlueHover"];
            windowSliderThumb.active.background = textures["ActiveYellow"];
            windowSliderThumb.fixedWidth = 25f;
            windowSliderThumb.fixedHeight = 25f;

            windowCloseButton = new GUIStyle();
            windowCloseButton.normal.background = textures["DarkRed"];
            windowCloseButton.hover.background = textures["BasicRed"];
            windowCloseButton.active.background = textures["ActiveYellow"];
            windowCloseButton.normal.textColor = Color.white;
            windowCloseButton.hover.textColor = Color.white;
            windowCloseButton.active.textColor = Color.white;
            windowCloseButton.fontStyle = FontStyle.Bold;
            windowCloseButton.alignment = TextAnchor.MiddleCenter;
        }
        #endregion
    }
}
