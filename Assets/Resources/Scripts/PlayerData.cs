using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

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
    public List<Item> playerFoods = new List<Item>();
    public CGBData interactingCGB = new CGBData();
    public SkeletonAnimation interactingSk;
    public void AddItem(string _id, int _count)
    {
        for (int i = 0; i < playerFoods.Count; i++)
        {
            if (playerFoods[i].id == _id)
            {
                playerFoods[i].count += _count;
                return;
            }
        }
        playerFoods.Add(DataBase.instance.FindFood(_id));
    }

    public void RemoveItem(string _id, int _count)
    {
        for (int i = 0; i < playerFoods.Count; i++)
        {
            if (playerFoods[i].id == _id)
            {
                playerFoods[i].count -= _count;
                if (playerFoods[i].count <= 0) playerFoods.Remove(playerFoods[i]);
                return;
            }
        }
    }
}
