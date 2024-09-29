using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class PlayerVFXManager : MonoBehaviour
{
    public VisualEffect _footStep;

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
}
