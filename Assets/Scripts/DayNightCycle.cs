using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DayNightCycle : MonoBehaviour
{
    [SerializeField] private float _currentTime;
    [SerializeField] private float _dayTime;
    [SerializeField] private DayNightStates _state;
    [SerializeField] private Transform _light;
    [SerializeField] private int _switchTimeDuration;
    [SerializeField] private GameObject _dayUiObject;
    [SerializeField] private GameObject _nightUiObject;
    [SerializeField] private Image _dayImage;

    public event UnityAction _daySwitched;
    public event UnityAction _nightSwitched;

    //day: [34, -22, 10]

    //night: [-13, -19, 28]

    private void Update()
    {
        if(_state == DayNightStates.Day)
        {
            _currentTime += Time.deltaTime;
            _dayImage.fillAmount = (_dayTime - _currentTime) / _dayTime;
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
        _dayUiObject.SetActive(true);
        _nightUiObject.SetActive(false);
        StartCoroutine(SwitchTime(Quaternion.Euler(34, -22, 10)));
        _daySwitched?.Invoke();
    }

    [ContextMenu("Switch Night")]
    public void SwitchNight()
    {
        _state = DayNightStates.Night;
        _dayUiObject.SetActive(false);
        _nightUiObject.SetActive(true);
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
