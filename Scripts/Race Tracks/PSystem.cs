using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PSystem : MonoBehaviour
{
    public ParticleSystem[] Particals;

    public ParticleSystem[] Secondary;

    public void PlayParticals()
    {
        foreach (ParticleSystem s in Particals)
        {
            s.Play();
        }
    }

    public void SetColor(Color c, bool playSplash)
    {
        foreach (ParticleSystem s in Particals)
        {
            var m = s.main;
            if (m.startColor.color != c)
            {
                m.startColor = c;

                if(playSplash)
                    foreach (ParticleSystem p in Secondary)
                        p.Play();
            }
        }
    }

    public void StopParticals()
    {
        foreach (ParticleSystem s in Particals)
            s.Stop();
    }
}
