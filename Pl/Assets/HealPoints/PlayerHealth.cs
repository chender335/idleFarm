using UnityEngine.SceneManagement;
using System;
using UnityEngine;

public class PlayerHealth : HealPoints
{
    public static Action OnPlayerDamaged;

    private float maxHealth;
    private float baseArmor;
    private float armorBustTime;
    
    private void Awake()
    {
        armorBustTime = 0;
        maxHealth = healPoints;
        baseArmor = armor;
    }

    protected override void Update()
    {
        base.Update();
        if(armorBustTime >= 0)
        {
            armorBustTime -= Time.deltaTime;
        }
        else
        {
            armor = baseArmor;
        }
    }

    protected override void Die()
    {
        SceneManager.LoadScene(0);
        base.Die();
    }

    protected override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        OnPlayerDamaged?.Invoke();
    }

    private void Heal(float healAmount)
    {
        if(healAmount <= 0)
        {
            throw new Exception("You cant heal less then 0" + gameObject);
        }
        else if(healPoints + healAmount <= maxHealth)
        {
            healPoints += healAmount;
        }
        else
        {
            healPoints = maxHealth;
        }
    }
    private void IncreaseArmor(float armorAmount, float time)
    {
        if (armorAmount <= 0)
        {
            throw new Exception("You cant increase armor less then 0" + gameObject);
        }
        else
        {
            armorBustTime = time;
            armor += armorAmount;
        }
    }

    private void OnEnable()
    {
        PlayerPickUp.OnHealthUp += Heal;
        PlayerPickUp.OnArmorUp += IncreaseArmor;
    }

    private void OnDisable()
    {
        PlayerPickUp.OnHealthUp += Heal;
        PlayerPickUp.OnArmorUp += IncreaseArmor;
    }
}
