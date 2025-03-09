using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private DayNightCycle _dayNightCycle;
    [SerializeField] private WaveController _waveController;

    private void OnEnable()
    {
        _dayNightCycle._daySwitched += OnDaySwitched;
        _dayNightCycle._nightSwitched += OnNightSwitched;
    }

    private void OnDisable()
    {
        _dayNightCycle._daySwitched -= OnDaySwitched;
        _dayNightCycle._nightSwitched -= OnNightSwitched;
    }

    private void OnDaySwitched()
    {
        _waveController.AddWaveIndex();
    }

    private void OnNightSwitched()
    {
        _waveController.SpawnEnemies();
        //ChangeUI
        //ChangeLight
        //ChangeAudio
    }
}
