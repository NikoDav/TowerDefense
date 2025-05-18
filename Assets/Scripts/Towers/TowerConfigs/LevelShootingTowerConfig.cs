using UnityEngine;

[CreateAssetMenu(fileName = "tower", menuName = "Tower/CreateShootingTowerLevel")]
public class LevelShootingTowerConfig : TowerLevelBaseConfig
{
    [SerializeField] private float _fireRate;
    [SerializeField] private int _dmg;
    [SerializeField] private float _range;

    public int Dmg { get => _dmg; set => _dmg = value; }
    public float Range { get => _range; set => _range = value; }
    public float FireRate { get => _fireRate; set => _fireRate = value; }
}
