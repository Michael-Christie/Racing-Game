using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeColliders : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {

            Debug.Log("Hit cone");
            Vector3 dir = transform.position - collision.transform.position;
            dir = dir.normalized;
            GetComponent<Rigidbody>().AddForce(dir * 100f, ForceMode.Impulse);
        }
    }
}
