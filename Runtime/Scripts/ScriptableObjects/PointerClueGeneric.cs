using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Pointeract {
    [CreateAssetMenu]
    public class PointerClueGeneric : PointerClue, IPointerClue
    {
        [SerializeField] Mesh mesh;
        [SerializeField] Material mat;
        [SerializeField] float clueScale = 0.1f;

        private Vector3 viewportPoint = new Vector3(0, 0f, 1f);
        private Matrix4x4 viewportMatrix;

        void OnEnable()
        {
            viewportMatrix = Matrix4x4.TRS(viewportPoint, Quaternion.identity, Vector3.one * clueScale);
            Assert.IsNotNull(mesh);
            Assert.IsNotNull(mat);
        }

        void IPointerClue.Render(Vector3 _position, Camera _camera)
        {
            Graphics.DrawMesh(mesh, _camera.transform.localToWorldMatrix * viewportMatrix, mat, 0);
        }
    }
}
