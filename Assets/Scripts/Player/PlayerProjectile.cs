using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    [SerializeField] private int _damage = 999;

    private float _timeForDie = 2f;


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent<Enemy>(out Enemy enemy))
        {
            enemy.ApplyDamage(_damage);
        }

        Destroy(gameObject, _timeForDie);
    }


    //private void OnCollisionEnter(Collision collision)
    //{
    //    Transform hitTransform = collision.transform;

    //    if (hitTransform.CompareTag("Enemy"))
    //    {
    //        hitTransform.GetComponent<Enemy>().ApplyDamage(_damage);
    //    }
    //    Destroy(gameObject);
    //}
}
