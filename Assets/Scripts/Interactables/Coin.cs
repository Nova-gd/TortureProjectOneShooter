using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour
{
    [SerializeField] private PlayerGolds _playerGolds;
    private AudioSource _getCoinSound;

    private void Start()
    {
        _getCoinSound = GetComponent<AudioSource>();

    }

    private IEnumerator PlayAndDestroy()
    {
        _getCoinSound.Play();
        yield return new WaitForSeconds(_getCoinSound.clip.length);  
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
}
