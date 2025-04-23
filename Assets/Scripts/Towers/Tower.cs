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
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private SpawnObject _spawnObject;
    private int _index;
    private Coroutine _meshSwitch;
    private bool _isCanvasEnabled;
    private bool _canShoot;
    private GameObject _target;
    private float _elapsedTime;
    private Bullet _currentBullet;
    //private bool _showUI = false;
    
    const int _delay = 3;

    private void OnEnable()
    {
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

    private void Update()
    {
        CheckClick();
        if(_target != null)
        {
            Shoot();
        }
    }

    private void FixedUpdate()
    {
        Collider[] enemies = Physics.OverlapSphere(transform.position, _towerConfig.TowerLevels[_index].Range, _enemyLayer);
        if(enemies.Length > 0)
        {
            _target = enemies[0].gameObject;
        }
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

    
    private void Shoot()
    {
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime >= _towerConfig.TowerLevels[_index].FireRate && Vector3.Distance(transform.position, _target.transform.position) < _towerConfig.TowerLevels[_index].Range)
        {
            _currentBullet = Instantiate(_bullet, _shootPoint.position, Quaternion.identity);
            _currentBullet.transform.LookAt(_target.transform);
            _elapsedTime = 0;
        }
    }



    private void CheckClick()
    {

        if (Input.GetMouseButtonDown(0) && _index>0)
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


    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 1, 0, 0.3f);
        Gizmos.DrawSphere(transform.position, _towerConfig.TowerLevels[_index].Range);
    }
}
