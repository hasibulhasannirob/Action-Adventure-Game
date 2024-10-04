using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class PlayerVFXManager : MonoBehaviour
{
    public VisualEffect _footStep;
    public ParticleSystem Blade1;
    public VisualEffect Slash;

    public void Update_FootStep(bool state)
    {
        if (state)
        {
            _footStep.Play();
        }
        else
        {
            _footStep.Stop();
        }
    }

    public void PlayBlade01()
    {
        Blade1.Play(); 
    }

    public void PlaySlash(Vector3 pos)
    {
        Slash.transform.position = pos;
        Slash.Play();
    }
}
