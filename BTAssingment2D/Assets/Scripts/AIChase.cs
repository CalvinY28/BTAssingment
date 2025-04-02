using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChase : MonoBehaviour
{

    public Transform target;
    private AIPath aiPath;

    // Start is called before the first frame update
    void Start()
    {
        aiPath = GetComponent<AIPath>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            aiPath.destination = target.position;
        }
    }
}
