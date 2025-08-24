using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Wave", menuName = "CreateWave")]
public class WaveConfigure : ScriptableObject
{
    [SerializeField] private List<EnemySpawnList> _enemies;
    [SerializeField] private int _reward;
    private int _waveIndex;

    public List<EnemySpawnList> Enemies { get => _enemies; set => _enemies = value; }
    public int WaveIndex { get => _waveIndex; set => _waveIndex = value; }
    public int Reward { get => _reward; set => _reward = value; }
}

[Serializable]
public class EnemySpawnList
{
    [SerializeField] private EnemyAttack _enemy;
    [SerializeField] private int _amount;

    public EnemyAttack Enemy { get => _enemy; set => _enemy = value; }
    public int Amount { get => _amount; set => _amount = value; }

}
