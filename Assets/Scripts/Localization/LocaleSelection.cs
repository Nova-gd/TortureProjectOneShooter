using System.Collections;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class LocaleSelector : MonoBehaviour
{
    private int _languageID;

    private void Start()
    {
        _languageID = LocaleStandart();
        ChangeLocale(_languageID);        
    }

    private void Update()
    {
        int currentLanguageId = LocaleStandart();

        Debug.Log(currentLanguageId + " - номер ID языка");

        if (currentLanguageId != _languageID)
        {
            ChangeLocale(currentLanguageId);
        }
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

    private int LocaleStandart()
    {
        Locale currentSelectedLocale = LocalizationSettings.SelectedLocale;
        ILocalesProvider availableLocales = LocalizationSettings.AvailableLocales;

        if (currentSelectedLocale == availableLocales.GetLocale("en"))
        {       
            return 0;            
        }
        else if (currentSelectedLocale == availableLocales.GetLocale("ru"))
        {          
            return 1;
        }
        else if (currentSelectedLocale == availableLocales.GetLocale("tr"))
        {            
            return 2;
        }
        else
        {     
            return 4;
        }
    }
}











