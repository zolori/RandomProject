using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    private Queue<PopupQueueItem> popupQueue = new Queue<PopupQueueItem>();
    private bool isPopupShowing = false;

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
        PopupQueueItem popupItem = new PopupQueueItem
        {
            itemName = itemName,
            itemDescription = itemDescription,
            itemIcon = itemIcon
        };

        // Ajoutez l'élément à la file d'attente
        popupQueue.Enqueue(popupItem);

        // Vérifiez si un pop-up est déjà affiché
        if (!isPopupShowing)
        {
            ShowNextPopup();
        }
    }

    private void ShowNextPopup()
    {
        if (popupQueue.Count > 0)
        {
            PopupQueueItem nextPopup = popupQueue.Dequeue();
            isPopupShowing = true;

            // Affichez le pop-up avec les informations de nextPopup
            itemObtainedPopup.SetActive(true);
            itemNameText.text = nextPopup.itemName;
            itemDescriptionText.text = nextPopup.itemDescription;
            itemIconImage.sprite = nextPopup.itemIcon;

            // Commencez une coroutine pour masquer le pop-up après un certain temps
            StartCoroutine(HideItemObtainedPopup());
        }
        else
        {
            isPopupShowing = false;
        }
    }

    IEnumerator HideItemObtainedPopup()
    {
        yield return new WaitForSeconds(3f);
        itemObtainedPopup.SetActive(false);

        // Affichez le prochain pop-up dans la file d'attente
        ShowNextPopup();
    }

    public void AddImageToScrollView(Sprite imageSprite)
    {
        // instanciate new image in main ui
        GameObject imageObject = Instantiate(itemIconPrefab, contentRectTransform);

        Image imageComponent = imageObject.GetComponent<Image>();
        imageComponent.sprite = imageSprite;
    }
}
