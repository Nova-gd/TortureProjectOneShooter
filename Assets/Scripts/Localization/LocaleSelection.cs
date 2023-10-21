using System.Collections;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class LocaleSelector : MonoBehaviour
{
    private void Start()
    {
        int ID = PlayerPrefs.GetInt("LocaleKey", 0);
        ChangeLocale(ID);
    }

    private bool _active = false;

    public void ChangeLocale(int localeID)
    {
        if (_active)
        {
            return;
        }

        StartCoroutine(SetLocale(localeID));
    }

    private IEnumerator SetLocale(int localeID)
    {
        _active = true;
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[localeID];
        _active = false;

        PlayerPrefs.SetInt("LocaleKey", localeID);
    }
}