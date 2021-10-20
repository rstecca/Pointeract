using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pointeract;

public class PointeractTester : MonoBehaviour, IPointable, IInteractable
{
    Material mat;
    Vector3 initialScale;
    Color initialColor;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
        initialScale = transform.localScale;
        initialColor = mat.color;
    }

    void IInteractable.OnInteract()
    {
        mat.color = Color.cyan;
    }

    void IPointable.OnPointerEnter()
    {
        mat.color = Color.red;
    }

    void IPointable.OnPointerExit()
    {
        mat.color = initialColor;
    }

    void IPointable.OnPointerStay()
    {
        mat.color = Color.green;
    }
}
