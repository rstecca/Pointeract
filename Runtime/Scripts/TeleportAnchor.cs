using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Pointeract
{
    public class TeleportAnchor : MonoBehaviour, ITeleportAnchor
    {
        public UnityEvent OnTeleportIn, OnTeleportOut;

        Vector3 ITeleportAnchor.GetTeleportPosition()
        {
            return transform.position;
        }

        void ITeleportAnchor.OnTeleportIn()
        {
            OnTeleportIn?.Invoke();
        }

        void ITeleportAnchor.OnTeleportOut()
        {
            OnTeleportOut?.Invoke();
        }
    }
}
