using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public Image itemImage;
    public Text itemName;
    public Text itemCount;
    [HideInInspector] public Item item;

    public void AddItem(Item _item)
    {
        item = _item;
        itemImage.sprite = item.sprite;
        itemName.text = item.name;
        itemCount.text = item.count.ToString();
        this.gameObject.SetActive(true);
    }
    public void RemoveItem()
    {
        itemName.text = "";
        itemCount.text = "";
        itemImage.sprite = null;
        this.gameObject.SetActive(false);
    }
}
