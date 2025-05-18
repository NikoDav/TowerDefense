using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyConfig", menuName = "CreateEnemy")]
public class EnemyConfig : ScriptableObject
{
    [SerializeField] private int _hp;
    [SerializeField] private int _delay;
    [SerializeField] private int _damage;

    public int Hp { get => _hp; set => _hp = value; }
    public int Delay { get => _delay; set => _delay = value; }
    public int Damage { get => _damage; set => _damage = value; }
}
