using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
    public OwnedItemsData.OwnedItem OwnedItem
    {
        get
        {
            return _ownedItem;
        }

        set
        {
            _ownedItem = value;
            bool isEmpty = null == _ownedItem;
            image.gameObject.SetActive(!isEmpty);
            number.gameObject.SetActive(!isEmpty);
            _button.interactable = !isEmpty;

            if (!isEmpty)
            {
                image.sprite = itemSprites.First(x => x.itemType == _ownedItem.Type).sprite;
                number.text = _ownedItem.Number.ToString();
            }
        }
    }

    [SerializeField] private ItemTypeSpriteMap[] itemSprites;
    [SerializeField] private Image image;
    [SerializeField] private Text number;
    private Button _button;
    private OwnedItemsData.OwnedItem _ownedItem;
    
    void Awake()
    {
        _button = GetComponent<Button>();
    }

    [Serializable]
    public class ItemTypeSpriteMap
    {
        public Item.ItemType itemType;
        public Sprite sprite;
    }
}
