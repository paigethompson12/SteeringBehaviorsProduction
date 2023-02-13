using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : Seek
{
    public GameObject[] path;

    float pathOffset;
    int pathIndex;
    float targetRad = .5f; 

    public override SteeringOutput getSteering()
    {
        if (target == null)
        {
            int nearestPath = 0;
            float distToNearest = float.PositiveInfinity;
            for (int i = 0; i < path.Length; i++)
            {
                GameObject candidate = path[i];
                Vector3 vectorToCandidate = candidate.transform.position - character.transform.position;
                float distToCandidate = vectorToCandidate.magnitude;
                if (distToCandidate < distToNearest)
                {
                    nearestPath = i;
                    distToNearest = distToCandidate;
                }
            }

            target = path[nearestPath];
        }
        
        float distToTarget = (target.transform.position - character.transform.position).magnitude;
        if (distToTarget < targetRad)
        {
            pathIndex++;
            if (pathIndex > path.Length - 1)
            {
                pathIndex = 0;
            }
            target = path[pathIndex];
        }

        return base.getSteering();
    }
}