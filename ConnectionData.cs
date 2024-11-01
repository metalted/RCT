using System.Collections.Generic;
using UnityEngine;

namespace RCT
{
    public static class ConnectionData
    {
        private static Dictionary<int, BlockConnectionPoints> connectionData = new Dictionary<int, BlockConnectionPoints>()
        {
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

            //Barrel roll
            { 248, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,40f), Vector3.zero) },

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
            //{ 1549, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,24f), Vector3.zero) },
            //{ 1550, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,24f), Vector3.zero) },
            { 1551, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,56f), Vector3.zero) }
            //{ 1552, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,56f), Vector3.zero) }
            //{ 1553, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,24f), Vector3.zero) },
            //{ 1554, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,24f), Vector3.zero) }

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
