using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance { get; private set; }

    private string MAINMENU = "MainMenu";

    private void Awake()
    {
        if (Instance == null) 
            Instance = this; 
        else
            Destroy(gameObject); 
        
        DontDestroyOnLoad(gameObject);
    }

    public void LoadScene(string sceneName)
    {
        // Optionally add fade-out, glitch, flash etc.
        SceneManager.LoadScene(sceneName);
    }

    public void LoadMainMenu()
    {
        LoadScene(MAINMENU);
    }
}
