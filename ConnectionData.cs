using System.Collections.Generic;
using UnityEngine;

namespace RCT
{
    public static class ConnectionData
    {
        private static Dictionary<int, BlockConnectionPoints> connectionData = new Dictionary<int, BlockConnectionPoints>()
        {
            #region Tubes
            //Single straight
            { 56, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,8f), Vector3.zero) },
            //1x1 bend
            { 58, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-8f,4f, 0f), new Vector3(0, -90f, 0)) },
            //2x2 bend
            { 59, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-24f,4f, 16f), new Vector3(0, -90f, 0)) },
            //3x3 bend
            { 60, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-40f,4f, 32f), new Vector3(0, -90f, 0)) },
            //4x4 bend (open top)
            { 116, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-56f,4f, 48f), new Vector3(0, -90f, 0)) },

            //Single straight (open top)
            { 227, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,8f), Vector3.zero) },
            //1x1 bend (open top)
            { 228, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-8f,4f, 0f), new Vector3(0, -90f, 0)) },
            //2x2 bend (open top)
            { 229, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-24f,4f, 16f), new Vector3(0, -90f, 0)) },
            //3x3 bend (open top)
            { 230, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-40f,4f, 32f), new Vector3(0, -90f, 0)) },
            //4x4 bend (open top)
            { 231, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-56f,4f, 48f), new Vector3(0, -90f, 0)) },

            //Single straight (open side)
            { 257, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,8f), Vector3.zero) },
            //1x1 bend (open side)
            { 258, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-8f,4f, 0f), new Vector3(0, -90f, 0)) },
            //2x2 bend (open side)
            { 259, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-24f,4f, 16f), new Vector3(0, -90f, 0)) },
            //3x3 bend (open side)
            { 260, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-40f,4f, 32f), new Vector3(0, -90f, 0)) },
            //4x4 bend (open side)
            { 261, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-56f,4f, 48f), new Vector3(0, -90f, 0)) },

            //Folder 201
            { 226, new BlockConnectionPoints( new Vector3(0,-4f,0), new Vector3(-90f, 0, 0), new Vector3(0,64f, 0), new Vector3(-90f, 0, 0)) },
            { 248, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,40f), Vector3.zero) },
            { 57, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,24f), Vector3.zero) },
            { 341, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,24f), Vector3.zero) },
            { 342, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,20f,24f), Vector3.zero) },
            { 343, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,40f), Vector3.zero) },
            { 344, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,24f), Vector3.zero) },
            { 345, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,20f,24f), Vector3.zero) },
            { 346, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-24f,4f,16f), new Vector3(0,-90f,0)) },
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
            { 2184, new BlockConnectionPoints( new Vector3(8f, 4f, 0), new Vector3(0,-90f,0), new Vector3(0,4f,8f), Vector3.zero) },
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
            { 1721, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-24f,4f,16f), new Vector3(0,-90f,0)) },
            { 1722, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-40f,4f,32f), new Vector3(0,-90f,0)) },
            { 1723, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-56f,4f,48f), new Vector3(0,-90f,0)) },
            { 1718, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-24f,4f,16f), new Vector3(0,-90f,0)) },
            { 1719, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-40f,4f,32f), new Vector3(0,-90f,0)) },
            { 1720, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-56f,4f,48f), new Vector3(0,-90f,0)) },
            { 1724, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-24f,-4f,16f), new Vector3(0,-90f,0)) },
            { 1725, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-40f,-4f,32f), new Vector3(0,-90f,0)) },
            { 1726, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-56f,-4f,48f), new Vector3(0,-90f,0)) },
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
             { 117, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-48f,-4f,-8f), new Vector3(0,180f,0)) },
             { 118, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-24f,-4f,16f), new Vector3(0,-90f,0)) },
             { 119, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-40f,-4f,32f), new Vector3(0,-90f,0)) },
             { 120, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-56f,-4f, 48f), new Vector3(0,-90f,0)) },
             { 121, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-24f,-12f,16f), new Vector3(0,-90f,0)) },
             { 122, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-40f,-20f,32f), new Vector3(0,-90f,0)) },
             { 123, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-56f,-28f, 48f), new Vector3(0,-90f,0)) },

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
             { 244, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-48f,-4f,-8f), new Vector3(0,180f,0)) },
             { 241, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-24f,-4f,16f), new Vector3(0,-90f,0)) },
             { 242, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-40f,-4f,32f), new Vector3(0,-90f,0)) },
             { 243, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-56f,-4f, 48f), new Vector3(0,-90f,0)) },
             { 245, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-24f,-12f,16f), new Vector3(0,-90f,0)) },
             { 246, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-40f,-20f,32f), new Vector3(0,-90f,0)) },
             { 247, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-56f,-28f, 48f), new Vector3(0,-90f,0)) },

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
             { 274, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-48f,-4f,-8f), new Vector3(0,180f,0)) },
             { 271, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-24f,-4f,16f), new Vector3(0,-90f,0)) },
             { 272, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-40f,-4f,32f), new Vector3(0,-90f,0)) },
             { 273, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-56f,-4f, 48f), new Vector3(0,-90f,0)) },
             { 275, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-24f,-12f,16f), new Vector3(0,-90f,0)) },
             { 276, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-40f,-20f,32f), new Vector3(0,-90f,0)) },
             { 277, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-56f,-28f, 48f), new Vector3(0,-90f,0)) },

            //Folder 209
            { 1547, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,8f), Vector3.zero) },
            { 1548, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,8f), Vector3.zero) },
            { 1549, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-8f,4f,0f), new Vector3(0,-90f,0)) },
            { 1550, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-8f,4f,0f), new Vector3(0,-90f,0)) },
            { 1551, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,40f), Vector3.zero) },
            { 1552, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,40f), Vector3.zero) },
            { 1553, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-24f,4f,16f), new Vector3(0,-90f,0)) },
            { 1554, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-24f,4f,16f), new Vector3(0,-90f,0)) },
            #endregion

            #region Roads
            //Folder 101
            { 0, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,8f), Vector3.zero) },
            //1x1 bend
            { 3, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-8f,4f, 0f), new Vector3(0, -90f, 0)) },
            //2x2 bend
            { 4, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-24f,4f, 16f), new Vector3(0, -90f, 0)) },
            //3x3 bend
            { 14, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-40f,4f, 32f), new Vector3(0, -90f, 0)) },
            //4x4 bend (open top)
            { 15, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-56f,4f, 48f), new Vector3(0, -90f, 0)) },
            //Sbends
            { 1189, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-16f,4f,24f), Vector3.zero) },
            { 1190, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-16f,4f,40f), Vector3.zero) },
            { 1191, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-16f,4f,56f), Vector3.zero) },

            //Folder 107
            { 1, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,8f), Vector3.zero) },
            { 1363, new BlockConnectionPoints( new Vector3(0,20f,8f), new Vector3(0,180f,0), new Vector3(0,4f,-8f), new Vector3(0,180f,0)) },
            { 2, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,8f), Vector3.zero) },
            { 1273, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,8f), Vector3.zero) },
            { 1274, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,8f), Vector3.zero) },
            { 22, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,8f), Vector3.zero) },
            { 372, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,8f), Vector3.zero) },
            { 373, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,8f), Vector3.zero) },
            { 1275, new BlockConnectionPoints( Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero) },
            { 1276, new BlockConnectionPoints( Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero) },
            { 1277, new BlockConnectionPoints( Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero) },
            { 1278, new BlockConnectionPoints( Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero) },
            { 1279, new BlockConnectionPoints( Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero) },
            { 1615, new BlockConnectionPoints( Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero) },
            { 1616, new BlockConnectionPoints( Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero) },
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
            { 1746, new BlockConnectionPoints( Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero) },
            { 1609, new BlockConnectionPoints( Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero) },
            { 1610, new BlockConnectionPoints( Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero) },
            { 1613, new BlockConnectionPoints( Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero) },
            { 1614, new BlockConnectionPoints( Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero) },
            { 1979, new BlockConnectionPoints( Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero) },
            { 1981, new BlockConnectionPoints( Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero) },
            { 1983, new BlockConnectionPoints( Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero) },
            { 1985, new BlockConnectionPoints( Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero) },
            { 2279, new BlockConnectionPoints( Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero) },
            { 2284, new BlockConnectionPoints( Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero) },

            //Folder 108-2
            { 1607, new BlockConnectionPoints( Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero) },
            { 1608, new BlockConnectionPoints( Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero) },
            { 1611, new BlockConnectionPoints( Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero) },
            { 1611, new BlockConnectionPoints( Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero) },
            { 1612, new BlockConnectionPoints( Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero) },
            { 1978, new BlockConnectionPoints( Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero) },
            { 1980, new BlockConnectionPoints( Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero) },
            { 1982, new BlockConnectionPoints( Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero) },
            { 1984, new BlockConnectionPoints( Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero) },

            //Folder 108-3
            { 1986, new BlockConnectionPoints( Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero) },
            { 1987, new BlockConnectionPoints( Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero) },
            { 1988, new BlockConnectionPoints( Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero) },
            { 1989, new BlockConnectionPoints( Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero) },
            { 1990, new BlockConnectionPoints( Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero) },
            { 1991, new BlockConnectionPoints( Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero) },
            { 1992, new BlockConnectionPoints( Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero) },
            { 1993, new BlockConnectionPoints( Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero) },

            //Folder 104
            { 7, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,8f), Vector3.zero) },
            { 5, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,24f), Vector3.zero) },
            { 6, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,40f), Vector3.zero) },
            { 1329, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,56f), Vector3.zero) },
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
            { 1125, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,40f), Vector3.zero) },
            { 1123, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,40f), Vector3.zero) },
            { 1120, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,24f), Vector3.zero) },
            { 1121, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,40f), Vector3.zero) },
            { 1122, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,56f), Vector3.zero) },

            //Folder 104-1
            { 86, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-24f, -4f, 16f), new Vector3(0, -90f, 0)) },
            { 87, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-40f, -4f, 32f), new Vector3(0, -90f, 0)) },
            { 88, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-56f, -4f, 48f), new Vector3(0, -90f, 0)) },

            { 1155, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-16f,4f,24f), Vector3.zero) },
            { 1156, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-16f,4f,40f), Vector3.zero) },
            { 1157, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-16f,4f,56f), Vector3.zero) },

            { 2235, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-24f, 36f, 16f), new Vector3(0, -90f, 0)) },
            { 2236, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-40f, 52f, 32f), new Vector3(0, -90f, 0)) },
            { 2237, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-56f, 84f, 48f), new Vector3(0, -90f, 0)) },

            { 2238, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-24f, 20f, 16f), new Vector3(0, -90f, 0)) },
            { 2239, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-40f, 28f, 32f), new Vector3(0, -90f, 0)) },
            { 2240, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-56f, 36f, 48f), new Vector3(0, -90f, 0)) },

            //Folder 113
            { 1542, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,0), Vector3.zero) },
            { 1557, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,0), Vector3.zero) },
            { 1558, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-8f,4f,8f), Vector3.zero) },
            { 1559, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-8f,4f,24f), Vector3.zero) },
            { 1560, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-8f,4f,0f), new Vector3(0, -90f, 0)) },
            { 1561, new BlockConnectionPoints( new Vector3(0,4f,-4f), Vector3.zero, new Vector3(0,4f,4f), Vector3.zero) },
            { 1562, new BlockConnectionPoints( new Vector3(0,4f,-6f), new Vector3(0,15f,0), new Vector3(0,4f,6f), new Vector3(0,-15f,0)) },
            { 1563, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,8f), Vector3.zero) },
            { 1564, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-8f,4f,24f), Vector3.zero) },
            { 1565, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,8f), Vector3.zero) }

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
