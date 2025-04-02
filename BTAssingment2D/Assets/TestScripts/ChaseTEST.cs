using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseTEST : MonoBehaviour
{

    public Transform target;
    private AIPath aiLerp;

    // Start is called before the first frame update
    void Start()
    {
        aiLerp = GetComponent<AIPath>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            aiLerp.destination = target.position;
        }
    }
}
