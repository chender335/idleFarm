using UnityEngine;

public class EnemyHealth : HealPoints
{
    private void Awake()
    {
        myGroup = ObjectsDamageGroup.Enemy;
    }
}
