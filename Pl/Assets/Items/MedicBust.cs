using UnityEngine;
using System;

[RequireComponent(typeof(Collider2D))]

public class MedicBust : MonoBehaviour, IPickable
{
    public float Value => healAmount;

    public PickableObjectType ObjectType => PickableObjectType.Medic;

    public float Time => throw new Exception("This class dont use time" + gameObject);

    [SerializeField] private float healAmount;
}
