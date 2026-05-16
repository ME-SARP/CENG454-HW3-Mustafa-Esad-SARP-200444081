using UnityEngine;
using UnityEngine.SceneManagement;

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
            Debug.Log("TEBRİKLER! Tesisi başarıyla savundunuz ve kazandınız!");
        }
        else
        {
            Debug.Log("OYUN BİTTİ! Çekirdek patladı, tesis çöktü!");
        }
    }

    private void Update()
    {
        if (!isGameActive && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}