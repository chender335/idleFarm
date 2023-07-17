using UnityEngine;


[RequireComponent(typeof(Collider2D))]

public class ArmorBust : MonoBehaviour, IPickable
{
    public float Value => armorAmount;

    public PickableObjectType ObjectType => PickableObjectType.Armor;

    public float Time => bustTime;

    [SerializeField] private float armorAmount;
    [SerializeField] private float bustTime;
}
