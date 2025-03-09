using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DayNightCycle : MonoBehaviour
{
    [SerializeField] private float _currentTime;
    [SerializeField] private float _dayTime;
    [SerializeField] private DayNightStates _state;
    [SerializeField] private Transform _light;

    public event UnityAction _daySwitched;
    public event UnityAction _nightSwitched;

    //day: [34, -22, 10]

    //night: [-13, -19, 28]

    private void Update()
    {
        if(_state == DayNightStates.Day)
        {
            _currentTime += Time.deltaTime;
        }
        if(_currentTime >= _dayTime)
        {
            _currentTime = 0;
            //SwitchNight();
        }
    }

    [ContextMenu("Switch Day")]
    public void SwitchDay()
    {
        _state = DayNightStates.Day;
        _daySwitched?.Invoke();
    }

    [ContextMenu("Switch Night")]
    public void SwitchNight()
    {
        _state = DayNightStates.Night;
        _nightSwitched?.Invoke();
    }

    
}
