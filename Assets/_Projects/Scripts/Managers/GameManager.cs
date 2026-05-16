using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem; 

public class GameManager : MonoBehaviour
{
    private bool isGameActive = true;

    private void OnEnable()
    {
        GameEvents.OnGameOver += HandleGameOver;
    }

    private void OnDisable()
    {
        GameEvents.OnGameOver -= HandleGameOver;
    }

    private void HandleGameOver(bool isWin)
    {
        if (!isGameActive) return;
        
        isGameActive = false;

        if (isWin)
        {
            Debug.Log("TEBRİKLER! Tesisi basariyla savundunuz ve kazandiniz!");
        }
        else
        {
            Debug.Log("OYUN BİTTİ! Cekirdek patladi, tesis coktu!");
        }
    }

    private void Update()
    {
        if (!isGameActive && Keyboard.current != null && Keyboard.current.rKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}