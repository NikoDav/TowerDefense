using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using HighlightPlus;

public class UnitControl : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _navMesh;
    [SerializeField] private HighlightEffect _highlightEffect;
    private Transform _target;
    private bool _clickSelf;


    private void Update()
    {
        //if (_clickSelf == false)
            //checkSelected();
        //else
            //checkClick();
    }
    private void checkClick()
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
                _clickSelf = false;
            }
        }
    }

    private void checkSelected()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if(hit.collider.gameObject == gameObject)
                {
                    _clickSelf = true;
                }
            }
        }
    }

    public void Select(bool select)
    {
        _clickSelf = select;
        _highlightEffect.SetHighlighted(select);
    }

    public void SetDestination(Vector3 targetPos)
    {
        _navMesh.SetDestination(targetPos);
        _clickSelf = false;
    }
}
