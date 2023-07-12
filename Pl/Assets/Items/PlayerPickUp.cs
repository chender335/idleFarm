using UnityEngine;
using System; 

public class PlayerPickUp : MonoBehaviour
{
    public static Action<float> OnHealthUp;
    public static Action<float> OnAmoUp;
    public static Action<float, float> OnArmorUp;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IPickable pickedObject = collision.collider.GetComponent<IPickable>();
        if(pickedObject == null)
        {
            return;
        }
        else
        {
            if(pickedObject.ObjectType == PickableObjectType.Medic)
            {
                OnHealthUp?.Invoke(pickedObject.Value);
            }
            if (pickedObject.ObjectType == PickableObjectType.Amo)
            {
                OnAmoUp?.Invoke(pickedObject.Value);
            }
            if (pickedObject.ObjectType == PickableObjectType.Armor)
            {
                OnArmorUp?.Invoke(pickedObject.Value, pickedObject.Time);
            }
            Destroy(collision.gameObject);
        }
    }
}
