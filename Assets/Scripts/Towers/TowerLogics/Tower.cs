using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;

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
    private bool _isBuilding = false;

    public event UnityAction Clicked;
    public event UnityAction Deactivate;

    const int _delay = 3;
    
    public void OnEnable()
    {
        CheckClick();
        _levelUpBtn.onClick.AddListener(LevelUp);
        _sellBtn.onClick.AddListener(Sell);

        _spawnObject._spawned += LevelUp;
    }

    public void OnDisable()
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
    public virtual void LevelUp()
    {
        if (Money.Instance.SpendMoney(_towerConfig.TowerLevels[_index].Cost))
        {
            if (_meshSwitch != null)
            {
                return;
            }
            _index++;
            if (_index + 1 >= _towerConfig.TowerLevels.Count)
            {
                _levelUpBtn.gameObject.SetActive(false);
            }

            _upgradePriceText.text = _towerConfig.TowerLevels[_index].Cost.ToString();
            _meshSwitch = StartCoroutine(MeshSwitch());
        }
    }

    private void Sell()
    {
        Money.Instance.addMoney(_towerConfig.TowerLevels[_index].Cost);
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
                    {
                        _canvas.gameObject.SetActive(true);
                        Clicked?.Invoke();
                    }  
                }
                else
                {
                    _canvas.gameObject.SetActive(false);
                    Deactivate?.Invoke();
                }
            }
            else
            {
                _canvas.gameObject.SetActive(false);
                Deactivate?.Invoke();
            }
        }
    }

    private IEnumerator MeshSwitch()
    {
        _levelUpBtn.gameObject.SetActive(false);
        _isBuilding = true;
        _meshFilter.mesh = _towerConfig.TowerLevels[_index - 1].BuildingMesh;
        yield return new WaitForSeconds(_delay);
        _levelUpBtn.gameObject.SetActive(true);
        _isBuilding = false;
        _meshFilter.mesh = _towerConfig.TowerLevels[_index - 1].FinalMesh;
        _meshSwitch = null;
    }


    
    
}
