using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave", menuName = "CreateWave")]
public class WaveConfigure : ScriptableObject
{
    [SerializeField] private List<Enemy> _enemies;
    [SerializeField] private int _enemiesAmount;
    private int _waveIndex;

    public List<Enemy> Enemies { get => _enemies; set => _enemies = value; }
    public int EnemiesAmount { get => _enemiesAmount; set => _enemiesAmount = value; }
    public int WaveIndex { get => _waveIndex; set => _waveIndex = value; }
}
