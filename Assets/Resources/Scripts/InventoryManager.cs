using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public Button invenBtn;
    public Button teabagBtn, foodBtn, toyBtn;
    public Transform slotsParent;
    public GameObject itemDetailPanel;
    public Image detailImage;
    public Text detailName;
    public Text detailDescription;
    public Text detailStat;
    category selectedCategory;
    enum category { teabag, food, toy};

    ItemSlot[] slots;
    Button[] slotBtns;

    public void Test_GiveItem(string id)
    {
        PlayerData.instance.AddFood(id, 3);
    }
    void Start()
    {
        invenBtn.onClick.AddListener(() => UpdateInven(category.teabag));
        teabagBtn.onClick.AddListener(() => UpdateInven(category.teabag));
        foodBtn.onClick.AddListener(() => UpdateInven(category.food));
        toyBtn.onClick.AddListener(() => UpdateInven(category.toy));
        slots = slotsParent.GetComponentsInChildren<ItemSlot>();
        slotBtns = new Button[slots.Length];
        for (int i = 0; i < slots.Length; i++)
        {
            slotBtns[i] = slots[i].gameObject.GetComponent<Button>();
            int index = i;
            slotBtns[i].onClick.AddListener(() => ViewItemDetail(index));
        }
    }
    void UpdateInven(category _category)
    {
        if(_category==category.teabag)
        {
            selectedCategory = category.teabag;
            int itemCount = PlayerData.instance.playerTeabags.Count;
            for (int i = 0; i < slots.Length; i++)
            {
                if (i < itemCount)
                {
                    slots[i].AddItem(PlayerData.instance.playerTeabags[i]);
                }
                else
                {
                    slots[i].RemoveItem();
                }
            }
        }
        if (_category == category.food)
        {
            selectedCategory = category.food;
            int itemCount = PlayerData.instance.playerFoods.Count;
            for (int i = 0; i < slots.Length; i++)
            {
                if (i < itemCount)
                {
                    slots[i].AddItem(PlayerData.instance.playerFoods[i]);
                }
                else
                {
                    slots[i].RemoveItem();
                }
            }
        }
        if (_category == category.toy) //임시.장난감만들면 작성
        {
            selectedCategory = category.toy;
            for (int i = 0; i < slots.Length; i++)
            {
                slots[i].RemoveItem();
            }
        }

    }

    void ViewItemDetail(int i)
    {
        if(selectedCategory==category.teabag)
        {
            detailImage.sprite = slots[i].teabag.sprite;
            detailName.text = slots[i].teabag.name;
            detailDescription.text = slots[i].teabag.description;
            detailStat.text = "달콤함 " + slots[i].teabag.scent + "   고소함 " + slots[i].teabag.earthy + "   달콤함 " + slots[i].teabag.sweet + "   상큼함 " + slots[i].teabag.sour;
        }
        else
        {
            detailImage.sprite = slots[i].item.sprite;
            detailName.text = slots[i].item.name;
            detailDescription.text = slots[i].item.description;
            detailStat.text = "달콤함 " + slots[i].item.scent + "   고소함 " + slots[i].item.earthy + "   달콤함 " + slots[i].item.sweet + "   상큼함 " + slots[i].item.sour;
        }
        itemDetailPanel.SetActive(true);
    }
}
