using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ScenesBook", menuName = "ScriptableObjects/ScenesBook")]
public class ScenesBook : ScriptableObject
{
    [SerializeField] private SceneData[] _sceneData;

    public SceneData[] SceneData => _sceneData;

    public SceneData GetSceneData(string sceneName)
    {
        foreach (SceneData sceneData in _sceneData)
            if (sceneData.Name == sceneName)
                return sceneData;

        return null;
    }
}

[Serializable]
public class SceneData
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _songIcon;

    public string Name => _name;
    public Sprite SongIcon => _songIcon;
}
