using Astroboy.Utils;
using System.Collections;
using UnityEngine;

namespace Astroboy.Player.Gun
{
    public class ImpactController : Singleton<ImpactController>
    {
        [Header("Params")]
        [SerializeField]
        private float timeImpact = 1f;

        private PoolingObject poolingObject;

        private const string impactTag = "Impact";

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
            poolingObject = PoolingObject.Instance;
        }

        public void ActivateImpact(Vector3 pos)
        {
            GameObject impact = poolingObject.Spawn(impactTag, pos, Quaternion.identity);
            StartCoroutine(WaitToDestroy(impact));
        }

        private IEnumerator WaitToDestroy(GameObject impact)
        {
            yield return new WaitForSeconds(timeImpact);
            poolingObject.ReturnPool(impactTag, impact);
        }
    }
}
