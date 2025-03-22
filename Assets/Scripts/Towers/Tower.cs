using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private TowerConfig _towerConfig;
    [SerializeField] private MeshFilter _meshFilter;
    private int _index;
    private Coroutine _meshSwitch;
    const int _delay = 3;

    [ContextMenu("LevelUp")]
    public void LevelUp()
    {
        if (_meshSwitch != null)
            return;
        _index++;
        _meshSwitch = StartCoroutine(MeshSwitch());
    }

    private IEnumerator MeshSwitch()
    {
        _meshFilter.mesh = _towerConfig.TowerLevels[_index - 1].BuildingMesh;
        yield return new WaitForSeconds(_delay);
        _meshFilter.mesh = _towerConfig.TowerLevels[_index - 1].FinalMesh;
        _meshSwitch = null;
    }
}
