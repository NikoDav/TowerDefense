using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave", menuName = "CreateWave")]
public class WaveConfigure : ScriptableObject
{
    [SerializeField] private List<Enemy> _enemies;
    [SerializeField] private int _enemiesAmount;
    private int _waveIndex;
}
