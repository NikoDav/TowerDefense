using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class UnitControl : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _navMesh;
    private Transform _target;


    private void Update()
    {
        CheckClick();
    }
    private void CheckClick()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                _target = hit.transform;
                _navMesh.SetDestination(_target.position);
            }
        }
    }
}
