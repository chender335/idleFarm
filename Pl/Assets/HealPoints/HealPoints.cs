using UnityEngine;
using System;

public abstract class HealPoints : MonoBehaviour
{
    [SerializeField] protected float healPoints;
    [SerializeField] protected float armor;
    [SerializeField] protected ObjectsDamageGroup myGroup;
    [SerializeField] protected float timeBetweenDamage;

    private float timeRemainedToBeDamaged = 0;

    virtual protected void Update()
    {
        if(timeRemainedToBeDamaged >= 0)
        {
            timeRemainedToBeDamaged -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ICanDealDamage damager = collision.collider.GetComponent<ICanDealDamage>();
        if (damager != null && (damager.DamagesGroup == myGroup || damager.DamagesGroup == ObjectsDamageGroup.Everybody) && timeRemainedToBeDamaged <= 0)
        {
            TakeDamage(collision.collider.GetComponent<ICanDealDamage>().Damage);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ICanDealDamage damager = collision.GetComponent<ICanDealDamage>();
        if (damager != null && (damager.DamagesGroup == myGroup || damager.DamagesGroup == ObjectsDamageGroup.Everybody))
        {
            TakeDamage(collision.GetComponent<ICanDealDamage>().Damage);
        }
        Debug.Log(damager.DamagesGroup == ObjectsDamageGroup.Everybody);
    }

    protected virtual void TakeDamage(float damage)
    {
        timeRemainedToBeDamaged = timeBetweenDamage;
        if(damage <= 0)
        {
            throw new Exception("Damage cant be less then 0" + gameObject);
        }
        else
        {
            healPoints -= damage * (1 - ((armor <= 100 ? armor : 100) / 100));
            if(healPoints <= 0)
            {
                Die();
            }
        }
    }

    virtual protected void Die()
    {
        Destroy(gameObject);
    }
}

public enum ObjectsDamageGroup
{
    Enemy,
    Player,
    Everybody
}
