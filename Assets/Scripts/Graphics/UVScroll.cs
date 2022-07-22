using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Astroboy.Graphics
{
    public class UVScroll : MonoBehaviour
    {
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
            offset.x += Time.deltaTime / scrollSpeed;

            if (offset.x > 0.9) offset.x = 0;

            mat.mainTextureOffset = offset;
        }
    }

}