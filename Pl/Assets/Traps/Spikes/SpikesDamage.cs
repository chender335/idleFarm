using UnityEngine;

[RequireComponent(typeof(Collider2D))]

public class SpikesDamage : MonoBehaviour, ICanDealDamage
{
    public float Damage => Mathf.Infinity;

    public ObjectsDamageGroup DamagesGroup => ObjectsDamageGroup.Everybody;
}
