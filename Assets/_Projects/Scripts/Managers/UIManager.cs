using UnityEngine;
using UnityEngine.UI; 

public class UIManager : MonoBehaviour
{
    [SerializeField] private Slider coreHealthSlider;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private Text gameOverText;

    private void OnEnable()
    {
        GameEvents.OnCoreHealthChanged += UpdateCoreHealthUI;
        GameEvents.OnGameOver += ShowGameOverScreen;
    }

    private void OnDisable()
    {
        GameEvents.OnCoreHealthChanged -= UpdateCoreHealthUI;
        GameEvents.OnGameOver -= ShowGameOverScreen;
    }

    private void Start()
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
    }

    private void UpdateCoreHealthUI(float currentHealth, float maxHealth)
    {
        if (coreHealthSlider != null)
        {
            coreHealthSlider.value = currentHealth / maxHealth;
        }
    }

    private void ShowGameOverScreen(bool isWin)
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
            
            if (gameOverText != null)
            {
                gameOverText.text = isWin ? "VICTORY! Core Secured." : "DEFEAT! Core Breached.";
            }
        }
    }
}