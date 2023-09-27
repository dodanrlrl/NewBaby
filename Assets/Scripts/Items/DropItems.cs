using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DropItems : MonoBehaviour
{
    [SerializeField] private bool destroyOnPickup = true;
    [SerializeField] private LayerMask canBePickupBy;
    [SerializeField] private AudioClip pickupSound;
    const string player = "Player";
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag(player))
        {
            OnPickedUp(other.gameObject);
            if (pickupSound)
                //SoundManager.PlayClip(pickupSound);

                if (destroyOnPickup)
                {
                    Destroy(gameObject);
                }
        }
    }

    protected abstract void OnPickedUp(GameObject receiver);
}
