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
                targetCC.ApplyDamageCC(damage, transform.parent.position);
                PlayerVFXManager playerVFXManager = transform.parent.GetComponent<PlayerVFXManager>();

                if (playerVFXManager != null)
                {
                    RaycastHit hit;
                    Vector3 orignalPos = transform.position + (-_damageCasterColider.bounds.extents.z) * transform.forward;
                    bool isHit = Physics.BoxCast(orignalPos, _damageCasterColider.bounds.extents / 2, transform.forward, out hit, transform.rotation, _damageCasterColider.bounds.extents.z, 1 << 6);

                    if (isHit)
                    {
                        playerVFXManager.PlaySlash(hit.point + new Vector3(0, 0.5f, 0));
                    }
                }
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

    private void OnDrawGizmos()
    {
       if(_damageCasterColider == null)
        {
            _damageCasterColider=GetComponent<Collider>();
        }

       RaycastHit hit;
       Vector3 orignalPos = transform.position + (-_damageCasterColider.bounds.extents.z) * transform.forward;
        bool isHit = Physics.BoxCast(orignalPos, _damageCasterColider.bounds.extents/2, transform.forward, out hit, transform.rotation, _damageCasterColider.bounds.extents.z, 1<<6);

        if (isHit)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(hit.point, 0.3f);
        }
    }
}
