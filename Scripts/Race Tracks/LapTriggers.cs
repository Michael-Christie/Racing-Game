using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapTriggers : MonoBehaviour
{
    public int ID;

    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<GameStart>().boxHit(ID);
    }
}
