using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodePoint : MonoBehaviour
{
    public Vector3 Posistion => pos();
    public Vector3 Forward => forw();
    public Vector3 Back => bac();
    public bool isSelected = false;
    bool MouseOver = false;

    Vector3 pos() { return transform.position; }
    Vector3 forw() { return transform.position + transform.forward * 4f; }
    Vector3 bac() { return transform.position - transform.forward * 4f; }

    public Material Normal;
    public Material Hovered;
    public Material Selected;

    private void OnMouseEnter() { MouseOver = true; }
    private void OnMouseExit() { MouseOver = false; }

    private void Update()
    {
        UpdateVisuals();
    }

    void UpdateVisuals()
    {
        if (isSelected)
            gameObject.GetComponent<MeshRenderer>().material = Selected;
        else if (MouseOver)
            gameObject.GetComponent<MeshRenderer>().material = Hovered;
        else
            gameObject.GetComponent<MeshRenderer>().material = Normal;

    }

    public void Select(bool b)
    {
        isSelected = b;
    }
}
