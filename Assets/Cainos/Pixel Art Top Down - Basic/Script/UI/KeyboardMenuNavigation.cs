using UnityEngine;
using UnityEngine.UI;

public class KeyboardMenuNavigation : MonoBehaviour
{
    public Selectable[] menuItems;
    private int selectedIndex = 0;

    void Update()
    {
        // D�tection des touches du clavier (par exemple, fl�ches gauche et droite)
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
        // D�cr�mentez l'index s�lectionn�
        selectedIndex = (selectedIndex - 1 + menuItems.Length) % menuItems.Length;

        // S�lectionnez le bouton correspondant
        menuItems[selectedIndex].Select();
    }

    void NavigateRight()
    {
        // Incr�mentez l'index s�lectionn�
        selectedIndex = (selectedIndex + 1) % menuItems.Length;

        // S�lectionnez le bouton correspondant
        menuItems[selectedIndex].Select();
    }
}
