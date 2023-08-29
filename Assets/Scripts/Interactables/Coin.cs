using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Coin : MonoBehaviour
{
    [SerializeField] private PlayerGolds _playerGolds;
    [SerializeField] private float _jumpHeightAnimation = 0.5f;

    private AudioSource _coinPickUpSound;

    private void Start()
    {
        _coinPickUpSound = GetComponent<AudioSource>();

    }

    private IEnumerator PlayAndDestroy()
    {        
        _coinPickUpSound.Play();
        float animationDuration = PickUpAnimation();
        yield return new WaitForSeconds(animationDuration);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent<PlayerGolds>(out PlayerGolds golds))
        {
            golds.AddGold();
            StartCoroutine(PlayAndDestroy());
        }
    }

    private float PickUpAnimation()
    {
        Vector3 initialPosition = transform.position;
        float animationDuration = 0.5f;

        transform.DOJump(initialPosition + Vector3.up * _jumpHeightAnimation, _jumpHeightAnimation, 1, animationDuration).SetEase(Ease.OutQuad);

        return animationDuration;
    }
}
