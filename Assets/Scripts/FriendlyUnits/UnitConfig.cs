using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "unit", menuName = "CreateUnit")]
public class UnitConfig : ScriptableObject
{
    [SerializeField] private int _hp;
    [SerializeField] private float _speed;
    [SerializeField] private float _range;
    [SerializeField] private int _damage;
    [SerializeField] private int _delay;
    [SerializeField] private float hitRange;

    public int Hp { get => _hp; set => _hp = value; }
    public float Speed { get => _speed; set => _speed = value; }
    public float Range { get => _range; set => _range = value; }
    public int Damage { get => _damage; set => _damage = value; }
    public int Delay { get => _delay; set => _delay = value; }
    public float HitRange { get => hitRange; set => hitRange = value; }
}
