using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteOnCollide : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) { Destroy(gameObject); } // Delete gameobject on collide with player

    }
}
