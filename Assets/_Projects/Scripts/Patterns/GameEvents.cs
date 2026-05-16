using System;
using UnityEngine;

public static class GameEvents
{
        public static Action<float, float> OnCoreHealthChanged;

    public static Action<bool> OnGameOver;

    public static void TriggerCoreHealthChanged(float currentHealth, float maxHealth)
    {
        OnCoreHealthChanged?.Invoke(currentHealth, maxHealth);
    }

    public static void TriggerGameOver(bool isWin)
    {
        OnGameOver?.Invoke(isWin);
    }
}