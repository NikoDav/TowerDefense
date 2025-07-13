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
    [SerializeField] private int _switchTimeDuration;

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
            SwitchNight();
        }

        if (FindObjectOfType<EnemyHealth>() == null && _state == DayNightStates.Night)
        {
            SwitchDay();
        }
    }

    [ContextMenu("Switch Day")]
    public void SwitchDay()
    {
        _state = DayNightStates.Day;
        StartCoroutine(SwitchTime(Quaternion.Euler(34, -22, 10)));
        _daySwitched?.Invoke();
    }

    [ContextMenu("Switch Night")]
    public void SwitchNight()
    {
        _state = DayNightStates.Night;
        StartCoroutine(SwitchTime(Quaternion.Euler(-13, -19, 28)));
        _nightSwitched?.Invoke();
    }

    private IEnumerator SwitchTime(Quaternion targetRotation)
    {
        Quaternion startRotation = _light.transform.rotation;
        float elapsedTime = 0;
        while(elapsedTime <= _switchTimeDuration)
        {
            elapsedTime += Time.deltaTime;
            _light.transform.rotation = Quaternion.Slerp(startRotation, targetRotation, elapsedTime / _switchTimeDuration);
            yield return null;
        }
        _light.transform.rotation = targetRotation;
    }
    
}
