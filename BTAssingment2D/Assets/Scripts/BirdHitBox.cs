using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdHitBox : MonoBehaviour
{
    public bool hitByBanana = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bana"))
        {
            hitByBanana = true;
        }
    }
}
