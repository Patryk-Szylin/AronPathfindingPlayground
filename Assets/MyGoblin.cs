using Pathfinding;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGoblin : MonoBehaviour
{
    public GameObject Target;
    private Seeker seeker;
    private IAstarAI ai;
    ABPath path;
    private void Awake()
    {
        seeker = GetComponent<Seeker>();
        ai = GetComponent<IAstarAI>();
    }


    private void Start()
    {
        var p = ABPath.Construct(this.transform.position, Target.transform.position, null);

        seeker.StartPath(p, OnPathComplete);
    }

    private void OnPathComplete(Path p)
    {
        if (path != null) path.Release(this);

        path = p as ABPath;

        path.Claim(this);
    }

    private void Update()
    {
        //Draw the path in the editor
        if (path != null && path.vectorPath != null)
        {
            for (int i = 0; i < path.vectorPath.Count - 1; i++)
            {
                Debug.DrawLine(path.vectorPath[i], path.vectorPath[i + 1], Color.green);
            }
        }
    }
}
