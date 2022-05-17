using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public Button invenBtn;
    public Transform slotsParent;
    public GameObject itemDetailPanel;
    public Image detailImage;
    public Text detailName;
    public Text detailDescription;

    ItemSlot[] slots;
    Button[] slotBtns;

    public void Test_GiveItem(string id)
    {
        PlayerData.instance.AddItem(id, 1);
    }
    void Start()
    {
        invenBtn.onClick.AddListener(UpdateInven);
        slots = slotsParent.GetComponentsInChildren<ItemSlot>();
        slotBtns = new Button[slots.Length];
        for (int i = 0; i < slots.Length; i++)
        {
            slotBtns[i] = slots[i].gameObject.GetComponent<Button>();
            int index = i;
            slotBtns[i].onClick.AddListener(() => ViewItemDetail(index));
        }
    }
    void UpdateInven()
    {
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

    void ViewItemDetail(int i)
    {
        detailImage.sprite = slots[i].item.sprite;
        detailName.text = slots[i].item.name;
        detailDescription.text = slots[i].item.description;
        itemDetailPanel.SetActive(true);
    }
}
