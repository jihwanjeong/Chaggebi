using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ShopItem
{
    public enum money { gold, dia }
    public enum type { gold, dia, food, toy }
    [System.Serializable] public class ItemStack
    {
        public type itemType;
        public string id;
        public int amount;
    }
    public money moneyType;
    public int price;
    public List<ItemStack> itemList = new List<ItemStack>();
}
public class ShopManager : MonoBehaviour
{
    public Sprite goldImg, diaImg;
    public AlarmController alarm;
    public ResourceAnimator resourceAnimator;
    public Button dailyRefreshBtn;
    public DailySlot[] dailySlots;
    public ShopSlot[] shopSlots;
    public GameObject getItemPanel;
    public Button getItemCloseBtn;
    public Image[] boughtItems;
    Text[] boughtItemNames;
    [Header("일일상점 아이템풀 설정--------------------------------")]
    public List<ShopItem> daily_freeList = new List<ShopItem>();
    public List<ShopItem> daily_List = new List<ShopItem>();
    void Start()
    {
        foreach (DailySlot slot in dailySlots) slot.buyBtn.onClick.AddListener(() => ClickBuy(slot));
        foreach (ShopSlot slot in shopSlots) slot.buyBtn.onClick.AddListener(() => ClickBuy(slot));
        dailyRefreshBtn.onClick.AddListener(RefreshDaily);
        boughtItemNames = new Text[boughtItems.Length];
        for (int i = 0; i < boughtItems.Length; i++)
        {
            boughtItemNames[i] = boughtItems[i].gameObject.GetComponentInChildren<Text>();
        }
        foreach(Image image in boughtItems) image.gameObject.SetActive(false);
        getItemPanel.SetActive(false);
        getItemCloseBtn.onClick.AddListener(CloseGetItemPanel);
    }

    void RefreshDaily()
    {
        dailySlots[0].SetItem(daily_freeList[Random.Range(0, daily_freeList.Count)]);
        for (int i = 1; i < dailySlots.Length; i++)
        {
            dailySlots[i].SetItem(daily_List[Random.Range(0, daily_List.Count)]);
        }
    }  
    
    void ClickBuy(DailySlot _slot)
    {
        if (_slot.shopItem.moneyType == ShopItem.money.gold)
        {
            if(_slot.shopItem.price <= PlayerData.instance.gold)
            {
                Buy(_slot);
                PlayerData.instance.SetGold(-_slot.shopItem.price);
            }
            else alarm.OpenAlarm("골드가 부족합니다!");
        }
        else if (_slot.shopItem.moneyType == ShopItem.money.dia)
        {
            if(_slot.shopItem.price <= PlayerData.instance.dia)
            {
                Buy(_slot);
                PlayerData.instance.SetDia(-_slot.shopItem.price);
            }
            else alarm.OpenAlarm("캔디가 부족합니다!");
        }
    }
    void ClickBuy(ShopSlot _slot)
    {
        if (_slot.shopItem.moneyType == ShopItem.money.gold)
        {
            if (_slot.shopItem.price <= PlayerData.instance.gold)
            {
                Buy(_slot);
                PlayerData.instance.SetGold(-_slot.shopItem.price);
            }
            else alarm.OpenAlarm("골드가 부족합니다!");
        }
        else if (_slot.shopItem.moneyType == ShopItem.money.dia)
        {
            if (_slot.shopItem.price <= PlayerData.instance.dia)
            {
                Buy(_slot);
                PlayerData.instance.SetDia(-_slot.shopItem.price);
            }
            else alarm.OpenAlarm("캔디가 부족합니다!");
        }
    }
    void Buy(DailySlot _slot)
    {
        foreach(ShopItem.ItemStack item in _slot.shopItem.itemList)
        {
            switch (item.itemType)
            {
                case ShopItem.type.food:
                    PlayerData.instance.AddFood(item.id, item.amount);
                    break;
                case ShopItem.type.dia:
                    PlayerData.instance.dia += item.amount;
                    break;
                case ShopItem.type.gold:
                    PlayerData.instance.gold += item.amount;
                    break;
            }
        }
        resourceAnimator.GetItem(_slot.itemImage.sprite, _slot.itemImage.transform);
    }
    void Buy(ShopSlot _slot)
    {
        for (int i = 0; i < _slot.shopItem.itemList.Count; i++)
        {
            boughtItems[i].gameObject.SetActive(true);
            switch (_slot.shopItem.itemList[i].itemType)
            {
                case ShopItem.type.gold:
                    PlayerData.instance.gold += _slot.shopItem.itemList[i].amount;
                    boughtItems[i].sprite = goldImg;
                    boughtItemNames[i].text = _slot.shopItem.itemList[i].amount.ToString();
                    break;
                case ShopItem.type.dia:
                    PlayerData.instance.dia += _slot.shopItem.itemList[i].amount;
                    boughtItems[i].sprite = diaImg;
                    boughtItemNames[i].text = _slot.shopItem.itemList[i].amount.ToString();
                    break;
                case ShopItem.type.food:
                    Item item = DataBase.instance.FindFood(_slot.shopItem.itemList[i].id);
                    PlayerData.instance.AddFood(item.id, _slot.shopItem.itemList[i].amount);
                    boughtItems[i].sprite = item.sprite;
                    boughtItemNames[i].text = item.name.ToString();
                    break;
            }

        }
        getItemPanel.SetActive(true);
    }
    public void CloseGetItemPanel()
    {
        foreach (Image image in boughtItems)
        {
            if(image.gameObject.activeSelf)
            {
                resourceAnimator.GetItem(image.sprite, image.transform);
                image.gameObject.SetActive(false);
            }
        }
        getItemPanel.SetActive(false);
    }
}
