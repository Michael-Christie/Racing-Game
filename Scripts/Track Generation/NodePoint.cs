using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodePoint : MonoBehaviour
{
    public Vector3 Posistion;
    public Vector3 Forward;
    public Vector3 Back;

    private void Awake()
    {
        Posistion = transform.position;
        Forward = transform.position + transform.forward * 4f;
        Back = transform.position - transform.forward * 4f;
    }
}
