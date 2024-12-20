﻿using UnityEngine;

namespace RCT
{
    public class BlockConnectionPoints
    {        
        public ConnectionData.ConnectionType connectionType;
        public Vector3 localStartPosition;
        public Vector3 localStartEuler;
        public Vector3 localEndPosition;
        public Vector3 localEndEuler;
        public bool valid = false;

        public BlockConnectionPoints() { }

        public BlockConnectionPoints(Vector3 _localStartPosition, Vector3 _localStartEuler, Vector3 _localEndPosition, Vector3 _localEndEuler, ConnectionData.ConnectionType _connectionType = ConnectionData.ConnectionType.Standard)
        {
            localStartPosition = _localStartPosition;
            localStartEuler = _localStartEuler;
            localEndPosition = _localEndPosition;
            localEndEuler = _localEndEuler;
            valid = true;
            connectionType = _connectionType;
        }
    }
}
