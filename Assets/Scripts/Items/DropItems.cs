using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DropItems : MonoBehaviour
{
    [SerializeField] private bool destroyOnPickup = true;
    [SerializeField] private LayerMask canBePickupBy;

    const string player = "Player";
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(player))
        {
            OnPickedUp(other.gameObject);
            SoundManager.Instance.PlayEffect(SoundManager.Effect.Pickup);

            if (destroyOnPickup)
            {
                Destroy(gameObject);
            }
        }
    }
    protected abstract void OnPickedUp(GameObject receiver);
}
