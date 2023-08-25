using System.Collections;
using UnityEngine;

public class ProjectilePickUp : MonoBehaviour
{
    [SerializeField] private PlayerShoot _projectileForShoot;
    private AudioSource _getProjectileSound;
    private void Start()
    {
        _getProjectileSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent<PlayerShoot>(out PlayerShoot projectiles))
        {
            projectiles.SetProjectileCount();
            StartCoroutine(PlayAndDestroy());
        }        
    }

    private IEnumerator PlayAndDestroy()
    {
        _getProjectileSound.Play();
        yield return new WaitForSeconds(_getProjectileSound.clip.length);
        Destroy(gameObject);
    }
}
