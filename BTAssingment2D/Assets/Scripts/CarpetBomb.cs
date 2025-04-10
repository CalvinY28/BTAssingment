using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarpetBomb : MonoBehaviour
{
    private float speed;
    private GameObject poopPrefab;
    private float poopDropInterval;
    private float dropTimer;

    public void Initialize(float moveSpeed, GameObject poop, float dropRate) // called by BirdArmy script
    {
        speed = moveSpeed;
        poopPrefab = poop;
        poopDropInterval = dropRate;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * speed * Time.deltaTime; // Move them to the right

        dropTimer += Time.deltaTime;
        if (dropTimer >= poopDropInterval) // if enough time passed take a dump
        {
            dropTimer = 0f;
            if (poopPrefab != null)
            {
                Instantiate(poopPrefab, transform.position, Quaternion.identity);
            }
        }

        if (Camera.main.WorldToViewportPoint(transform.position).x > 1.5f) // delete after out of camera view
        {
            Destroy(gameObject);
        }
    }
}
