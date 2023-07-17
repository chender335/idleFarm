using UnityEngine;
using System;

[RequireComponent(typeof(Collider2D))]

public class AmoBust : MonoBehaviour, IPickable
{
    public float Value => amoAmount;

    public PickableObjectType ObjectType => PickableObjectType.Amo;

    public float Time => throw new Exception("This class dont use time" + gameObject);

    [SerializeField] private float amoAmount;
}
