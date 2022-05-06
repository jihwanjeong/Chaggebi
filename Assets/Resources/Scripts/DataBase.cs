using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] public class CGBData
{
    //차깨비 외형 정보
    public bool isPlaced { get; set; } = false;
    public int age { get; set; } //진화단계
    public string base1 { get; set; } //몸색(1단계)
    public int base1vary { get; set; }
    public string base2 { get; set; } //스킨(2단계)
    public string flavor { get; set; } //맛(3단계)
    public string name { get; set; } = "차깨비";
    public string description { get; set; }
    public string teabagID { get; set; }
    public int mouth { get; set; }
    public int brow { get; set; }
    //public void UpdateAppearance(CGBData newCGB)
    //{
    //    isPlaced = newCGB.isPlaced;
    //    age = newCGB.age;
    //    base1 = newCGB.base1;
    //    base1vary = newCGB.base1vary;
    //    base2 = newCGB.base2;
    //    flavor = newCGB.flavor;
    //    name = newCGB.name;
    //    description = newCGB.description;
    //    teabag = newCGB.teabag;
    //    mouth = newCGB.mouth;
    //    brow = newCGB.brow;
    //}
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
    //싱글턴
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
        return AllTeabags[AllTeabags.FindIndex(x => x.id == _id)];
    }
    public Item FindItem(string _id)
    {
        return AllFoods[AllFoods.FindIndex(x => x.id == _id)];
    }

    void GetAllCgbDB()
    {
        string[] line = cgbDB.text.Substring(0, cgbDB.text.Length).Split('\n');
        for (int i = 0; i < line.Length; i++)
        {
            string[] row = line[i].Split('\t');
            AllCGBs.Add(new CGBData { age = Int16.Parse(row[0]), base1 = row[1], base2 = row[2], flavor = row[3], name = row[4], description = row[5], teabagID = row[6] });
            AllTeabags.Add(new Teabag { id = row[6], name = row[7], description = row[8], scent = Int16.Parse(row[9]), earthy = Int16.Parse(row[10]), sweet = Int16.Parse(row[11]), sour = Int16.Parse(row[12]) });
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
            { id = row[0], name = row[1], description = row[2], scent = Int16.Parse(row[3]), earthy = Int16.Parse(row[4]), sweet = Int16.Parse(row[5]), sour = Int16.Parse(row[6]), cost = Int16.Parse(row[7]) });
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
