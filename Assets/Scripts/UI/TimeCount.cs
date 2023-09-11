using UnityEngine;
using UnityEngine.UI;

public class TimeCount : MonoBehaviour
{
    [SerializeField] private Text _timeCountText;
    [SerializeField] private GameManager _gameManager;
   
    private float _startTime;
    private float _actualTime;

    
    //public float ActualTime => _actualTime;

    private void Start()
    {
        _startTime = _gameManager.LoadTime();

    }

    private void Update()
    {    
       
        float elapsedTime = Time.time;

        float templateTime = elapsedTime + _startTime;

        DisplayTime(templateTime);
           
    }

    private void DisplayTime(float elapsedTime)
    {        
        float seconds = Mathf.FloorToInt(elapsedTime % 60);
        _timeCountText.text = seconds.ToString();
    }
}
