using UnityEngine;
using UnityEngine.UI;

public class WeaponCount : MonoBehaviour
{
    [SerializeField] private Text _projectileCountText;
    [SerializeField] private PlayerShoot _playerShoot; 

    private void Start()
    {
        UpdateCountText();
    }

    private void Update()
    {
        UpdateCountText();
    }


    private void UpdateCountText()
    {
        int totalProjectile = _playerShoot.ProjectileCount;
        _projectileCountText.text = totalProjectile.ToString();
    } 
}
