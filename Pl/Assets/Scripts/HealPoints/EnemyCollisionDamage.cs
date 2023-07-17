using UnityEngine;

public class EnemyCollisionDamage : MonoBehaviour, ICanDealDamage
{
    public float Damage => contactDamage;

    public ObjectsDamageGroup DamagesGroup => damageGroup;

    [SerializeField] private float contactDamage;
    [SerializeField] private ObjectsDamageGroup damageGroup;
}
