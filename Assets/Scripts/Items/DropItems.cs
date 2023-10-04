using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class DropItems : MonoBehaviour
{
    [SerializeField] private bool destroyOnPickup = true;
    [SerializeField] private LayerMask canBePickupBy;
    [SerializeField] Items _item;

    const string player = "Player";
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag(player))
        {
            OnPickedUp();
            SoundManager.Instance.PlayEffect(SoundManager.Effect.Pickup);

            if (destroyOnPickup)
            {
                Destroy(gameObject);
            }
        }
    }
    private void OnPickedUp()
    {
        Inventory.Instance.AddItem(_item);
    }
}
