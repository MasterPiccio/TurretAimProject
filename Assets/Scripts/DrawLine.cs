using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    Cannon cannon;
    LineRenderer lineRenderer;

    public Transform firepoint;

    // Number of points on the line
    public int numPoints = 20;

    // distance between those points on the line
    public float timeBetweenPoints = 0.1f;

    // The physics layers that will cause the line to stop being drawn

    void Start()
    {
        cannon = GetComponent<Cannon>();
        lineRenderer = GetComponent<LineRenderer>();
    }


    //Y = Y0  +  V0y*t  +  -1/2 * g *t^2 

    //gravity is already -9.81m/s^2 in unity (so just add to the formula instead of minus)

    void Update()
    {
        lineRenderer.positionCount = (int)numPoints;
        List<Vector3> points = new List<Vector3>();
        Vector3 startingPosition = firepoint.position;
        Vector3 startingVelocity = firepoint.right * cannon.ballspeed;
        for (float t = 0; t < numPoints; t += timeBetweenPoints)
        {
            Vector3 newPoint = startingPosition + t * startingVelocity;
            newPoint.y = startingPosition.y + startingVelocity.y * t + Physics.gravity.y/2f * t * t;
            points.Add(newPoint);

        }

        lineRenderer.SetPositions(points.ToArray());
    }
}