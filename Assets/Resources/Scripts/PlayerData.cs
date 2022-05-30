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

    public int gold, dia;

    public List<CGBData> playerCGBs = new List<CGBData>();
    public List<Item> playerFoods = new List<Item>();
    public List<Teabag> playerTeabags = new List<Teabag>();

    public CGBData interactingCGB = new CGBData();
    public SkeletonAnimation interactingSk;
    [HideInInspector] public bool isRemoved;
    public void AddFood(string _id, int _count)
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
        playerFoods[playerFoods.Count-1].count = _count;
    }

    public void RemoveFood(string _id, int _count)
    {
        for (int i = 0; i < playerFoods.Count; i++)
        {
            if (playerFoods[i].id == _id)
            {
                if (playerFoods[i].count - _count < 0)
                {
                    Debug.Log("not enough items!");
                    isRemoved = false;
                    return;
                }
                else
                {
                    playerFoods[i].count -= _count;
                    if (playerFoods[i].count == 0) playerFoods.Remove(playerFoods[i]);
                    isRemoved = true;
                    return;
                }
            }
            else isRemoved = false;
        }
    }

    public void AddTeabag(string _id, int _count_star1, int _count_star2, int _count_star3)
    {
        for (int i = 0; i < playerTeabags.Count; i++)
        {
            if (playerTeabags[i].id == _id)
            {
                playerTeabags[i].count_star1 += _count_star1;
                playerTeabags[i].count_star2 += _count_star2;
                playerTeabags[i].count_star3 += _count_star3;
                return;
            }
        }
        playerTeabags.Add(DataBase.instance.FindTeabag(_id));
        int j = playerTeabags.Count-1;
        playerTeabags[j].count_star1 = _count_star1;
        playerTeabags[j].count_star2 = _count_star2;
        playerTeabags[j].count_star3 = _count_star3;
    }

    public void RemoveTeabag(string _id, int _count_star1, int _count_star2, int _count_star3)
    {
        for (int i = 0; i < playerTeabags.Count; i++)
        {
            if (playerTeabags[i].id == _id)
            {
                if(playerTeabags[i].count_star1 - _count_star1 < 0 || playerTeabags[i].count_star2 - _count_star2 < 0 || playerTeabags[i].count_star3 - _count_star3 < 0)
                {
                    Debug.Log("not enough teabags!");
                    isRemoved = false;
                    return;
                }
                else
                {
                    playerTeabags[i].count_star1 -= _count_star1;
                    playerTeabags[i].count_star2 -= _count_star2;
                    playerTeabags[i].count_star3 -= _count_star3;
                    if (playerTeabags[i].count_star1 + playerTeabags[i].count_star2 + playerTeabags[i].count_star3 == 0) playerTeabags.Remove(playerTeabags[i]);
                    isRemoved = true;
                    return;
                }              
            }
            else isRemoved = false;
        }
    }

}
