using Agava.YandexGames;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SdkGameReady : MonoBehaviour
{    
    private void Start()
    {
        YandexGamesSdk.GameReady();
    }
}
