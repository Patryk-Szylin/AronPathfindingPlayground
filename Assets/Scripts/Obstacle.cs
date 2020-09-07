using Pathfinding;
using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    GraphNode node;


    private void Start()
    {
        node = AstarPath.active.graphs[0].GetNearest(transform.position, NNConstraint.Default).node;

        node.Walkable = false;

        Observable.Interval(TimeSpan.FromSeconds(2f))
            .Take(1)
            .Subscribe(_ =>
            {
                node.Walkable = true;
                Destroy(this.gameObject);
            });

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
