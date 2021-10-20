using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pointeract
{
    public interface IPointable
    {
        void OnPointerEnter();
        void OnPointerStay();
        void OnPointerExit();
    }
}
