using Astroboy.Data;
using System.Collections.Generic;
using UnityEngine;

namespace Astroboy.Utils
{
    public class PoolingObject : Singleton<PoolingObject>
    {
        [SerializeField]
        public Dictionary<string, Queue<GameObject>> poolDictionary;
        [SerializeField]
        public List<PoolType> pools;

        #region Singleton
        protected override void Awake()
        {
            if (_instance != null && _instance != this)
                Destroy(this.gameObject);
            else
                Instance = this;

        }
        #endregion Singleton

        private void Start()
        {
            poolDictionary = new Dictionary<string, Queue<GameObject>>();

            foreach (PoolType pool in pools)
            {
                Queue<GameObject> objectPool = new Queue<GameObject>();
                GameObject container = new GameObject();
                container.transform.SetParent(this.gameObject.transform);
                container.name = pool.tag;

                for (int i = 0; i < pool.capacity; i++)
                {
                    GameObject obj = Instantiate(pool.prefab);
                    obj.transform.SetParent(container.transform);
                    obj.SetActive(false);
                    objectPool.Enqueue(obj);
                }

                poolDictionary.Add(pool.tag, objectPool);
            }
        }

        public GameObject Spawn(string tag, Vector3 pos, Quaternion rot)
        {
            if (!poolDictionary.ContainsKey(tag))
            {
                Debug.LogError("This tag " + tag + " doesn't exist");
                return null;
            }

            GameObject obj = poolDictionary[tag].Dequeue();

            obj.SetActive(true);
            obj.transform.position = pos;
            obj.transform.rotation = rot;

            IPoolingObject pooledObj = obj.GetComponent<IPoolingObject>();

            if (pooledObj != null)
            {
                pooledObj.OnObjectSpawn();
            }

            poolDictionary[tag].Enqueue(obj);

            return obj;
        }

        public void ReturnPool(string tag, GameObject obj)
        {
            obj.SetActive(false);
            poolDictionary[tag].Enqueue(obj);
        }
    }
}
