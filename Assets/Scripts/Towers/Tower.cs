using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class Tower : MonoBehaviour
{
    [SerializeField] private TowerConfig _towerConfig;
    [SerializeField] private MeshFilter _meshFilter;
    [SerializeField] private TMP_Text _upgradePriceText;
    [SerializeField] private Canvas _canvas;
    private int _index;
    private Coroutine _meshSwitch;
    private bool _isCanvasEnabled;
    const int _delay = 3;


    private void Update()
    {
        CheckClick();
    }
    [ContextMenu("LevelUp")]
    public void LevelUp()
    {
        if (_meshSwitch != null)
            return;
        _index++;
        _upgradePriceText.text = _towerConfig.TowerLevels[_index].Cost.ToString();
        _meshSwitch = StartCoroutine(MeshSwitch());
    }

    private void CheckClick()
    {
        if (Input.GetMouseButtonDown(0) && _isCanvasEnabled)
        {
            Debug.Log(EventSystem.current.IsPointerOverGameObject());
            if(EventSystem.current.IsPointerOverGameObject() == false && isClickOnCanvas() == false)
            {
                _canvas.gameObject.SetActive(false);
                _isCanvasEnabled = false;
            }
            else if(isClickOnCanvas())
            {
                _canvas.gameObject.SetActive(true);
                _isCanvasEnabled = true;
            }
        }
    }

    private bool isClickOnCanvas()
    {
        Vector2 mousePos = Input.mousePosition;
        RectTransform rectTransform = _canvas.GetComponent<RectTransform>();
        return RectTransformUtility.RectangleContainsScreenPoint(rectTransform, mousePos);
    }

    private void OnMouseDown()
    {
        //_canvas.gameObject.SetActive(true);
        //_isCanvasEnabled = true;
    }

    private IEnumerator MeshSwitch()
    {
        _meshFilter.mesh = _towerConfig.TowerLevels[_index - 1].BuildingMesh;
        yield return new WaitForSeconds(_delay);
        _meshFilter.mesh = _towerConfig.TowerLevels[_index - 1].FinalMesh;
        _meshSwitch = null;
    }
}
