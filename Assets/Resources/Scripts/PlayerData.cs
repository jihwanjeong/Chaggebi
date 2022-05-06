using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    #region SINGLETON
    //╫л╠шео
    public static PlayerData instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }
    #endregion

    public List<CGBData> playerCGBs = new List<CGBData>();
    public List<Item> playerItems = new List<Item>();

    public void AddItem(string _id, int _count)
    {
        for (int i = 0; i < playerItems.Count; i++)
        {
            if (playerItems[i].id == _id)
            {
                playerItems[i].count += _count;
                return;
            }
        }
        playerItems.Add(DataBase.instance.FindItem(_id));
    }
}
