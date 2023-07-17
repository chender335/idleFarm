using UnityEngine;

public class BulletDamager : MonoBehaviour, ICanDealDamage
{
    public float Damage => PlayerShoot.GunInfo.BulletDamage;

    public ObjectsDamageGroup DamagesGroup => ObjectsDamageGroup.Everybody;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SelfDestroy();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SelfDestroy();
    }

    private void SelfDestroy()
    {
        Destroy(gameObject);
    }
}
