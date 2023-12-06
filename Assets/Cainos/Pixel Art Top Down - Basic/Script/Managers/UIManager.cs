using System.Collections;
using TMPro;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject itemObtainedPopup;
    public TextMeshProUGUI itemNameText;
    public TextMeshProUGUI itemDescriptionText;
    public Image itemIconImage;

    public GameObject itemIconPrefab;
    public ScrollRect scrollRect;
    private RectTransform contentRectTransform;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        contentRectTransform = scrollRect.content;

    }

    public void ShowItemObtainedPopup(string itemName, string itemDescription, Sprite itemIcon)
    {
        // display item's info
        itemObtainedPopup.SetActive(true);
        itemNameText.text = itemName;
        itemDescriptionText.text = itemDescription;
        itemIconImage.sprite = itemIcon;

        // hide popup after some time
        StartCoroutine(HideItemObtainedPopup());
    }

    IEnumerator HideItemObtainedPopup()
    {
        yield return new WaitForSeconds(3f);
        itemObtainedPopup.SetActive(false);
    }

    public void AddImageToScrollView(Sprite imageSprite)
    {
        // instanciate new image in main ui
        GameObject imageObject = Instantiate(itemIconPrefab, contentRectTransform);

        Image imageComponent = imageObject.GetComponent<Image>();
        imageComponent.sprite = imageSprite;
    }
}
