using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Face : Align
{
    // TODO: override Align's getTargetAngle to face the target instead of matching it's orientation
    public override float getTargetAngle()
    {
        // --- replace me ---
        //float targetAngle = target.transform.eulerAngles.x;
        // ------------------
        Vector3 velocity = character.linearVelocity;
        float targetAngle = newOrientation(character.transform.eulerAngles.y, velocity);
        character.transform.eulerAngles = new Vector3(0, targetAngle, 0);

        return targetAngle;
    }

    private float newOrientation(float current, Vector3 velocity)
    {
        // Make sure we have a velocity.
        if (velocity.magnitude > 0) // Millington: "if velocity.length() > 0:"
        {
            // Calculate oreintation from the velocity
            // Millington has "return atan2(-static.x, static.z) because he assumes a left-hand system
            // see formulae on pages 47 vs. 46

            float targetAngle = Mathf.Atan2(velocity.x, velocity.z);
            // The above calculated radians. We prefer degrees, so convert:
            targetAngle *= Mathf.Rad2Deg;
            return targetAngle;
        }
        else
        {
            return current;
        }
    }

}
