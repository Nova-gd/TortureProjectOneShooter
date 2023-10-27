using UnityEngine;

public class StartScene : MonoBehaviour
{
    private LevelLoader _levelLoader;

    private void Awake()
    {
        _levelLoader = GetComponent<LevelLoader>();
    }

    private void Start()
    {
        _levelLoader.LoadLevel();
    }
}
