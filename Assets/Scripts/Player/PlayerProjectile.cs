using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    private int _damage = 90;

    private void OnCollisionEnter(Collision collision)
    {
        Transform hitTransform = collision.transform;

        if (hitTransform.CompareTag("Enemy"))
        {           
            hitTransform.GetComponent<Enemy>().ApplyDamage(_damage);
        }
        Destroy(gameObject);
    }    
}
