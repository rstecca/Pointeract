using UnityEngine;
using UnityEngine.Events;

namespace Pointeract
{
    public class Teleporter : MonoBehaviour
    {
        public UnityEvent OnTeleport;

        public void TeleportToPosition(Vector3 _position)
        {
            transform.position = _position;
        }
    }
}
