using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDetective : MonoBehaviour
{
    private PlayerHealth _playerHealth;

    public PlayerHealth PlayerHealth => _playerHealth;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent<PlayerHealth>(out PlayerHealth playerHealth))
        {
            _playerHealth = playerHealth;
        }
    }

    private void OnTriggerExit (Collider collision)
    {
        if (collision.TryGetComponent<PlayerHealth>(out PlayerHealth playerHealth))
        {
            _playerHealth = null;
        }
    }
}
