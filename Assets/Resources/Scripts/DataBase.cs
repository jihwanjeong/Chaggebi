using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] public class CGBData
{
    //?????? ???? ????
    public bool isPlaced { get; set; } = false;
    public int age { get; set; } = 1; 
    public string type { get; set; }
    public bool isGrowPrepare { get; set; } = false;
    public string flavorPrepare { get; set; }
    //public int base1vary { get; set; }
    //public string base2 { get; set; } //??Ų(2?ܰ?)
    public string flavor { get; set; } = "none";
    public string name { get; set; } = "??????";
    public string customName { get; set; } = "?? ??????";
    public string description { get; set; }
    public string teabagID { get; set; }
    public int mouth { get; set; }
    public int brow { get; set; }
    //????
    public int fullRate { get; set; } = 50;
    public int cleanRate { get; set; } = 100;
    public int happyRate { get; set; } = 50;
    public int scent { get; set; }
    public int earthy { get; set; }
    public int sweet { get; set; }
    public int sour { get; set; }

    public CGBData GetCGB()
    {
        CGBData newCGB = new CGBData();
        newCGB.type = this.type;
        //newCGB.base1vary = this.base1vary;
        //newCGB.base2 = this.base2;
        newCGB.flavor = this.flavor;
        newCGB.name = this.name;
        newCGB.description = this.description;
        newCGB.teabagID = this.teabagID;
        return newCGB;
    }
}

[System.Serializable] public class Teabag
{
    public string id { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public int scent { get; set; }
    public int earthy { get; set; }
    public int sweet { get; set; }
    public int sour { get; set; }
    public int count_star1 { get; set; } = 0;
    public int count_star2 { get; set; } = 0;
    public int count_star3 { get; set; } = 0;
    public Sprite sprite;
}

[System.Serializable]public class Item
{
    public string id { get; set; }
    public string name { get; set; }
    public string type { get; set; }
    public string description { get; set; }
    public int scent { get; set; }
    public int earthy { get; set; }
    public int sweet { get; set; }
    public int sour { get; set; }
    public int cost { get; set; }
    public int count { get; set; } = 1;
    public Sprite sprite;
}

[System.Serializable]public class Customer
{
    public string id { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public int scent { get; set; }
    public int earthy { get; set; }
    public int sweet { get; set; }
    public int sour { get; set; }
    public int gold { get; set; }
    public int friendLv { get; set; } = 1;
    public int friendExp { get; set; } = 0;
    public string item_rare { get; set; }
    public string item_normal { get; set; }
    public Sprite sprite;
}


public class DataBase : MonoBehaviour
{
    #region SINGLETON
    //?̱???
    public static DataBase instance;
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
    public string diaName, goldName;
    public TextAsset cgbDB, customerDB, foodDB;
    public List<CGBData> AllCGBs;
    public List<Teabag> AllTeabags;
    public Sprite[] AllTeabagSprites;
    public List<Item> AllFoods;
    public Sprite[] AllFoodSprites;
    public List<Customer> AllCustomers;
    public Sprite[] AllCustomerSprites;

    void Start()
    {
        GetAllCgbDB();
        GetAllItemDB();
        GetAllCustomerDB();
    }

    public Teabag FindTeabag(string _id)
    {
        int i = AllTeabags.FindIndex(x => x.id == _id);
        Teabag teabag = new Teabag
        {
            id = AllTeabags[i].id,
            name = AllTeabags[i].name,
            description = AllTeabags[i].description,
            scent = AllTeabags[i].scent,
            earthy = AllTeabags[i].earthy,
            sweet = AllTeabags[i].sweet,
            sour = AllTeabags[i].sour,
            sprite = AllTeabags[i].sprite
        };
        return teabag;
    }
    public Item FindFood(string _id)
    {
        int i = AllFoods.FindIndex(x => x.id == _id);
        Item item = new Item
        {
            id = AllFoods[i].id,
            name = AllFoods[i].name,
            type = AllFoods[i].type,
            description = AllFoods[i].description,
            scent = AllFoods[i].scent,
            earthy = AllFoods[i].earthy,
            sweet = AllFoods[i].sweet,
            sour = AllFoods[i].sour,
            cost = AllFoods[i].cost,
            sprite = AllFoods[i].sprite
        };
        return item;
    }

    void GetAllCgbDB()
    {
        string[] line = cgbDB.text.Substring(0, cgbDB.text.Length).Split('\n');
        for (int i = 0; i < line.Length; i++)
        {
            string[] row = line[i].Split('\t');
            AllCGBs.Add(new CGBData { age = Int16.Parse(row[0]), type = row[1], flavor = row[2], name = row[3], description = row[4], teabagID = row[5] });
            AllTeabags.Add(new Teabag { id = row[5], name = row[6], description = row[7], scent = Int16.Parse(row[8]), earthy = Int16.Parse(row[9]), sweet = Int16.Parse(row[10]), sour = Int16.Parse(row[11]) });
            for (int j = 0; j < AllTeabagSprites.Length; j++)
            {
                if (AllTeabags[i].id == AllTeabagSprites[j].name)
                {
                    AllTeabags[i].sprite = AllTeabagSprites[j];
                    break;
                }
            }
        }
    }
    void GetAllItemDB()
    {
        string[] line = foodDB.text.Substring(0, foodDB.text.Length).Split('\n');
        for (int i = 0; i < line.Length; i++)
        {
            string[] row = line[i].Split('\t');
            AllFoods.Add(new Item
            { id = row[0], name = row[1], type = row[2], description = row[3], scent = Int16.Parse(row[4]), earthy = Int16.Parse(row[5]), sweet = Int16.Parse(row[6]), sour = Int16.Parse(row[7]), cost = Int16.Parse(row[8]) });
            for (int j = 0; j < AllFoodSprites.Length; j++)
            {
                if (AllFoods[i].id == AllFoodSprites[j].name)
                {
                    AllFoods[i].sprite = AllFoodSprites[j];
                    break;
                }
            }
        }
    }
    void GetAllCustomerDB()
    {
        string[] line = customerDB.text.Substring(0, customerDB.text.Length).Split('\n');
        for (int i = 0; i < line.Length; i++)
        {
            string[] row = line[i].Split('\t');
            AllCustomers.Add(new Customer
            {
                id = row[0],
                name = row[1],
                description = row[2],
                scent = Int16.Parse(row[3]),
                earthy = Int16.Parse(row[4]),
                sweet = Int16.Parse(row[5]),
                sour = Int16.Parse(row[6]),
                gold = Int16.Parse(row[7]),
                item_rare = row[8],
                item_normal = row[9]
            });
            for (int j = 0; j < AllCustomerSprites.Length; j++)
            {
                if (AllCustomers[i].id == AllCustomerSprites[j].name)
                {
                    AllCustomers[i].sprite = AllCustomerSprites[j];
                    break;
                }
            }
        }
    }
}
