using UnityEngine;

public class Projectile : MonoBehaviour
{
    private int _damage = 40;
    private float _timeToDie = 3f;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent<PlayerHealth>(out PlayerHealth player))
        {
            player.ApplyDamage(_damage);
        }

        Destroy(gameObject, _timeToDie);
    }





    //private void OnCollisionEnter(Collision collision)
    //{
    //    Transform hitTransform = collision.transform;

    //    if (hitTransform.CompareTag("Player"))
    //    {           
    //        hitTransform.GetComponent<PlayerHealth>().ApplyDamage(_damage);
    //    }

    //    Destroy(gameObject, _timeToDie);
    //}    
}
