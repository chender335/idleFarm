using UnityEngine;

public class SpikeBallDamage : MonoBehaviour, ICanDealDamage
{
    public float Damage => Mathf.Infinity;

    public ObjectsDamageGroup DamagesGroup => ObjectsDamageGroup.Everybody;
}
