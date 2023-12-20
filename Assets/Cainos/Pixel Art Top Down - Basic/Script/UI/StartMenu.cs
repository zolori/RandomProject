using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public TMP_InputField seedInputField;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void PlayButtonClicked()
    {
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
        SceneManager.LoadScene("SC Pixel Art Top Down - Basic");
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}
