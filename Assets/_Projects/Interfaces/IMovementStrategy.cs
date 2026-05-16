using UnityEngine;

public interface IMovementStrategy
{
    void ExecuteMovement(Transform targetTransform, float moveSpeed);
}