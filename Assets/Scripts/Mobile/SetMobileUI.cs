using Agava.WebUtility;
using UnityEngine;

public class SetMobileUI : MonoBehaviour
{
    [SerializeField] private GameObject _mobileUI;

    private void Start()
    {
        if (Device.IsMobile)
            if (!_mobileUI.activeSelf)
            {
                _mobileUI.SetActive(true);
            }
    }
}
