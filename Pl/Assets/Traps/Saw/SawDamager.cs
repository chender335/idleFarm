using UnityEngine;

[RequireComponent(typeof(Collider2D))]

public class SawDamager : MonoBehaviour, ICanDealDamage
{
    public float Damage => Mathf.Infinity;

    public ObjectsDamageGroup DamagesGroup => ObjectsDamageGroup.Everybody;
}
