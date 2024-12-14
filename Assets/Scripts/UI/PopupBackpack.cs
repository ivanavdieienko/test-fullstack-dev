using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupBackpack : Popup
{
    [SerializeField]
    private Image toyIcon;

    [SerializeField]
    private Image foodIcon;

    [SerializeField]
    private Image drinkIcon;

    private readonly Dictionary<ItemType, Image> images = new();

    public override PopupType PopupType => PopupType.Backpack;

    private void Start()
    {
        images[ItemType.Toy] = toyIcon;
        images[ItemType.Food] = foodIcon;
        images[ItemType.Drink] = drinkIcon;
    }

    public void AddItem(ItemType type, ItemUi item)
    {
        if (!images.ContainsKey(type))
        {
            images[type].sprite = item.Sprite;
        }
    }

    public void RemoveItem(ItemType type)
    {
        images[type].sprite = null;
    }
}