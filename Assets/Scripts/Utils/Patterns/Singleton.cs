using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Astroboy.Utils
{
    public abstract class Singleton<T> : MonoBehaviour
    {
        protected static T _instance;
        public static T Instance
        {
            get => _instance;
            protected set => _instance = value;
        }

        protected abstract void Awake();
    }
}
