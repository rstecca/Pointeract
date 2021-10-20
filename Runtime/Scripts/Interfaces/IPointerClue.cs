using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pointeract
{
    public interface IPointerClue
    {
        void Render(Vector3 _position, Camera _camera);
    }
}
