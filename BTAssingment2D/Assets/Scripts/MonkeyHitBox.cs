using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyHitBox : MonoBehaviour
{
    public bool hitByProjectile = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Poop"))
        {
            hitByProjectile = true;
        }
    }
}
