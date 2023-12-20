using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndMenu : MonoBehaviour
{
    public SoundPlayer soundPlayer;
    public AudioClip hoverButton;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
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
            Debug.LogWarning("soundPlayer Empty");
        }
    }
}