using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PSystem : MonoBehaviour
{
    public ParticleSystem[] Particals;

    public void PlayParticals()
    {
        foreach (ParticleSystem s in Particals)
            s.Play();
    }

    public void StopParticals()
    {
        foreach (ParticleSystem s in Particals)
            s.Stop();
    }
}
