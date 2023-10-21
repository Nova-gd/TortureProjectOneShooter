using Agava.YandexGames;
using UnityEngine;

public class SdkGameReady : MonoBehaviour
{    
    private void Start()
    {
        YandexGamesSdk.GameReady();
    }
}
