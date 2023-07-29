using UnityEngine;

public class FireTrapDamage : MonoBehaviour, ICanDealDamage
{
    public float Damage => Mathf.Infinity;
    public ObjectsDamageGroup DamagesGroup => ObjectsDamageGroup.Everybody;

    private FireTrap fireTrap;
#pragma warning disable CS0108 // „лен скрывает унаследованный член: отсутствует новое ключевое слово
    private Collider2D collider;
#pragma warning restore CS0108 // „лен скрывает унаследованный член: отсутствует новое ключевое слово

    private void Awake()
    {
        fireTrap = transform.parent.GetComponent<FireTrap>();
        collider = GetComponent<Collider2D>();

        collider.enabled = false;
        collider.isTrigger = true;
    }

    private void ChangeFireState(bool isEnabled)
    {
        collider.enabled = isEnabled;
    }

    private void OnEnable()
    {
        fireTrap.OnFireStateChanged += ChangeFireState;
    }

    private void OnDisable()
    {
        fireTrap.OnFireStateChanged -= ChangeFireState;
    }

}
