using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class PlayerVFXManager : MonoBehaviour
{
    public VisualEffect _footStep;
    public ParticleSystem Blade1;
    public ParticleSystem Blade2;
    public ParticleSystem Blade3;
    public VisualEffect Slash;
    public VisualEffect Heal;

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

    public void PlayBlade02()
    {
        Blade2.Play();
    }

    public void PlayBlade03()
    {
        Blade3.Play();
    }

    public void StopBlade()
    {
        Blade1.Simulate(0);
        Blade1.Stop();
        Blade2.Simulate(0);
        Blade2.Stop();
        Blade3.Simulate(0);
        Blade3.Stop();
    }

    public void PlaySlash(Vector3 pos)
    {
        Slash.transform.position = pos;
        Slash.Play();
    }

    public void PlayHealVFX()
    {
        Heal.Play();
    }
}
