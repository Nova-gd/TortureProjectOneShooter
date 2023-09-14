using UnityEngine;
using UnityEngine.UI;

public class TimeCount : MonoBehaviour
{
    [SerializeField] private Text _timeCountText;
    private float _startTime;
    private bool _isRunning = false;
    private float _leaderBoardTime;

    public float LeaderBoardTime => _leaderBoardTime;    

    private void Start()
    {
        ResetTimer();         
        StartTimer();
    }

    private void Update()
    {
        if (_isRunning)
        {
            float currentTime = Time.time - _startTime; 
            int minutes = Mathf.FloorToInt(currentTime / 60); 
            int seconds = Mathf.FloorToInt(currentTime % 60); 
            int milliseconds = Mathf.FloorToInt((currentTime * 1000) % 1000);            
            string timeString = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
            _timeCountText.text = timeString;
            _leaderBoardTime = currentTime;
        }
    }

    private void StartTimer()
    {       
        _isRunning = true;        
    }

    public void StopTimer()
    {
        _isRunning = false;
    }

    private void ResetTimer()
    {
        _isRunning = false;
        _startTime = Time.time; 
        _timeCountText.text = "00:00:000";
    }
}
