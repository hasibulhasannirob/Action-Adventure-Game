using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public enum PickUpType
    {
        Heal, Coin
    }

    public PickUpType Type;
    public int Value = 20;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<Character>().PickUpItem(this);
            Destroy(gameObject);
        }
    }
}
