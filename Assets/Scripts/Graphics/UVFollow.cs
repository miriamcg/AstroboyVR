using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Astroboy.Graphics
{
    public class UVFollow : MonoBehaviour
    {
        [SerializeField]
        private GameObject player;
        [SerializeField]
        private float scrollSpeed = 0f;

        private MeshRenderer mesh = null;
        private Material mat = null;

        private Vector3 offset = Vector3.zero;

        void Start()
        {
            mesh = GetComponent<MeshRenderer>();
            mat = mesh.material;

            offset = mat.mainTextureOffset;
        }

        void Update()
        {
            offset.x = player.transform.position.x / transform.localScale.x / scrollSpeed;
            offset.y = player.transform.position.y / transform.localScale.y / scrollSpeed;

            if (offset.x > 1) offset.x = 0;

            mat.mainTextureOffset = offset;
        }
    }

}
