using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public TMP_InputField seedInputField;

    public void PlayButtonClicked()
    {
        // Vérifiez si l'utilisateur a entré une seed
        if (!string.IsNullOrEmpty(seedInputField.text))
        {
            int userSeed;
            if (int.TryParse(seedInputField.text, out userSeed))
            {
                // Stockez la seed entrée par l'utilisateur dans le SeedGenerator
                SeedGenerator.SetUserEnteredSeed(userSeed);
            }
            else
            {
                // Affichez un message d'erreur si l'entrée n'est pas un nombre valide
                Debug.LogError("Seed invalide. Veuillez entrer un nombre entier.");
                return;
            }
        }

        // Charger la scène du jeu
        PlayGame();
    }

    private void PlayGame()
    {
        SceneManager.LoadScene("Map");
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
