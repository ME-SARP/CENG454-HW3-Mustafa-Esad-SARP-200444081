using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem; 

public class GameManager : MonoBehaviour
{
    private bool isGameActive = true;
    
    [SerializeField] private float gameDuration = 120f; 
    private float timeRemaining;

    private string endScreenText = "";

    private void Start()
    {
        timeRemaining = gameDuration;
        Time.timeScale = 1f; 
    }

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
        isGameActive = false;
        Time.timeScale = 0f; 
        
        if (isWin)
        {
            endScreenText = "VICTORY";
            Debug.Log("*********************************");
            Debug.Log("            VICTORY              ");
            Debug.Log("*********************************");
        }
        else
        {
            endScreenText = "DEFEAT";
            Debug.Log("*********************************");
            Debug.Log("            DEFEAT               ");
            Debug.Log("*********************************");
        }
    }

    private void Update()
    {
        if (isGameActive)
        {
            timeRemaining -= Time.deltaTime;
            
            if (timeRemaining <= 0f)
            {
                HandleGameOver(true);
            }
        }
        else
        {
            if (Keyboard.current != null && Keyboard.current.rKey.wasPressedThisFrame)
            {
                Time.timeScale = 1f; // Yeniden baslatirken zamani aciyoruz
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    private void OnGUI()
    {
        if (!isGameActive)
        {
            GUIStyle style = new GUIStyle();
            style.fontSize = 60;
            style.fontStyle = FontStyle.Bold;
            style.alignment = TextAnchor.MiddleCenter;
            
            style.normal.textColor = endScreenText == "VICTORY" ? Color.green : Color.red;

            GUI.Label(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 50, 400, 100), endScreenText, style);

            GUIStyle subStyle = new GUIStyle();
            subStyle.fontSize = 20;
            subStyle.alignment = TextAnchor.MiddleCenter;
            subStyle.normal.textColor = Color.white;
            GUI.Label(new Rect(Screen.width / 2 - 200, Screen.height / 2 + 50, 400, 50), "Yeniden baslatmak icin 'R' tusuna basin", subStyle);
        }
    }
}