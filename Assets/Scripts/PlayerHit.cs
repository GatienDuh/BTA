using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    public LayerMask Bullets;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            this.gameObject.GetComponent<PlayerCombat>().Life -= 1;
            Destroy(other);
        }
    }
}
