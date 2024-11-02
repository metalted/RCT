using System.Collections.Generic;
using UnityEngine;

namespace RCT
{
    public static class ConnectionData
    {
        public enum ConnectionType { Standard, Curve, Shift };

        private static Dictionary<int, BlockConnectionPoints> connectionData = new Dictionary<int, BlockConnectionPoints>()
        {
            #region Tubes
            //Single straight
            { 56, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,8f), Vector3.zero) },
            //1x1 bend
            { 58, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-8f,4f, 0f), new Vector3(0, -90f, 0), ConnectionType.Curve) },
            //2x2 bend
            { 59, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-24f,4f, 16f), new Vector3(0, -90f, 0), ConnectionType.Curve) },
            //3x3 bend
            { 60, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-40f,4f, 32f), new Vector3(0, -90f, 0), ConnectionType.Curve) },
            //4x4 bend (open top)
            { 116, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-56f,4f, 48f), new Vector3(0, -90f, 0), ConnectionType.Curve) },

            //Single straight (open top)
            { 227, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,8f), Vector3.zero) },
            //1x1 bend (open top)
            { 228, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-8f,4f, 0f), new Vector3(0, -90f, 0), ConnectionType.Curve) },
            //2x2 bend (open top)
            { 229, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-24f,4f, 16f), new Vector3(0, -90f, 0), ConnectionType.Curve) },
            //3x3 bend (open top)
            { 230, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-40f,4f, 32f), new Vector3(0, -90f, 0), ConnectionType.Curve) },
            //4x4 bend (open top)
            { 231, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-56f,4f, 48f), new Vector3(0, -90f, 0), ConnectionType.Curve) },

            //Single straight (open side)
            { 257, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,8f), Vector3.zero) },
            //1x1 bend (open side)
            { 258, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-8f,4f, 0f), new Vector3(0, -90f, 0), ConnectionType.Curve) },
            //2x2 bend (open side)
            { 259, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-24f,4f, 16f), new Vector3(0, -90f, 0), ConnectionType.Curve) },
            //3x3 bend (open side)
            { 260, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-40f,4f, 32f), new Vector3(0, -90f, 0), ConnectionType.Curve) },
            //4x4 bend (open side)
            { 261, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-56f,4f, 48f), new Vector3(0, -90f, 0), ConnectionType.Curve) },

            //Folder 201
            { 226, new BlockConnectionPoints( new Vector3(0,-4f,0), new Vector3(-90f, 0, 0), new Vector3(0,64f, 0), new Vector3(-90f, 0, 0)) },
            { 248, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,40f), Vector3.zero) },
            { 57, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,24f), Vector3.zero) },
            { 341, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,24f), Vector3.zero) },
            { 342, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,20f,24f), Vector3.zero) },
            { 343, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,40f), Vector3.zero) },
            { 344, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,24f), Vector3.zero) },
            { 345, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,20f,24f), Vector3.zero) },
            { 346, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-24f,4f,16f), new Vector3(0,-90f,0), ConnectionType.Curve) },
            { 347, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,20f,24f), Vector3.zero) },
            { 348, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,20f,24f), Vector3.zero) },
            { 1232, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,8f), Vector3.zero) },
            { 1233, new BlockConnectionPoints( new Vector3(0,12f,-8f), Vector3.zero, new Vector3(0,12f,8f), Vector3.zero) },
            { 124, new BlockConnectionPoints( new Vector3(0,4f,6.4f), Vector3.zero, new Vector3(0,4f,8f), Vector3.zero) },
            { 1461, new BlockConnectionPoints( new Vector3(0,-4f,-8f), Vector3.zero, new Vector3(0,12f,40f), Vector3.zero) },
            { 1555, new BlockConnectionPoints( new Vector3(0,4f,6.4f), Vector3.zero, new Vector3(0,4f,8f), Vector3.zero) },
            { 1618, new BlockConnectionPoints( new Vector3(0,4f,7.2f), Vector3.zero, new Vector3(0,4f,8.8f), Vector3.zero) },
            { 1619, new BlockConnectionPoints( new Vector3(0,4f,7.4f), Vector3.zero, new Vector3(0,4f,8.8f), Vector3.zero) },
            { 1620, new BlockConnectionPoints( new Vector3(0,4f,7.4f), Vector3.zero, new Vector3(0,4f,8.8f), Vector3.zero) },
            { 2184, new BlockConnectionPoints( new Vector3(8f, 4f, 0), new Vector3(0,-90f,0), new Vector3(0,4f,8f), Vector3.zero, ConnectionType.Curve) },
            { 2185, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,24f), Vector3.zero) },
            { 2186, new BlockConnectionPoints( new Vector3(0,4f,6.4f), Vector3.zero, new Vector3(0,4f,8f), Vector3.zero) },
            { 2187, new BlockConnectionPoints( new Vector3(0,4f,6.4f), Vector3.zero, new Vector3(0,4f,8f), Vector3.zero) },

            //Folder 202
            { 1709, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,16f), new Vector3(-90f, 0, 0)) },
            { 1710, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,28f,32f), new Vector3(-90f, 0, 0)) },
            { 1711, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,44f,48f), new Vector3(-90f, 0, 0)) },
            { 1712, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,60f,64f), new Vector3(-90f, 0, 0)) },
            { 1713, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,0f), new Vector3(-90f, 0, 0)) },
            { 1714, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,28f,16f), new Vector3(-90f, 0, 0)) },
            { 1715, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,44f,32f), new Vector3(-90f, 0, 0)) },
            { 1716, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,60f,48f), new Vector3(-90f, 0, 0)) },
            { 1721, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-24f,4f,16f), new Vector3(0,-90f,0), ConnectionType.Curve) },
            { 1722, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-40f,4f,32f), new Vector3(0,-90f,0), ConnectionType.Curve) },
            { 1723, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-56f,4f,48f), new Vector3(0,-90f,0), ConnectionType.Curve) },
            { 1718, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-24f,4f,16f), new Vector3(0,-90f,0), ConnectionType.Curve) },
            { 1719, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-40f,4f,32f), new Vector3(0,-90f,0), ConnectionType.Curve) },
            { 1720, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-56f,4f,48f), new Vector3(0,-90f,0), ConnectionType.Curve) },
            { 1724, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-24f,-4f,16f), new Vector3(0,-90f,0), ConnectionType.Curve) },
            { 1725, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-40f,-4f,32f), new Vector3(0,-90f,0), ConnectionType.Curve) },
            { 1726, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-56f,-4f,48f), new Vector3(0,-90f,0), ConnectionType.Curve) },
            { 2203, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,40f), Vector3.zero) },
            { 2204, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,40f), Vector3.zero) },

            //Folder 203
             { 110, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,24f), Vector3.zero) },
             { 61, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,20f,24f), Vector3.zero) },
             { 62, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,20f,24f), Vector3.zero) },
             { 63, new BlockConnectionPoints( new Vector3(0,4f,8f), new Vector3(0,180f,0), new Vector3(0,20f,-8f), new Vector3(0,180f,0)) },
             { 114, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,28f,24f), Vector3.zero) },
             { 115, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,28f,24f), Vector3.zero) },
             { 112, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,24f), Vector3.zero) },
             { 111, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,24f), Vector3.zero) },
             { 113, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,8f), Vector3.zero) },
             { 1239, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,20f,40f), Vector3.zero) },
             { 1240, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,20f,40f), Vector3.zero) },
             { 1238, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,40f), Vector3.zero) },
             { 1237, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,40f), Vector3.zero) },
             { 1234, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,24f), Vector3.zero) },
             { 1235, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,40f), Vector3.zero) },
             { 1236, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,56f), Vector3.zero) },
             { 336, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,40f), Vector3.zero) },
             { 335, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,40f), Vector3.zero) },

             //Folder 204
             { 117, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-48f,-4f,-8f), new Vector3(0,180f,0), ConnectionType.Curve) },
             { 118, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-24f,-4f,16f), new Vector3(0,-90f,0), ConnectionType.Curve) },
             { 119, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-40f,-4f,32f), new Vector3(0,-90f,0), ConnectionType.Curve) },
             { 120, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-56f,-4f, 48f), new Vector3(0,-90f,0), ConnectionType.Curve) },
             { 121, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-24f,-12f,16f), new Vector3(0,-90f,0), ConnectionType.Curve) },
             { 122, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-40f,-20f,32f), new Vector3(0,-90f,0), ConnectionType.Curve) },
             { 123, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-56f,-28f, 48f), new Vector3(0,-90f,0), ConnectionType.Curve) },

             //Folder 205
             { 232, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,24f), Vector3.zero) },
             { 236, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,20f,24f), Vector3.zero) },
             { 234, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,20f,24f), Vector3.zero) },
             { 240, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,20f,8f), Vector3.zero) },
             { 237, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,28f,24f), Vector3.zero) },
             { 238, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,28f,24f), Vector3.zero) },
             { 235, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,24f), Vector3.zero) },
             { 233, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,24f), Vector3.zero) },
             { 239, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,8f), Vector3.zero) },
             { 1246, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,20f,40f), Vector3.zero) },
             { 1247, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,20f,40f), Vector3.zero) },
             { 1245, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,40f), Vector3.zero) },
             { 1244, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,40f), Vector3.zero) },
             { 1241, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,24f), Vector3.zero) },
             { 1242, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,40f), Vector3.zero) },
             { 1243, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,56f), Vector3.zero) },

             { 337, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,40f), Vector3.zero) },
             { 338, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,40f), Vector3.zero) },

             { 249, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,0f), new Vector3(-90f, 0, 0)) },
             { 250, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,28f,16f), new Vector3(-90f, 0, 0)) },
             { 251, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,44f,32f), new Vector3(-90f, 0, 0)) },
             { 252, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,60f,48f), new Vector3(-90f, 0, 0)) },

             { 253, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,-4f,0f), new Vector3(90f, 0, 0)) },
             { 254, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,-20f,16f), new Vector3(90f, 0, 0)) },
             { 255, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,-36f,32f), new Vector3(90f, 0, 0)) },
             { 256, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,-52f,48f), new Vector3(90f, 0, 0)) },

            //Folder 206
             { 244, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-48f,-4f,-8f), new Vector3(0,180f,0), ConnectionType.Curve) },
             { 241, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-24f,-4f,16f), new Vector3(0,-90f,0), ConnectionType.Curve) },
             { 242, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-40f,-4f,32f), new Vector3(0,-90f,0), ConnectionType.Curve) },
             { 243, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-56f,-4f, 48f), new Vector3(0,-90f,0), ConnectionType.Curve) },
             { 245, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-24f,-12f,16f), new Vector3(0,-90f,0), ConnectionType.Curve) },
             { 246, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-40f,-20f,32f), new Vector3(0,-90f,0), ConnectionType.Curve) },
             { 247, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-56f,-28f, 48f), new Vector3(0,-90f,0), ConnectionType.Curve) },

            //Folder 207
             { 262, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,24f), Vector3.zero) },
             { 266, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,20f,24f), Vector3.zero) },
             { 264, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,20f,24f), Vector3.zero) },
             { 270, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,20f,8f), Vector3.zero) },
             { 267, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,28f,24f), Vector3.zero) },
             { 268, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,28f,24f), Vector3.zero) },
             { 265, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,24f), Vector3.zero) },
             { 263, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,24f), Vector3.zero) },
             { 269, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,8f), Vector3.zero) },
             { 1253, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,20f,40f), Vector3.zero) },
             { 1254, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,20f,40f), Vector3.zero) },
             { 1252, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,40f), Vector3.zero) },
             { 1251, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,40f), Vector3.zero) },
             { 1248, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,24f), Vector3.zero) },
             { 1249, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,40f), Vector3.zero) },
             { 1250, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,56f), Vector3.zero) },
             { 339, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,40f), Vector3.zero) },
             { 340, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,40f), Vector3.zero) },

            //Folder 208
             { 274, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-48f,-4f,-8f), new Vector3(0,180f,0), ConnectionType.Curve) },
             { 271, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-24f,-4f,16f), new Vector3(0,-90f,0), ConnectionType.Curve) },
             { 272, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-40f,-4f,32f), new Vector3(0,-90f,0), ConnectionType.Curve) },
             { 273, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-56f,-4f, 48f), new Vector3(0,-90f,0), ConnectionType.Curve) },
             { 275, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-24f,-12f,16f), new Vector3(0,-90f,0), ConnectionType.Curve) },
             { 276, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-40f,-20f,32f), new Vector3(0,-90f,0), ConnectionType.Curve) },
             { 277, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-56f,-28f, 48f), new Vector3(0,-90f,0), ConnectionType.Curve) },

            //Folder 209
            { 1547, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,8f), Vector3.zero) },
            { 1548, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,8f), Vector3.zero) },
            { 1549, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-8f,4f,0f), new Vector3(0,-90f,0), ConnectionType.Curve) },
            { 1550, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-8f,4f,0f), new Vector3(0,-90f,0), ConnectionType.Curve) },
            { 1551, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,40f), Vector3.zero) },
            { 1552, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,40f), Vector3.zero) },
            { 1553, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-24f,4f,16f), new Vector3(0,-90f,0), ConnectionType.Curve) },
            { 1554, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-24f,4f,16f), new Vector3(0,-90f,0), ConnectionType.Curve) },
            #endregion

            #region Roads

            //Reversed Flipped roads are not working

            //Folder 101 (OK)
            { 0, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,8f), Vector3.zero) },
            //1x1 bend
            { 3, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-8f,4f, 0f), new Vector3(0, -90f, 0), ConnectionType.Curve) },
            //2x2 bend
            { 4, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-24f,4f, 16f), new Vector3(0, -90f, 0), ConnectionType.Curve) },
            //3x3 bend
            { 14, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-40f,4f, 32f), new Vector3(0, -90f, 0), ConnectionType.Curve) },
            //4x4 bend (open top)
            { 15, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-56f,4f, 48f), new Vector3(0, -90f, 0), ConnectionType.Curve) },
            //Sbends
            { 1189, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-16f,4f,24f), Vector3.zero, ConnectionType.Shift) },
            { 1190, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-16f,4f,40f), Vector3.zero, ConnectionType.Shift) },
            { 1191, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-16f,4f,56f), Vector3.zero, ConnectionType.Shift) },

            //Folder 107
            { 1, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,8f), Vector3.zero) },
            { 1363, new BlockConnectionPoints( new Vector3(0,20f,8f), new Vector3(0,180f,0), new Vector3(0,4f,-8f), new Vector3(0,180f,0)) },
            { 2, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,8f), Vector3.zero) },
            { 1273, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,8f), Vector3.zero) },
            { 1274, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,8f), Vector3.zero) },
            { 22, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,8f), Vector3.zero) },
            { 372, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,8f), Vector3.zero) },
            { 373, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,8f), Vector3.zero) },
            { 1275, new BlockConnectionPoints( new Vector3(0,8f,0), Vector3.zero, new Vector3(0,8f,0), Vector3.zero) },
            { 1276, new BlockConnectionPoints( new Vector3(0,8f,0), Vector3.zero, new Vector3(0,8f,0), Vector3.zero) },
            { 1277, new BlockConnectionPoints( new Vector3(0,8f,0), Vector3.zero, new Vector3(0,8f,0), Vector3.zero) },
            { 1278, new BlockConnectionPoints( new Vector3(0,8f,0), Vector3.zero, new Vector3(0,8f,0), Vector3.zero) },
            { 1279, new BlockConnectionPoints( new Vector3(0,8f,0), Vector3.zero, new Vector3(0,8f,0), Vector3.zero) },
            //{ 1615, new BlockConnectionPoints( new Vector3(0,8f,0), Vector3.zero, new Vector3(0,8f,0), Vector3.zero) }, CreateRCTBlock Nullreference exception
            //{ 1616, new BlockConnectionPoints( new Vector3(0,8f,0), Vector3.zero, new Vector3(0,8f,0), Vector3.zero) },
            { 2256, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,8f), Vector3.zero) },
            { 2259, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,8f), Vector3.zero) },

            //Folder 108
            { 69, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,8f), Vector3.zero) },
            { 1545, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,8f), Vector3.zero) },
            { 290, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,8f), Vector3.zero) },
            { 72, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,8f), Vector3.zero) },
            { 73, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,8f), Vector3.zero) },
            { 2280, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,8f), Vector3.zero) },

            //Folder 108-1
            //{ 1746, new BlockConnectionPoints( Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero) }, CreateRCTBlock Nullreference exception
            //{ 1609, new BlockConnectionPoints( Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero) },
            //{ 1610, new BlockConnectionPoints( Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero) },
            //{ 1613, new BlockConnectionPoints( Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero) },
            //{ 1614, new BlockConnectionPoints( Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero) },
            //{ 1979, new BlockConnectionPoints( Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero) },
            //{ 1981, new BlockConnectionPoints( Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero) },
            //{ 1983, new BlockConnectionPoints( Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero) },
            //{ 1985, new BlockConnectionPoints( Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero) },
            //{ 2279, new BlockConnectionPoints( Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero) },
            //{ 2284, new BlockConnectionPoints( Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero) },

            //Folder 108-2
            { 1607, new BlockConnectionPoints( new Vector3(0,8f,0), Vector3.zero, new Vector3(0,8f,0), Vector3.zero) },
            { 1608, new BlockConnectionPoints( new Vector3(0,8f,0), Vector3.zero, new Vector3(0,8f,0), Vector3.zero) },
            { 1611, new BlockConnectionPoints( new Vector3(0,8f,0), Vector3.zero, new Vector3(0,8f,0), Vector3.zero) },
            { 1612, new BlockConnectionPoints( new Vector3(0,8f,0), Vector3.zero, new Vector3(0,8f,0), Vector3.zero) },
            { 1978, new BlockConnectionPoints( new Vector3(0,8f,0), Vector3.zero, new Vector3(0,8f,0), Vector3.zero) },
            { 1980, new BlockConnectionPoints( new Vector3(0,8f,0), Vector3.zero, new Vector3(0,8f,0), Vector3.zero) },
            { 1982, new BlockConnectionPoints( new Vector3(0,8f,0), Vector3.zero, new Vector3(0,8f,0), Vector3.zero) },
            { 1984, new BlockConnectionPoints( new Vector3(0,8f,0), Vector3.zero, new Vector3(0,8f,0), Vector3.zero) },

            //Folder 108-3
            { 1986, new BlockConnectionPoints( new Vector3(0,8f,0), Vector3.zero, new Vector3(0,8f,0), Vector3.zero) },
            { 1987, new BlockConnectionPoints( new Vector3(0,8f,0), Vector3.zero, new Vector3(0,8f,0), Vector3.zero) },
            { 1988, new BlockConnectionPoints( new Vector3(0,8f,0), Vector3.zero, new Vector3(0,8f,0), Vector3.zero) },
            { 1989, new BlockConnectionPoints( new Vector3(0,8f,0), Vector3.zero, new Vector3(0,8f,0), Vector3.zero) },
            { 1990, new BlockConnectionPoints( new Vector3(0,8f,0), Vector3.zero, new Vector3(0,8f,0), Vector3.zero) },
            { 1991, new BlockConnectionPoints( new Vector3(0,8f,0), Vector3.zero, new Vector3(0,8f,0), Vector3.zero) },
            { 1992, new BlockConnectionPoints( new Vector3(0,8f,0), Vector3.zero, new Vector3(0,8f,0), Vector3.zero) },
            { 1993, new BlockConnectionPoints( new Vector3(0,8f,0), Vector3.zero, new Vector3(0,8f,0), Vector3.zero) },

            //Folder 104 (OK)
            { 7, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,8f), Vector3.zero) },
            { 5, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,24f), Vector3.zero) },
            { 6, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,40f), Vector3.zero) },
            { 1255, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,56f), Vector3.zero) },
            { 8, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,20f,24f), Vector3.zero) },
            { 9, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,20f,24f), Vector3.zero) },
            { 12, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,8f), Vector3.zero) },
            { 13, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,8f), Vector3.zero) },
            { 10, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,20f,8f), Vector3.zero) },
            { 28, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,28f,24f), Vector3.zero) },
            { 29, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,28f,24f), Vector3.zero) },
            { 26, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,24f), Vector3.zero) },
            { 25, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,24f), Vector3.zero) },
            { 27, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,8f), Vector3.zero) },
            { 1126, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,20f,40f), Vector3.zero) },
            { 1125, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,20f,40f), Vector3.zero) },
            { 1124, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,40f), Vector3.zero) },
            { 1123, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,40f), Vector3.zero) },
            { 1120, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,24f), Vector3.zero) },
            { 1121, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,40f), Vector3.zero) },
            { 1122, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,56f), Vector3.zero) },

            //Folder 104-1
            { 86, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-24f, -4f, 16f), new Vector3(0, -90f, 0), ConnectionType.Curve) },
            { 87, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-40f, -4f, 32f), new Vector3(0, -90f, 0), ConnectionType.Curve) },
            { 88, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-56f, -4f, 48f), new Vector3(0, -90f, 0), ConnectionType.Curve) },

            { 1155, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-16f,12f,24f), Vector3.zero, ConnectionType.Shift) },
            { 1156, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-16f,12f,40f), Vector3.zero, ConnectionType.Shift) },
            { 1157, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-16f,12f,56f), Vector3.zero, ConnectionType.Shift) },

            { 2235, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-24f, 36f, 16f), new Vector3(0, -90f, 0), ConnectionType.Curve) },
            { 2236, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-40f, 52f, 32f), new Vector3(0, -90f, 0), ConnectionType.Curve) },
            { 2237, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-56f, 84f, 48f), new Vector3(0, -90f, 0), ConnectionType.Curve) },

            { 2238, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-24f, 20f, 16f), new Vector3(0, -90f, 0), ConnectionType.Curve) },
            { 2239, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-40f, 28f, 32f), new Vector3(0, -90f, 0), ConnectionType.Curve) },
            { 2240, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-56f, 36f, 48f), new Vector3(0, -90f, 0), ConnectionType.Curve) },

            //Folder 103
            { 30, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,8f), Vector3.zero) },
            { 31, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,24f), Vector3.zero) },
            { 32, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,40f), Vector3.zero) },
            { 33, new BlockConnectionPoints( new Vector3(0,12f,-8f), Vector3.zero, new Vector3(0,4f,8f), Vector3.zero) },
            { 34, new BlockConnectionPoints( new Vector3(0,12f,-8f), Vector3.zero, new Vector3(0,4f,24f), Vector3.zero) },
            { 35, new BlockConnectionPoints( new Vector3(0,12f,-8f), Vector3.zero, new Vector3(0,4f,40f), Vector3.zero) },
            { 36, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-8f,4f,0f), new Vector3(0,-90f,0), ConnectionType.Curve) },
            { 37, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-24f,4f,16f), new Vector3(0,-90f,0), ConnectionType.Curve) },
            { 38, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-40f,4f,32f), new Vector3(0,-90f,0), ConnectionType.Curve) },
            { 39, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-56f,4f,48f), new Vector3(0,-90f,0), ConnectionType.Curve) },
            { 161, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,8f), Vector3.zero) },
            { 1697, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(24f,4f,16f), new Vector3(0,90f,0), ConnectionType.Curve) },
            { 1698, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(40f,4f,32f), new Vector3(0,90f,0), ConnectionType.Curve) },
            { 1699, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(56f,4f,48f), new Vector3(0,90f,0), ConnectionType.Curve) },
            { 2254, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,20f,40f), Vector3.zero) },
            { 2255, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,20f,24f), Vector3.zero) },

            //Folder 103-1
            { 1147, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-8f,4f,0f), new Vector3(0,-90f,0), ConnectionType.Curve) },
            { 1148, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(24f,12f,16f), new Vector3(0,90f,0), ConnectionType.Curve) },
            { 1149, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(40f,20f,16f), new Vector3(0,90f,0), ConnectionType.Curve) },
            { 1150, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-8f,4f,0f), new Vector3(0,-90f,0), ConnectionType.Curve) },
            { 1151, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(24f,20f,16f), new Vector3(0,90f,0), ConnectionType.Curve) },
            { 1152, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(40f,28f,32f), new Vector3(0,90f,0), ConnectionType.Curve) },
            { 1703, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-24f,4f,16f), new Vector3(0,-90f,0), ConnectionType.Curve) },
            { 1704, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-40f,4f,32f), new Vector3(0,-90f,0), ConnectionType.Curve) },
            { 1705, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-56f,4f,48f), new Vector3(0,-90f,0), ConnectionType.Curve) },
            { 1706, new BlockConnectionPoints( new Vector3(0,12f,-8f), Vector3.zero, new Vector3(-24f,4f,16f), new Vector3(0,-90f,0), ConnectionType.Curve) },
            { 1707, new BlockConnectionPoints( new Vector3(0,12f,-8f), Vector3.zero, new Vector3(-40f,4f,32f), new Vector3(0,-90f,0), ConnectionType.Curve) },
            { 1708, new BlockConnectionPoints( new Vector3(0,12f,-8f), Vector3.zero, new Vector3(-56f,4f,48f), new Vector3(0,-90f,0), ConnectionType.Curve) },
            { 2241, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-24f,12f,16f), new Vector3(0,-90f,0), ConnectionType.Curve) },
            { 2242, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-40f,20f,32f), new Vector3(0,-90f,0), ConnectionType.Curve) },
            { 2243, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-56f,28f,48f), new Vector3(0,-90f,0), ConnectionType.Curve) },

            //Folder 103-2
            { 162, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,24f), Vector3.zero) },
            { 163, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,40f), Vector3.zero) },
            { 1154, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,56f), Vector3.zero) },
            { 164, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-16f,4f,24f), Vector3.zero, ConnectionType.Shift) },
            { 165, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-16f,4f,40f), Vector3.zero, ConnectionType.Shift) },
            { 1153, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-16f,4f,56f), Vector3.zero, ConnectionType.Shift) },

            //Folder 105
            { 89, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-24f,-4f,16f), new Vector3(0, -90f, 0), ConnectionType.Curve) },
            { 90, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-40f,-4f,32f), new Vector3(0, -90f, 0), ConnectionType.Curve) },
            { 91, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-56f,-4f,48f), new Vector3(0, -90f, 0), ConnectionType.Curve) },
            { 1204, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,40f), Vector3.zero) },
            { 1205, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,40f), Vector3.zero) },
            { 1195, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,24f), Vector3.zero) },
            { 1196, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,40f), Vector3.zero) },
            { 1197, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,56f), Vector3.zero) },
            { 1198, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,24f), Vector3.zero) },
            { 1199, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,40f), Vector3.zero) },
            { 1200, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,56f), Vector3.zero) },
            { 1201, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-16,12f,24f), Vector3.zero, ConnectionType.Shift) },
            { 1202, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-16,12f,40f), Vector3.zero, ConnectionType.Shift) },
            { 1203, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-16,12f,56f), Vector3.zero, ConnectionType.Shift) },
            { 1700, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(24f,12f,16f), new Vector3(0, 90f, 0), ConnectionType.Curve) },
            { 1701, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(40f,12f,32f), new Vector3(0, 90f, 0), ConnectionType.Curve) },
            { 1702, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(56f,12f,48f), new Vector3(0, 90f, 0), ConnectionType.Curve) },

            //Folder 111
            { 313, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,8f), Vector3.zero) },
            { 351, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,24f), Vector3.zero) },
            { 352, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,40f), Vector3.zero) },
            { 314, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,8f), Vector3.zero) },
            { 315, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-8f, 4f, 0), new Vector3(0, -90f, 0), ConnectionType.Curve) },
            { 316, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-24f, 4f, 16f), new Vector3(0, -90f, 0), ConnectionType.Curve) },
            { 317, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-40f, 4f, 32f), new Vector3(0, -90f, 0), ConnectionType.Curve) },
            { 318, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-56f, 4f, 48f), new Vector3(0, -90f, 0), ConnectionType.Curve) },

            //Folder 112
            { 324, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,8f), Vector3.zero) },
            { 322, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,24f), Vector3.zero) },
            { 323, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,40f), Vector3.zero) },
            { 325, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,20f,24f), Vector3.zero) },
            { 326, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,20f,24f), Vector3.zero) },
            { 328, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,8f), Vector3.zero) },
            { 329, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,8f), Vector3.zero) },
            { 327, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,20f,8f), Vector3.zero) },
            { 333, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,28f,24f), Vector3.zero) },
            { 334, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,28f,24f), Vector3.zero) },
            { 331, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,24f), Vector3.zero) },
            { 330, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,24f), Vector3.zero) },
            { 332, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,8f), Vector3.zero) },
            { 1223, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,20f,40f), Vector3.zero) },
            { 1224, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,20f,40f), Vector3.zero) },
            { 1222, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,40f), Vector3.zero) },
            { 1221, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,40f), Vector3.zero) },
            { 1218, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,24f), Vector3.zero) },
            { 1219, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,40f), Vector3.zero) },
            { 1220, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,56f), Vector3.zero) },
            { 319, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-24f,-4f,16f), new Vector3(0, -90f, 0), ConnectionType.Curve) },
            { 320, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-40f,-4f,32f), new Vector3(0, -90f, 0), ConnectionType.Curve) },
            { 321, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-56f,-4f,48f), new Vector3(0, -90f, 0), ConnectionType.Curve) },

            //Folder 109
             { 291, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,8f), Vector3.zero) },
             { 349, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,24f), Vector3.zero) },
             { 350, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,40f), Vector3.zero) },
             { 292, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,8f), Vector3.zero) },
             { 293, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-8f,4f,0), new Vector3(0, -90f, 0), ConnectionType.Curve) },
             { 294, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-24f,4f,16f), new Vector3(0, -90f, 0), ConnectionType.Curve) },
             { 295, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-40f,4f,32f), new Vector3(0, -90f, 0), ConnectionType.Curve) },
             { 296, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-56f,4f,48f), new Vector3(0, -90f, 0), ConnectionType.Curve) },

            //Folder 110
            { 302, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,8f), Vector3.zero) },
            { 300, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,24f), Vector3.zero) },
            { 301, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,40f), Vector3.zero) },
            { 303, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,20f,24f), Vector3.zero) },
            { 304, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,20f,24f), Vector3.zero) },
            { 306, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,8f), Vector3.zero) },
            { 307, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,8f), Vector3.zero) },
            { 305, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,20f,8f), Vector3.zero) },
            { 311, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,28f,24f), Vector3.zero) },
            { 312, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,28f,24f), Vector3.zero) },
            { 309, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,24f), Vector3.zero) },
            { 308, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,24f), Vector3.zero) },
            { 310, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,8f), Vector3.zero) },
            { 1230, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,20f,40f), Vector3.zero) },
            { 1231, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,20f,40f), Vector3.zero) },
            { 1229, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,40f), Vector3.zero) },
            { 1228, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,40f), Vector3.zero) },
            { 1225, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,24f), Vector3.zero) },
            { 1226, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,40f), Vector3.zero) },
            { 1227, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,56f), Vector3.zero) },
            { 297, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-24f,-4f,16f), new Vector3(0, -90f, 0), ConnectionType.Curve) },
            { 298, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-40f,-4f,32f), new Vector3(0, -90f, 0), ConnectionType.Curve) },
            { 299, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-56f,-4f,48f), new Vector3(0, -90f, 0), ConnectionType.Curve) },

            //Folder 102
             { 75, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,-4f,40f), Vector3.zero) },
             { 76, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,-4f,8f), Vector3.zero) },
             { 77, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,-4f,24f), Vector3.zero) },
             { 78, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-24f,-4f,16f), new Vector3(0, -90f, 0), ConnectionType.Curve) },
             { 79, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(16f,-4f,40f), Vector3.zero) },
             { 80, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-40f,-4f,32f), new Vector3(0, -90f, 0), ConnectionType.Curve) },
             { 81, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-8f,4f,0f), new Vector3(0, -90f, 0), ConnectionType.Curve) },
             { 82, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,8f), Vector3.zero) },
             { 83, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,-4f,40f), Vector3.zero) },
             { 84, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,-4f,40f), Vector3.zero) },
             { 1556, new BlockConnectionPoints( new Vector3(0,4f,7.2f), Vector3.zero, new Vector3(0,4f,8.8f), Vector3.zero) },

             //Folder 106
             //Folder 101 (OK)
            { 167, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,8f), Vector3.zero) },
            { 168, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,24f), Vector3.zero) },
            { 169, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-24f,4f, 16f), new Vector3(0, -90f, 0), ConnectionType.Curve) },
            { 170, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-40f,4f, 32f), new Vector3(0, -90f, 0), ConnectionType.Curve) },
            { 171, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-56f,4f, 48f), new Vector3(0, -90f, 0), ConnectionType.Curve) },

            //Folder 105-1
            { 1206, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,24f), Vector3.zero) },
            { 1207, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,24f), Vector3.zero) },
            { 1208, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,24f), Vector3.zero) },
            { 1209, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,20f,24f), Vector3.zero) },
            { 1210, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,40f), Vector3.zero) },
            { 1211, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,40f), Vector3.zero) },
            { 1212, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,40f), Vector3.zero) },
            { 1213, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,20f,40f), Vector3.zero) },
            { 1214, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,56f), Vector3.zero) },
            { 1215, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,56f), Vector3.zero) },
            { 1216, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,56f), Vector3.zero) },
            { 1217, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,20f,56f), Vector3.zero) },


            //Folder 113
            { 1542, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,0), Vector3.zero) },
            { 1557, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,8f), Vector3.zero) },
            { 1558, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-8f,4f,8f), Vector3.zero, ConnectionType.Shift) },
            { 1559, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-8f,4f,24f), Vector3.zero, ConnectionType.Shift) },
            { 1560, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-8f,4f,0f), new Vector3(0, -90f, 0), ConnectionType.Curve) },
            { 1561, new BlockConnectionPoints( new Vector3(0,4f,-4f), Vector3.zero, new Vector3(0,4f,4f), Vector3.zero) },
            { 1562, new BlockConnectionPoints( new Vector3(0,4f,-6f), new Vector3(0,15f,0), new Vector3(0,4f,6f), new Vector3(0,-15f,0), ConnectionType.Curve) },
            { 1563, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,8f), Vector3.zero) },
            { 1564, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-8f,4f,24f), Vector3.zero, ConnectionType.Shift) },
            { 1565, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-0.8507652f,4f,1.724298f), new Vector3(0,-10f,0), ConnectionType.Curve) },
            { 1566, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-1.362965f,4f,2.352763f), new Vector3(0,-15f,0), ConnectionType.Curve) },
            { 1567, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-3.215391f,4f,4f), new Vector3(0,-30f,0), ConnectionType.Curve) },
            { 1568, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-2.343145f,4f,-2.343145f), new Vector3(0,-45f,0), ConnectionType.Curve) },
            { 2251, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,0,40f), Vector3.zero) },
            { 2252, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,8f,40f), Vector3.zero) },

            //Folder 114
            { 131, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,40f), Vector3.zero) },
            { 160, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,24f), Vector3.zero) },
            { 1280, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,8f), Vector3.zero) },
            { 1281, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,24f), Vector3.zero) },
            { 1282, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,40f), Vector3.zero) },

            //Folder 115
            { 1622, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,24f), Vector3.zero) },
            { 1623, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,40f), Vector3.zero) },
            { 1624, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,56f), Vector3.zero) },
            { 1628, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-8f,4f,8f), new Vector3(0,-90f,0), ConnectionType.Curve) },
            { 1629, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-8f,4f,16f), new Vector3(0,-90f,0), ConnectionType.Curve) },
            { 1630, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-8f,4f,24f), new Vector3(0,-90f,0), ConnectionType.Curve) },
            { 1631, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-8f,4f,8f), new Vector3(0,-90f,0), ConnectionType.Curve) },
            { 1632, new BlockConnectionPoints( new Vector3(8f,4f,8f), new Vector3(0,-90f,0), new Vector3(0,12f,24f), Vector3.zero, ConnectionType.Curve) },
            { 1633, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-8f,4f,16f), new Vector3(0,-90f,0), ConnectionType.Curve) },
            { 1634, new BlockConnectionPoints( new Vector3(8f,4f,16f), new Vector3(0,-90f,0), new Vector3(0,12f,40f), Vector3.zero, ConnectionType.Curve) },
            { 1635, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-8f,4f,24f), new Vector3(0,-90f,0), ConnectionType.Curve) },
            { 1636, new BlockConnectionPoints( new Vector3(8f,4f,24f), new Vector3(0,-90f,0), new Vector3(0,12f,56f), Vector3.zero, ConnectionType.Curve) },

            //Folder 116
            { 1680, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,8f), Vector3.zero) },
            { 1682, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,8f), Vector3.zero) },
            { 1683, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,5.6f,8f), Vector3.zero) },
            { 1684, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4.8f,8f), Vector3.zero) },
            { 1681, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4.8f,0f), Vector3.zero) },
            { 1685, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4.8f,0f), Vector3.zero) },
            { 1686, new BlockConnectionPoints( new Vector3(0,4.8f,-8f), Vector3.zero, new Vector3(0,4.8f,8f), Vector3.zero) },
            { 1687, new BlockConnectionPoints( new Vector3(0,4.8f,-8f), Vector3.zero, new Vector3(0,4.8f,0f), Vector3.zero) },
            { 1688, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4.8f,8f), Vector3.zero) },
            { 1689, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,5.6f,8f), Vector3.zero) },
            { 2278, new BlockConnectionPoints( new Vector3(0,4f,0f), Vector3.zero, new Vector3(0,4f,8f), Vector3.zero) },
            { 1500, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,8f), Vector3.zero) },
            { 223, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,8f), Vector3.zero) },
            { 224, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-24f,4f,16f), new Vector3(0,-90f,0), ConnectionType.Curve) },
            { 225, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-40f,4f,32f), new Vector3(0,-90f,0), ConnectionType.Curve) },

            //CHOO CHOO TIME
            //Folder 1400
            { 1637, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,8f), Vector3.zero) },
            { 1638, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,24f), Vector3.zero) },
            { 1639, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,40f), Vector3.zero) },
            { 1640, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,56f), Vector3.zero) },
            { 1641, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-24f,4f,16f), new Vector3(0,-90f,0), ConnectionType.Curve) },
            { 1642, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-40f,4f,32f), new Vector3(0,-90f,0), ConnectionType.Curve) },
            { 1643, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-56f,4f,48f), new Vector3(0,-90f,0), ConnectionType.Curve) },
            { 1645, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-16f,4f,40f), Vector3.zero, ConnectionType.Shift) },
            { 1646, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-16f,4f,56f), Vector3.zero, ConnectionType.Shift) },
            { 1648, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,40f), Vector3.zero) },
            { 1649, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,56f), Vector3.zero) },
            { 1650, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,24f), Vector3.zero) },
            { 1651, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,24f), Vector3.zero) },
            { 1652, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,8f), Vector3.zero) },
            { 1693, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,0f), Vector3.zero) },
            
            //Folder 1401
             { 1666, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,8f), Vector3.zero) },
             { 1690, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,40f), Vector3.zero) },
             { 1691, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,8f), Vector3.zero) },
             { 1692, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,24f), Vector3.zero) },
             { 1694, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,0), Vector3.zero) },
             { 1695, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-40f,4f,32f), new Vector3(0,-90f,0), ConnectionType.Curve) },
             { 1696, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-56f,4f,48f), new Vector3(0,-90f,0), ConnectionType.Curve) },
             { 1644, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0f,56f,44f), new Vector3(-90f,0,0)) },
             { 1647, new BlockConnectionPoints( new Vector3(0,0,-4f), new Vector3(-90f,0,0), new Vector3(0f,60f,56f), Vector3.zero) },
             { 2263, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,8f), Vector3.zero) },
             
             //Folder 1402
             { 1668, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,8f), Vector3.zero) },
             { 1677, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,8f), Vector3.zero) },
             { 1678, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,8f), Vector3.zero) },

            //Halfpipes
            //Folder 302
            { 20, new BlockConnectionPoints( new Vector3(8f, 4f, 0), new Vector3(0,-90f,0), new Vector3(-8f,4f,0), new Vector3(0,-90f,0)) },
            { 392, new BlockConnectionPoints( new Vector3(8f, 4f, 0), new Vector3(0,-90f,0), new Vector3(-24f,4f,0), new Vector3(0,-90f,0)) },
            { 24, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-8f,4f,0), new Vector3(0,-90f,0), ConnectionType.Curve) },
            { 50, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-24f,4f,16f), new Vector3(0,-90f,0), ConnectionType.Curve) },
            { 385, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-40f,4f,32f), new Vector3(0,-90f,0), ConnectionType.Curve) },
            { 386, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-56f,4f,48f), new Vector3(0,-90f,0), ConnectionType.Curve) },
            { 391, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-40f,4f,32f), new Vector3(0,-90f,0), ConnectionType.Curve) },
            { 45, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-24f,4f,16f), new Vector3(0,-90f,0), ConnectionType.Curve) },
            { 46, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-40f,4f,32f), new Vector3(0,-90f,0), ConnectionType.Curve) },
            { 16, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,28f,0), new Vector3(-90f,0,0)) },
            { 1127, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,20f,0), new Vector3(-90f,0,0)) },
            { 1128, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,20f,16f), new Vector3(-90f,0,0)) },
            { 1129, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,20f,32f), new Vector3(-90f,0,0)) },
            { 387, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(8f,4f,0), new Vector3(0,90f,0), ConnectionType.Curve) },
            { 388, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(24f,4f,16f), new Vector3(0,90f,0), ConnectionType.Curve) },
            { 389, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(40f,4f,32f), new Vector3(0,90f,0), ConnectionType.Curve) },
            { 390, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(56f,4f,48f), new Vector3(0,90f,0), ConnectionType.Curve) },
            { 1373, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,56f), Vector3.zero) },
            { 1374, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(16f,20f,56f), Vector3.zero, ConnectionType.Shift) },
            { 2260, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-16f,4f,40f), Vector3.zero, ConnectionType.Shift) },
            { 2261, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,40f), Vector3.zero) },
            { 2262, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,40f), Vector3.zero) },

            //Folder 301
            { 1130, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-40f,-4f,32f), new Vector3(0,-90f,0), ConnectionType.Curve) },
            { 1131, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-56f,-4f,48f), new Vector3(0,-90f,0), ConnectionType.Curve) },
            { 1132, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,20f,8f), Vector3.zero) },
            { 1133, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,8f), Vector3.zero) },
            { 1134, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,24f), Vector3.zero) },
            { 1135, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,40f), Vector3.zero) },
            { 1136, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,56f), Vector3.zero) },
            //{ 1137, new BlockConnectionPoints( new Vector3(8f,4f,0), new Vector3(0,-90f,0), new Vector3(0,-4f,0f), new Vector3(0,0,90f)) }, //needs a new Sideways case or something
            { 1171, new BlockConnectionPoints( new Vector3(0,20f,-8f), Vector3.zero, new Vector3(-8f,4f,0f), new Vector3(0,-90f,0), ConnectionType.Curve) },
            { 1172, new BlockConnectionPoints( new Vector3(0,12f,-8f), Vector3.zero, new Vector3(-8f,4f,0f), new Vector3(0,-90f,0), ConnectionType.Curve) },
            { 1173, new BlockConnectionPoints( new Vector3(0,12f,-8f), Vector3.zero, new Vector3(-24f,4f,16f), new Vector3(0,-90f,0), ConnectionType.Curve) },
            { 1174, new BlockConnectionPoints( new Vector3(0,12f,-8f), Vector3.zero, new Vector3(-40f,4f,32f), new Vector3(0,-90f,0), ConnectionType.Curve) },
            { 1175, new BlockConnectionPoints( new Vector3(0,12f,-8f), Vector3.zero, new Vector3(-56f,4f,48f), new Vector3(0,-90f,0), ConnectionType.Curve) },
            { 1192, new BlockConnectionPoints( new Vector3(8f, 4f, 0), new Vector3(0,-90f,0), new Vector3(-24f,-4f,0), new Vector3(0,-90f,0)) },
            { 1193, new BlockConnectionPoints( new Vector3(8f, 4f, 0), new Vector3(0,-90f,0), new Vector3(-40f,-4f,0), new Vector3(0,-90f,0)) },
            { 1194, new BlockConnectionPoints( new Vector3(8f, 4f, 0), new Vector3(0,-90f,0), new Vector3(-56f,-4f,0), new Vector3(0,-90f,0)) },

            //Folder 303
            { 1330, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,0f), new Vector3(-90f, 0, 0)) },
            { 1331, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,28f,16f), new Vector3(-90f, 0, 0)) },
            { 1332, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,44f,32f), new Vector3(-90f, 0, 0)) },
            { 1333, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,60f,48f), new Vector3(-90f, 0, 0)) },
            { 1334, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-8f,12f,0f), new Vector3(-90f, 0, 0), ConnectionType.Shift) },
            { 1335, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-8f,28f,16f), new Vector3(-90f, 0, 0), ConnectionType.Shift) },
            { 1336, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-8f,44f,32f), new Vector3(-90f, 0, 0), ConnectionType.Shift) },
            { 1337, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-8f,60f,48f), new Vector3(-90f, 0, 0), ConnectionType.Shift) },
            { 2229, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,40f), Vector3.zero) },
            { 2230, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,40f), Vector3.zero) },
            { 2231, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,-20f,40f), Vector3.zero) },
            { 2232, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,-28f,40f), Vector3.zero) },
            { 2233, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,40f), Vector3.zero) },
            { 2234, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,40f), Vector3.zero) },

            //Folder 304
            { 2191, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-24f,4f,16f), new Vector3(0,-90f,0), ConnectionType.Curve) },
            { 2192, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-40f,4f,32f), new Vector3(0,-90f,0), ConnectionType.Curve) },
            { 2193, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-56f,4f,48f), new Vector3(0,-90f,0), ConnectionType.Curve) },
            { 2194, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-24f,12f,16f), new Vector3(0,-90f,0), ConnectionType.Curve) },
            { 2195, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-40f,20f,32f), new Vector3(0,-90f,0), ConnectionType.Curve) },
            { 2196, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-56f,28f,48f), new Vector3(0,-90f,0), ConnectionType.Curve) },
            { 2197, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-24f,4f,16f), new Vector3(0,-90f,0), ConnectionType.Curve) },
            { 2198, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-40f,4f,32f), new Vector3(0,-90f,0), ConnectionType.Curve) },
            { 2199, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-56f,4f,48f), new Vector3(0,-90f,0), ConnectionType.Curve) },

            { 2200, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-24f,12f,16f), new Vector3(0,-90f,0), ConnectionType.Curve) },
            { 2201, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-40f,20f,32f), new Vector3(0,-90f,0), ConnectionType.Curve) },
            { 2202, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-56f,28f,48f), new Vector3(0,-90f,0), ConnectionType.Curve) },

            { 2205, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-24f,12f,16f), new Vector3(0,-90f,0), ConnectionType.Curve) },
            { 2206, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-40f,20f,32f), new Vector3(0,-90f,0), ConnectionType.Curve) },
            { 2207, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-56f,28f,48f), new Vector3(0,-90f,0), ConnectionType.Curve) },

            { 2208, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-24f,20f,0f), new Vector3(0,-90f,0), ConnectionType.Curve) },
            { 2209, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-40f,36f,16f), new Vector3(0,-90f,0), ConnectionType.Curve) },
            { 2210, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-56f,52f,32f), new Vector3(0,-90f,0), ConnectionType.Curve) },

            { 2226, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-24f,-4f,16f), new Vector3(0,-90f,0), ConnectionType.Curve) },
            { 2227, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-40f,4f,32f), new Vector3(0,-90f,0), ConnectionType.Curve) },
            { 2228, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-56f,12f,48f), new Vector3(0,-90f,0), ConnectionType.Curve) },

            //Folder 300
            { 377, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-8f,4f, 0f), new Vector3(0, -90f, 0), ConnectionType.Curve) },
            { 378, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-24f,4f, 16f), new Vector3(0, -90f, 0), ConnectionType.Curve) },
            { 379, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-40f,4f, 32f), new Vector3(0, -90f, 0), ConnectionType.Curve) },
            { 380, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-56f,4f, 48f), new Vector3(0, -90f, 0), ConnectionType.Curve) },

            { 381, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(8f,4f,0), new Vector3(0, 90f, 0), ConnectionType.Curve) },
            { 382, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(24f,4f,16f), new Vector3(0, 90f, 0), ConnectionType.Curve) },
            { 383, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(40f,4f,32f), new Vector3(0, 90f, 0), ConnectionType.Curve) },
            { 384, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(56f,4f,48f), new Vector3(0, 90f, 0), ConnectionType.Curve) }
            #endregion
        };

        public static BlockConnectionPoints GetBlockConnectionPoints(int blockID)
        {
            if (connectionData.ContainsKey(blockID))
            {
                return connectionData[blockID];
            }

            return new BlockConnectionPoints();
        }

        public static bool Supports(int blockID)
        {
            return connectionData.ContainsKey(blockID);
        }
    }
}
