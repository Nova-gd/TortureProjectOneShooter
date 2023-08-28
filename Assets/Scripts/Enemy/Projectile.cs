using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private int _damage = 40;
    private float _timeToDie = 3f;
    private AudioSource _flyBurnSound;
    private AudioSource _burnSound;

    private void Start()
    {
        _flyBurnSound = GetComponent<AudioSource>();
        _burnSound = GetComponents<AudioSource>()[1]; 
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent<PlayerHealth>(out PlayerHealth player))
        {
            player.ApplyDamage(_damage);
            StartCoroutine(PlayAndDestroy());
        }

        Destroy(gameObject, _timeToDie);
    }

    private IEnumerator PlayAndDestroy()
    {
        _burnSound.Play();
        yield return new WaitForSeconds(_burnSound.clip.length);
        Destroy(gameObject);
    }
}
