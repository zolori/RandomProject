using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public TextMeshProUGUI seedText;

    public SoundPlayer soundPlayer;
    public AudioClip hoverButton;
    public AudioClip clickButton;

    public void Resume()
    {
        // play sound
        if (soundPlayer != null)
        {
            soundPlayer.PlaySoundEffect(clickButton);
        }
        else
        {
            Console.Error.WriteLine("soundPlayer Empty");
        }

        Cursor.visible = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        UIManager.instance.isPaused = false;
    }

    public void Pause()
    {
        Cursor.visible = true;
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
        // play sound
        if (soundPlayer != null)
        {
            soundPlayer.PlaySoundEffect(clickButton);
        }
        else
        {
            Console.Error.WriteLine("soundPlayer Empty");
        }

        int currentSeed = SeedGenerator.GetGeneratedSeed();
        GUIUtility.systemCopyBuffer = currentSeed.ToString();
        Debug.Log("Seed copiée dans le presse-papiers : " + currentSeed);
    }

    public void onHoverButton()
    {
        // play sound
        if (soundPlayer != null)
        {
            soundPlayer.PlaySoundEffect(hoverButton);
        }
        else
        {
            Console.Error.WriteLine("soundPlayer Empty");
        }
    }
}
