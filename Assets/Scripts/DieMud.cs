using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieMud : MonoBehaviour
{
    public LayerMask player;

    private void OnTrigger(Collider player)
    {
        if (player.CompareTag("Player"))
        {
            player.GetComponent<PlayerCombat>().Life -= 100;
        }
    }
}
