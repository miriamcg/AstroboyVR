using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Astroboy.Data
{
    [System.Serializable]
    public class PoolType
    {
        public string tag;
        public int capacity;
        public GameObject prefab;
    }
}
