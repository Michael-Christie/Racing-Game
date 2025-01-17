﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodePoint : MonoBehaviour
{
    public Vector3 Posistion => pos();
    public Vector3 Forward => forw();
    public Vector3 Back => bac();
    public Vector3 Rotation => transform.eulerAngles;
    public bool isSelected = false;
    bool MouseOver = false;

    public bool LockedNode = false;

    Vector3 pos() { return transform.position; }
    Vector3 forw() { return transform.position + transform.forward * 10f; }
    Vector3 bac() { return transform.position - transform.forward * 10f; }

    public Material Normal;
    public Material Hovered;
    public Material Selected;
    public Material Locked;

    //private void OnMouseEnter() { MouseOver = true; }
    //private void OnMouseExit() { MouseOver = false; }

    private void Update()
    {
        UpdateVisuals();
    }

    void UpdateVisuals()
    {
        if (!LockedNode)
        {
            if (isSelected)
                gameObject.GetComponent<MeshRenderer>().material = Selected;
            else if (MouseOver)
                gameObject.GetComponent<MeshRenderer>().material = Hovered;
            else
                gameObject.GetComponent<MeshRenderer>().material = Normal;
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().material = Locked;
        }

    }

    public void Select(bool b)
    {
        isSelected = b;
    }
    
    public void RotateRight()
    { 
        Vector3 euler = transform.rotation.eulerAngles;
        euler += new Vector3(0, 15, 0);
        transform.rotation = Quaternion.Euler(euler);
    }

    public void RotateLeft()
    {
        Vector3 euler = transform.rotation.eulerAngles;
        euler -= new Vector3(0, 15, 0);
        transform.rotation = Quaternion.Euler(euler);
    }

    public void SetPosition(Vector3 v) { transform.position = v; }
}
