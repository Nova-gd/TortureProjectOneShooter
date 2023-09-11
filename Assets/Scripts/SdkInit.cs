using Agava.YandexGames;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SdkInit : MonoBehaviour
{
    private void Start()
    {        
        StartCoroutine(DelayCoroutineFunction());

        SceneManager.LoadScene("StartScreen");
    }

    IEnumerator DelayCoroutineFunction()
    {     
        yield return YandexGamesSdk.Initialize();   
    } 
}
