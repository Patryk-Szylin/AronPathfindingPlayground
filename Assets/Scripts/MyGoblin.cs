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

    public GameObject MWall;

    private void Awake()
    {
        seeker = GetComponent<Seeker>();
        ai = GetComponent<IAstarAI>();
    }


    private void Start()
    {
       
    }

    private void OnPathComplete(Path p)
    {
        if (path != null) path.Release(this);

        path = p as ABPath;

        path.Claim(this);
    }

    private void Update()
    {
        ai.destination = Target.transform.position;

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Instantiate(MWall, hit.point, Quaternion.identity);
            }
        }

        if (Input.GetMouseButton(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Target.transform.position = hit.point;
            }
        }



        //var p = ABPath.Construct(this.transform.position, Target.transform.position, null);

        //seeker.StartPath(p, OnPathComplete);
        //Draw the path in the editor
        //if (path != null && path.vectorPath != null)
        //{
        //    for (int i = 0; i < path.vectorPath.Count - 1; i++)
        //    {
        //        Debug.DrawLine(path.vectorPath[i], path.vectorPath[i + 1], Color.green);
        //    }
        //}
    }
}
