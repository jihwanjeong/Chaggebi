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
    public AlarmController alarm;
    public Button dailyRefreshBtn;
    public DailySlot[] dailySlots;
    public ShopSlot[] shopSlots;
    [Header("일일상점 아이템풀 설정--------------------------------")]
    public List<ShopItem> daily_freeList = new List<ShopItem>();
    public List<ShopItem> daily_List = new List<ShopItem>();

    void Start()
    {
        foreach (DailySlot slot in dailySlots) slot.buyBtn.onClick.AddListener(() => ClickBuy(slot.shopItem));
        foreach (ShopSlot slot in shopSlots) slot.buyBtn.onClick.AddListener(() => ClickBuy(slot.shopItem));
        dailyRefreshBtn.onClick.AddListener(RefreshDaily);
    }

    void RefreshDaily()
    {
        dailySlots[0].SetItem(daily_freeList[Random.Range(0, daily_freeList.Count)]);
        for (int i = 1; i < dailySlots.Length; i++)
        {
            dailySlots[i].SetItem(daily_List[Random.Range(0, daily_List.Count)]);
        }
    }

    void ClickBuy(ShopItem shopItem)
    {
        if (shopItem.moneyType == ShopItem.money.gold)
        {
            if(shopItem.price <= PlayerData.instance.gold)
            {
                Buy(shopItem);
                PlayerData.instance.gold -= shopItem.price;
            }
            else alarm.OpenAlarm("골드가 부족합니다!");
        }
        else if (shopItem.moneyType == ShopItem.money.dia)
        {
            if(shopItem.price <= PlayerData.instance.dia)
            {
                Buy(shopItem);
                PlayerData.instance.dia -= shopItem.price;
            }
            else alarm.OpenAlarm("캔디가 부족합니다!");
        }
    }
    void Buy(ShopItem shopItem)
    {
        foreach(ShopItem.ItemStack item in shopItem.itemList)
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
    }
}
