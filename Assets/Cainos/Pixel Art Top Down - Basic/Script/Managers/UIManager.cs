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
    public TextMeshProUGUI popupNumberText;
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


    public void ShowItemObtainedPopup(string itemName, string itemDescription, Sprite itemIcon, int currentPopup, int maxPopup)
    {
        PopupQueueItem popupItem = new PopupQueueItem
        {
            itemName = itemName,
            itemDescription = itemDescription,
            itemIcon = itemIcon,
            popupNumberCurrent = currentPopup,
            popupNumberMax = maxPopup
        };

        // add element to the Queue
        popupQueue.Enqueue(popupItem);

        // already a popup displayed?
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

            // display information of the popup
            itemObtainedPopup.SetActive(true);
            itemNameText.text = nextPopup.itemName;
            itemDescriptionText.text = nextPopup.itemDescription;
            itemIconImage.sprite = nextPopup.itemIcon;
            popupNumberText.text = $"{nextPopup.popupNumberCurrent}/{nextPopup.popupNumberMax}";

            // wait to hide the popup
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

        // display next popup
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
