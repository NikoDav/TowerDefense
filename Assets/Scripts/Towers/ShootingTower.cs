using UnityEngine;

[CreateAssetMenu(fileName = "tower", menuName = "CreateShootingTowerLevel")]
public class ShootingTower : TowerLevel
{
    [SerializeField] private float _fireRate;
    [SerializeField] private int _dmg;
    [SerializeField] private float _range;

    public int Dmg { get => _dmg; set => _dmg = value; }
    public float Range { get => _range; set => _range = value; }
    public float FireRate { get => _fireRate; set => _fireRate = value; }
}
