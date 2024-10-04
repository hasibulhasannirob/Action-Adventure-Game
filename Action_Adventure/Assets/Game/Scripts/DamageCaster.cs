using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DamageCaster : MonoBehaviour
{
    private Collider _damageCasterColider;
    public int damage = 30;
    public string TargetTag;
    private List<Collider> _damageTargetList;

    private void Awake()
    {
        _damageCasterColider = GetComponent<Collider>();
        _damageCasterColider.enabled = false;
        _damageTargetList = new List<Collider>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == TargetTag && !_damageTargetList.Contains(other))
        {
            Character targetCC = other.GetComponent<Character>();

            if (targetCC != null)
            {
                targetCC.ApplyDamageCC(damage);
            }

            _damageTargetList.Add(other);
        }
        
    } 

    


    public void EnableDamageCaster()
    { 
        _damageTargetList.Clear();
        _damageCasterColider.enabled = true;
    }

    public void DisableDamageCaster()
    {
        _damageTargetList.Clear();
        _damageCasterColider.enabled = false;
    }
}
