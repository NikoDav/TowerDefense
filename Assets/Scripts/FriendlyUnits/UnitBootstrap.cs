using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitBootstrap : MonoBehaviour
{
    [SerializeField] private UnitConfig _unitConfig;
    [SerializeField] private UnitAttack _unitAttack;
    [SerializeField] private UnitHealth _unitHp;
    [SerializeField] private NavMeshAgent _navMesh;

    private void Start()
    {
        _unitAttack.Initialized(_unitConfig.Damage, _unitConfig.Range, _navMesh, _unitConfig.Delay, _unitConfig.HitRange);
        _unitHp.Initialized(_unitConfig.Hp);
    }
}
