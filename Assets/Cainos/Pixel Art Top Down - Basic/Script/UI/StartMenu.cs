using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public TMP_InputField seedInputField;

    public SoundPlayer soundPlayer;

    public AudioClip hoverButton;
    public AudioClip typingText;
    public AudioClip clickButton;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void PlayButtonClicked()
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

        // did user asked for a precise seed?
        if (!string.IsNullOrEmpty(seedInputField.text))
        {
            int userSeed;
            if (int.TryParse(seedInputField.text, out userSeed))
            {
                SeedGenerator.SetUserEnteredSeed(userSeed);
            }
            else
            {
                // not a valid seed
                Debug.LogError("Seed invalide. Veuillez entrer un nombre entier.");
                return;
            }
        }

        PlayGame();
    }

    private void PlayGame()
    {
        Cursor.visible = false;

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.LogWarning("No next scene in the build settings.");
        }
    }

    public void QuitGame()
    {

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
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

    public void onTextChanging()
    {
        // play sound
        if (soundPlayer != null)
        {
            soundPlayer.PlaySoundEffect(typingText);
        }
        else
        {
            Console.Error.WriteLine("soundPlayer Empty");
        }
    }
}