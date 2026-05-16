using UnityEngine;

public class LinearMovement : IMovementStrategy
{
    public void ExecuteMovement(Transform currentTransform, float moveSpeed)
    {
        currentTransform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
    }
}