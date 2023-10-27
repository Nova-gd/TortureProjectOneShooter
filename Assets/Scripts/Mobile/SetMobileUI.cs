using Agava.WebUtility;
using UnityEngine;

public class SetMobileUI : MonoBehaviour
{
    [SerializeField] private GameObject _mobileUI;
    [SerializeField] private GameObject _learningText;


    private void Start()
    {
        if (Device.IsMobile)
        {
            if (!_mobileUI.activeSelf)
            {
                _mobileUI.SetActive(true);
                _learningText.SetActive(false);
            }
        }

    }
}
