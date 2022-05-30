using UnityEngine;
using UnityEngine.UI;

public class DailySlot : MonoBehaviour
{
    public Sprite gold, dia;
    public Image itemImage;
    public Text itemName;
    public Text itemPrice;
    public Text itemAmount;
    public Button buyBtn;
    [HideInInspector] public ShopItem shopItem;
    Item item;

    public void SetItem(ShopItem _item)
    {
        shopItem = _item;
        switch (shopItem.itemList[0].itemType)
        {
            case ShopItem.type.food:
                item = DataBase.instance.FindFood(shopItem.itemList[0].id);
                itemImage.sprite = item.sprite;
                itemName.text = item.name;                
                break;
            case ShopItem.type.dia:
                item = null;
                itemImage.sprite = dia;
                itemName.text = DataBase.instance.diaName;
                break;
            case ShopItem.type.gold:
                item = null;
                itemImage.sprite = gold;
                itemName.text = DataBase.instance.goldName;
                break;
        }
        if (shopItem.price > 0) itemPrice.text = shopItem.price.ToString();
        itemAmount.text = "x" + shopItem.itemList[0].amount.ToString();
    }
}
