using UnityEngine;

public class TargetedMovement : IMovementStrategy
{
    public void ExecuteMovement(Transform currentTransform, float moveSpeed)
    {
        // Sahnedeki enerji çekirdeğini ismiyle buluyoruz (Tam bir öğrenci pratik çözümü)
        GameObject core = GameObject.Find("EnergyCore");
        
        if (core != null)
        {
            Vector3 direction = (core.transform.position - currentTransform.position).normalized;
            
            currentTransform.Translate(direction * moveSpeed * Time.deltaTime);
        }
    }
}