﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace RCT
{
    public class RCTBlock : MonoBehaviour
    {
        public int blockID;
        public BlockConnectionPoints connectionPoints;
        public Transform start;
        public Transform end;

        public bool isReversed = false;
        public bool isFlipped = false;
        public float rotation = 0f;
    }
}
