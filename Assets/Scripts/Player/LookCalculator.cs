
using UnityEngine;

public class LookCalculator
{
    public bool HasLookInput(Vector2 input)
    {
        return input.y != 0;
    }
    public bool HasTurnInput(Vector2 input)
    {
        return input.x != 0;
    }
    public float GetNewLookAngle(float inputY, float currentAngle, float speed, float deltaTime)
    {
        var newRotation = currentAngle + -inputY * speed * deltaTime;
        return Mathf.Clamp(newRotation, -45, 45);
    }

    public Vector3 GetNewLookRotation(float currentAngle)
    {
        return new Vector3(currentAngle, 0, 0);
    }
}
