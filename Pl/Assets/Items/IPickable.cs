public interface IPickable
{
    public float Value { get; }
    public PickableObjectType ObjectType { get; }
    public float Time { get; }
}

public enum PickableObjectType
{
    Medic,
    Amo,
    Armor
}