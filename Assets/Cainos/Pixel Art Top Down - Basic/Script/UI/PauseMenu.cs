using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public TextMeshProUGUI seedText;

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        UIManager.instance.isPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        UIManager.instance.isPaused = true;

        DisplaySeed();
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }

    void DisplaySeed()
    {
        int currentSeed = SeedGenerator.GetGeneratedSeed();
        seedText.text = currentSeed.ToString();
    }

    public void CopySeedToClipboard()
    {
        int currentSeed = SeedGenerator.GetGeneratedSeed();
        GUIUtility.systemCopyBuffer = currentSeed.ToString();
        Debug.Log("Seed copiée dans le presse-papiers : " + currentSeed);
    }
}
