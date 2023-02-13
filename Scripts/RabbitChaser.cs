using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitChaser : Kinematic
{
    public GameObject[] myPath = new GameObject[4];
    FollowPath myMoveType;
    Face myRotateType;
  
    // Start is called before the first frame update
    void Start()
    {
        myRotateType = new Face();
        myRotateType.character = this;
        myRotateType.target = myTarget;

        myMoveType = new FollowPath();
        myMoveType.character = this;
        myMoveType.path = myPath;
    }

    // Update is called once per frame
    protected override void Update()
    {
        steeringUpdate = new SteeringOutput();
        steeringUpdate.angular = myRotateType.getSteering().angular;
        steeringUpdate.linear = myMoveType.getSteering().linear;
        base.Update();
    }
}