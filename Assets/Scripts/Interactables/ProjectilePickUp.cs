using System.Collections;
using UnityEngine;
using DG.Tweening;

public class ProjectilePickUp : MonoBehaviour
{
    [SerializeField] private PlayerShoot _projectileForShoot;
    [SerializeField] private float _jumpHeightAnimation = 0.5f;

    private AudioSource _projectilePickUpSound;
    private void Start()
    {
        _projectilePickUpSound = GetComponent<AudioSource>();
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
        _projectilePickUpSound.Play();
        float animationDuration = PickUpAnimation();        
        yield return new WaitForSeconds(animationDuration);
        Destroy(gameObject);
    }

    private float PickUpAnimation()
    {        
        Vector3 initialPosition = transform.position;  
        float animationDuration = 0.5f;

        transform.DOJump(initialPosition + Vector3.up * _jumpHeightAnimation, _jumpHeightAnimation, 1, animationDuration).SetEase(Ease.OutQuad);

        return animationDuration;
    }
}
