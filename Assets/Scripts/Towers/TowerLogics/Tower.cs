using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    [SerializeField] protected TowerLevelContainer _towerConfig;
    [SerializeField] private MeshFilter _meshFilter;
    [SerializeField] private TMP_Text _upgradePriceText;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private Button _levelUpBtn;
    [SerializeField] private Button _sellBtn;
    [SerializeField] private SpawnObject _spawnObject;
    protected int _index;
    private Coroutine _meshSwitch;
    private bool _firstClick = true;

    
    const int _delay = 3;
    
    private void OnEnable()
    {
        CheckClick();
        _levelUpBtn.onClick.AddListener(LevelUp);
        _sellBtn.onClick.AddListener(Sell);

        _spawnObject._spawned += LevelUp;
    }

    private void OnDisable()
    {
        _levelUpBtn.onClick.RemoveListener(LevelUp);
        _sellBtn.onClick.RemoveListener(Sell);

        _spawnObject._spawned -= LevelUp;
    }

    protected void Update()
    {
        CheckClick();
        
    }


    [ContextMenu("LevelUp")]
    public void LevelUp()
    {
        if (_meshSwitch != null)
        {
            return;
        }
        _index++;
        if (_index+1 >= _towerConfig.TowerLevels.Count)
        {
            _levelUpBtn.gameObject.SetActive(false);
        }
        
        _upgradePriceText.text = _towerConfig.TowerLevels[_index].Cost.ToString();
        _meshSwitch = StartCoroutine(MeshSwitch());
    }

    private void Sell()
    {
        Destroy(gameObject);
    }

    




    private void CheckClick()
    {
        if (Input.GetMouseButtonUp(0) && _index>0)
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    Debug.Log("click");
                    if (_firstClick)
                        _firstClick = false;
                    else
                        _canvas.gameObject.SetActive(true);
                }
                else
                {
                    _canvas.gameObject.SetActive(false);
                }
            }
            else
                _canvas.gameObject.SetActive(false);
        }
    }

    private IEnumerator MeshSwitch()
    {
        _meshFilter.mesh = _towerConfig.TowerLevels[_index - 1].BuildingMesh;
        yield return new WaitForSeconds(_delay);
        _meshFilter.mesh = _towerConfig.TowerLevels[_index - 1].FinalMesh;
        _meshSwitch = null;
    }


    
    
}
