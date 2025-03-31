using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    [SerializeField] private TowerConfig _towerConfig;
    [SerializeField] private MeshFilter _meshFilter;
    [SerializeField] private TMP_Text _upgradePriceText;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private Button _levelUpBtn;
    [SerializeField] private Button _sellBtn;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _shootPoint;
    private int _index;
    private Coroutine _meshSwitch;
    private bool _isCanvasEnabled;
    private bool _canShoot;
    private Target _target;
    const int _delay = 3;

    private void OnEnable()
    {
        _levelUpBtn.onClick.AddListener(LevelUp);
        _sellBtn.onClick.AddListener(Sell);
    }

    private void OnDisable()
    {
        _levelUpBtn.onClick.RemoveListener(LevelUp);
        _sellBtn.onClick.RemoveListener(Sell);
    }

    private void Start()
    {
        LevelUp();
        _target = FindObjectOfType<Target>();
    }
    private void Update()
    {
        CheckClick();
        ShootCheck();
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

    private void ShootCheck()
    {
        Debug.Log(_towerConfig.TowerLevels[_index].Range);
        if (Vector3.Distance(transform.position, _target.transform.position) < _towerConfig.TowerLevels[_index].Range && _canShoot)
        {
            Debug.Log("shoot");
            StartCoroutine(Shoot());
        }
    }

    private void CheckClick()
    {

        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
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
        _canShoot = false;
        yield return new WaitForSeconds(_delay);
        _canShoot = true;
        _meshFilter.mesh = _towerConfig.TowerLevels[_index - 1].FinalMesh;
        _meshSwitch = null;
    }

    private IEnumerator Shoot()
    {
        GameObject bullet = Instantiate(_bullet, _shootPoint.position, Quaternion.identity);
        bullet.transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, _towerConfig.TowerLevels[_index].Range);
        _canShoot = false;
        yield return new WaitForSeconds(_towerConfig.TowerLevels[_index].FireRate);
        _canShoot = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 1, 0, 0.3f);
        Gizmos.DrawSphere(transform.position, _towerConfig.TowerLevels[_index].Range);
    }
}
