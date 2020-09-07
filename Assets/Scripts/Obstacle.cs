using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    GraphNode node;


    private void Start()
    {
        node = AstarPath.active.GetNearest(transform.position, NNConstraint.Default).node;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Bounds bounds = GetComponent<Collider>().bounds; 
            
            var guo = new GraphUpdateObject(bounds);

            guo.updatePhysics = true;

            AstarPath.active.UpdateGraphs(guo);
        }
    }

}
