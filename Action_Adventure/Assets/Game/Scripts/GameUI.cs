using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public GameManager GM;
    public Slider HealthSlider;

    void Update()
    {
        HealthSlider.value = GM.playerCharacter.GetComponent<Health>().CurrentHealthPercentage;
    }
}
