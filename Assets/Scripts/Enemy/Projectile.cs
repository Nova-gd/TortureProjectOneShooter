using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private int _damage = 40;
    private float _timeToDie = 5;
    private void OnCollisionEnter(Collision collision)
    {
        Transform hitTransform = collision.transform;

        if (hitTransform.CompareTag("Player"))
        {           
            hitTransform.GetComponent<PlayerHealth>().ApplyDamage(_damage);
        }
        Destroy(gameObject, _timeToDie);
    }    
}
