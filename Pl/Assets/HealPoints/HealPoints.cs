using UnityEngine;
using System;

public abstract class HealPoints : MonoBehaviour
{
    [SerializeField] protected float healPoints;
    [SerializeField] protected float armor;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<Enemy>() != null)
        {
            TakeDamage(collision.collider.GetComponent<ICanDealDamage>().Damage);
        }
    }

    private void TakeDamage(float damage)
    {
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
