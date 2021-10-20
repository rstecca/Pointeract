using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pointeract
{
    public class DirectionalPointer : MonoBehaviour
    {
        [SerializeField, Tooltip("The object that teleports. Can be null if no teleport needed")] Teleporter teleporter;
        [SerializeField] PointerClue pointerClue;

        Collider currentlyPointed, previouslyPointed;

        ITeleportAnchor previousAnchor;
        IPointerClue iPointerClue;

        private void Awake()
        {
            iPointerClue = (IPointerClue)pointerClue;
        }

        void Start()
        {
            
        }

        public void Update()
        {
            previouslyPointed = currentlyPointed;
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 10f)) {
                currentlyPointed = hit.collider;
                iPointerClue?.Render(hit.point, GetComponent<Camera>());
                bool isNewPointed = currentlyPointed?.GetInstanceID() != previouslyPointed?.GetInstanceID();
                foreach(IPointable pointable in currentlyPointed.GetComponents<IPointable>()) {
                    if(isNewPointed) {
                        pointable.OnPointerEnter();
                    } else {
                        pointable.OnPointerStay();
                    }
                }
                if(isNewPointed && previouslyPointed != null) {
                    foreach (IPointable pointable in previouslyPointed.GetComponents<IPointable>()) {
                        pointable.OnPointerExit();
                    }
                }
                if (Google.XR.Cardboard.Api.IsTriggerPressed || Input.GetMouseButtonDown(0)) {
                    foreach (IInteractable interactable in currentlyPointed.GetComponents<IInteractable>()) {
                        interactable.OnInteract();
                    }
                    // teleport
                    if (teleporter != null) {
                        ITeleportAnchor anchor = currentlyPointed.GetComponent<ITeleportAnchor>();
                        if (anchor != null) {
                            Vector3 pos = anchor.GetTeleportPosition();
                            teleporter.TeleportToPosition(pos);
                            anchor.OnTeleportIn();
                            teleporter.OnTeleport?.Invoke();
                            
                            if(previousAnchor != null) {
                                previousAnchor.OnTeleportOut();
                            }
                            previousAnchor = anchor;
                        }
                    }
                }
            }
            else {
                if(currentlyPointed != null) {
                    IPointable[] pointables = currentlyPointed.GetComponents<IPointable>();
                    foreach(IPointable pointable in pointables) {
                        pointable.OnPointerExit();
                    }
                    currentlyPointed = null;
                }
            }
        }
    }
}
