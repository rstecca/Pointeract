using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pointeract
{
    public interface ITeleportAnchor
    {
        Vector3 GetTeleportPosition();
        void OnTeleportIn();
        void OnTeleportOut();
    }
}
