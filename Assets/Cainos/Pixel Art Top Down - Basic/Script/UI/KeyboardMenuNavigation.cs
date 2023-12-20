using UnityEngine;
using UnityEngine.UI;

public class KeyboardMenuNavigation : MonoBehaviour
{
    public Selectable[] menuItems;
    private int selectedIndex = 0;

    void Update()
    {
        // Détection des touches du clavier (par exemple, flèches gauche et droite)
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            NavigateLeft();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            NavigateRight();
        }
    }

    void NavigateLeft()
    {
        // Décrémentez l'index sélectionné
        selectedIndex = (selectedIndex - 1 + menuItems.Length) % menuItems.Length;

        // Sélectionnez le bouton correspondant
        menuItems[selectedIndex].Select();
    }

    void NavigateRight()
    {
        // Incrémentez l'index sélectionné
        selectedIndex = (selectedIndex + 1) % menuItems.Length;

        // Sélectionnez le bouton correspondant
        menuItems[selectedIndex].Select();
    }
}
