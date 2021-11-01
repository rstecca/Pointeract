using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Pointeract
{

    public class PointableEvents : MonoBehaviour, IPointable, IInteractable
    {
        [SerializeField] UnityEvent OnInteract, OnPointEnter, OnPointExit, OnPointStay;

        //void Start()
        //{

        //}

        void IInteractable.OnInteract()
        {
            OnInteract.Invoke();
        }

        void IPointable.OnPointerEnter()
        {
            OnPointEnter.Invoke();
        }

        void IPointable.OnPointerExit()
        {
            OnPointExit.Invoke();
        }

        void IPointable.OnPointerStay()
        {
            OnPointStay.Invoke();
        }

    }

}
