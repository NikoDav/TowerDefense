using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DruidVine : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private LayerMask _layer;

    public List<IDamagable> CheckTrigger()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _radius, _layer);
        List<IDamagable> damagables = new List<IDamagable>();
        foreach(Collider collider in colliders)
        {
            damagables.Add(collider.GetComponent<IDamagable>());
        }
        return damagables;
    }
}
