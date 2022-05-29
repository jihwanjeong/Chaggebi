using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public Image itemImage;
    public Text itemName;
    public Text itemCount;
    public GameObject selectedImg;
    public GameObject tierCount;
    public Text tier1, tier2, tier3;
    [HideInInspector] public Item item;
    [HideInInspector] public Teabag teabag;

    public void AddItem(Item _item)
    {
        item = _item;
        itemImage.sprite = item.sprite;
        itemName.text = item.name;
        itemCount.text = item.count.ToString();
        tierCount.SetActive(false);
        this.gameObject.SetActive(true);
    }
    public void AddItem(Teabag _teabag)
    {
        teabag = _teabag;
        itemImage.sprite = teabag.sprite;
        itemName.text = teabag.name;
        itemCount.text = "";
        tier1.text = teabag.count_star1.ToString();
        tier2.text = teabag.count_star2.ToString();
        tier3.text = teabag.count_star3.ToString();
        tierCount.SetActive(true);
        this.gameObject.SetActive(true);
    }
    public void RemoveItem()
    {
        itemName.text = "";
        itemCount.text = "";
        itemImage.sprite = null;
        teabag = null;
        item = null;
        tierCount.SetActive(false);
        this.gameObject.SetActive(false);
    }

    public void SelectActive(bool _b)
    {
        selectedImg.SetActive(_b);
    }
}
