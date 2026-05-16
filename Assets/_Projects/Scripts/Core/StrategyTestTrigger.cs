using UnityEngine;
using UnityEngine.InputSystem;

public class StrategyTestTrigger : MonoBehaviour
{
    private Enemy enemyComponent;
    private bool isTargeted = false;

    private void Start()
    {
        enemyComponent = GetComponent<Enemy>();
    }

    private void Update()
    {
        if (Keyboard.current != null && Keyboard.current.mKey.wasPressedThisFrame)
        {
            if (enemyComponent != null)
            {
                if (!isTargeted)
                {
                    enemyComponent.ChangeMovementStrategy(new TargetedMovement());
                    Debug.Log(gameObject.name + " HAREKET STRATEJİSİ DEĞİŞTİ: Targeted Movement (Çekirdeğe Yöneliyor!)");
                }
                else
                {
                    enemyComponent.ChangeMovementStrategy(new LinearMovement());
                    Debug.Log(gameObject.name + " HAREKET STRATEJİSİ DEĞİŞTİ: Linear Movement (Düz Aşağı Yürüyor!)");
                }

                isTargeted = !isTargeted;
            }
        }
    }
}