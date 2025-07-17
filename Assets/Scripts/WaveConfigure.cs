using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave", menuName = "CreateWave")]
public class WaveConfigure : ScriptableObject
{
    [SerializeField] private List<EnemyAttack> _enemies;
    [SerializeField] private int _enemiesAmount;
    [SerializeField] private int _reward;
    private int _waveIndex;

    public List<EnemyAttack> Enemies { get => _enemies; set => _enemies = value; }
    public int EnemiesAmount { get => _enemiesAmount; set => _enemiesAmount = value; }
    public int WaveIndex { get => _waveIndex; set => _waveIndex = value; }
    public int Reward { get => _reward; set => _reward = value; }
}
