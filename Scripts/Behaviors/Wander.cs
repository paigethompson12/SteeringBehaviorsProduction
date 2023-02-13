
using UnityEngine;

public class Wander : SteeringBehavior
{
    public Kinematic character;
    float maxSpeed = 5f;
    float maxRotation = 285f;

    //character.angularvelocity = millington's rotation
    //transform.rotation = Millington's orientation

    public override SteeringOutput getSteering()
    {
        SteeringOutput result = new SteeringOutput();

        result.linear = maxSpeed * (character.transform.rotation * Vector3.forward);        
        //float rotation = Mathf.DeltaAngle(character.transform.eulerAngles.y, getTargetAngle());
        character.angularVelocity = randomBinomial() * maxRotation;
        //result.angular = 
        
        return result;
    }

    float randomBinomial()
    {
        return Random.value - Random.value;
    }
    
}
