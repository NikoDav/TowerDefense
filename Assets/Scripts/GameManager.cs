using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private DayNightCycle _dayNightCycle;
    [SerializeField] private WaveController _waveController;
    [SerializeField] private GameObject _shopPanel;

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
        _shopPanel.SetActive(true);
        _waveController.AddWaveIndex();
        _waveController.CheckReadyNextMap();
    }

    private void OnNightSwitched()
    {
        _waveController.SpawnEnemies();
        _shopPanel.SetActive(false);
        //ChangeUI
        //ChangeLight
        //ChangeAudio
    }
}
