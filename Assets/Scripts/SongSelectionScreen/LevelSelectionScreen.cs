using System.Collections.Generic;
using UnityEngine;

public class LevelSelectionScreen : MonoBehaviour
{
    [SerializeField] private ScenesBook _scenesBook;
    [SerializeField] private LevelPreview _levelPreviewPrefab;
    [SerializeField] private LevelLoader _levelLoader;

    private List<LevelPreview> _previews = new List<LevelPreview>();

    private void Awake()
    {
        for (int i = 0; i < _scenesBook.SceneData.Length; i++)
        {
            LevelPreview preview = Instantiate(_levelPreviewPrefab, _levelPreviewPrefab.transform.parent);
            preview.gameObject.SetActive(true);
            _previews.Add(preview);
            preview.SceneData = _scenesBook.SceneData[i];
        }
    }

    private void OnEnable()
    {
        foreach (LevelPreview preview in _previews)
            preview.PlayButtonClick += OnPlayButtonClick;
    }

    private void OnDisable()
    {
        foreach (LevelPreview preview in _previews)
            preview.PlayButtonClick -= OnPlayButtonClick;
    }

    private void Start()
    {
        
    }

    private void OnPlayButtonClick(SceneData data)
    {
        _levelLoader.LoadLevel(data.Name);
    }
}
