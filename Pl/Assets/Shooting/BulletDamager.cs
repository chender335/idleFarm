using UnityEngine;

public class BulletDamager : MonoBehaviour, ICanDealDamage
{
    public float Damage => PlayerShoot.GunInfo.BulletDamage;
}
