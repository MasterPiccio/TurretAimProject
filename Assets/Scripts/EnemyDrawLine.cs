using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrawLine : MonoBehaviour
{
    Enemy enemy;
    LineRenderer lineRenderer;

    public Transform firepoint;

    // Number of points on the line
    public int numPoints = 20;

    // distance between those points on the line
    public float timeBetweenPoints = 0.1f;

    public List<Vector3> points;

    // The physics layers that will cause the line to stop being drawn

    void Start()
    {
        
        enemy = GetComponent<Enemy>();
        lineRenderer = GetComponent<LineRenderer>();
    }


    //Y = Y0  +  V0y*t  +  -1/2 * g *t^2 

    //gravity is already -9.81m/s^2 in unity (so just add to the formula instead of minus)

    void Update()
    {
        lineRenderer.positionCount = (int)numPoints;
        points = new List<Vector3>();
        Vector3 startingPosition = firepoint.position;
        Vector3 startingVelocity = firepoint.right * enemy.ballspeed;
        for (float t = 0; t < numPoints; t += timeBetweenPoints)
        {
            Vector3 newPoint = startingPosition + t * startingVelocity;
            Vector3 nextpoint = startingPosition + (t+1) * startingVelocity;
            newPoint.y = startingPosition.y + startingVelocity.y * t + Physics.gravity.y/2f * t * t;
            nextpoint.y = startingPosition.y + startingVelocity.y * (t+1) + Physics.gravity.y/2f * (t+1) * (t+1);
            RaycastHit2D hit = Physics2D.Raycast(newPoint,nextpoint,timeBetweenPoints);
            
            if(hit == false)
            {
                points.Add(newPoint);
                enemy.ontarget =false;
                
            }
            if(hit ==true)
            {   
                Debug.Log(hit.collider.tag);
                points.Add(hit.point);
                enemy.ontarget =false;

                    if(hit.collider.tag=="Player")
                        {
                            enemy.ontarget=true;;
                        }
                break;
            }

            

        }


        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPositions(points.ToArray());
    }



    public void UpdateLine()
    {

    }



    
}