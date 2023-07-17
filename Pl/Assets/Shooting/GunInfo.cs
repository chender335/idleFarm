using UnityEngine;

[CreateAssetMenu(menuName = "GunInfo")]

public class GunInfo : ScriptableObject
{
    [SerializeField] private float bulletDamage;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float shootDelay;
    [SerializeField] private GameObject bulletPrefab;

    public float BulletDamage => bulletDamage;
    public float BulletSpeed => bulletSpeed;
    public float ShootDelay => shootDelay;
    public GameObject BulletPrefab => bulletPrefab;
} 
