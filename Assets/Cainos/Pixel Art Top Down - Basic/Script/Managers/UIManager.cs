using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public PauseMenu pauseMenu;

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

    public bool isPaused = false;

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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                pauseMenu.Resume();
            }
            else
            {
                pauseMenu.Pause();
            }
        }
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
        yield return new WaitForSeconds(7f);
        itemObtainedPopup.SetActive(false);

        // display next popup
        ShowNextPopup();
    }

    public void AddItemToScrollView(Sprite imageSprite, string name)
    {
        // instanciate new image in main ui
        GameObject popupObject = Instantiate(itemIconPrefab, contentRectTransform);

        Image imageComponent = popupObject.transform.GetChild(0).GetComponentInChildren<Image>();
        imageComponent.sprite = imageSprite;

        TextMeshProUGUI textComponent = popupObject.transform.GetChild(1).GetComponentInChildren<TextMeshProUGUI>();
        textComponent.text = name;
    }
}
