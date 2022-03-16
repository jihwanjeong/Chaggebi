using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeacupPanelManager : MonoBehaviour
{
    public GameObject TeabagWarningPopup;
    public GameObject CGBGachaPopup;
    GameObject CGBCard;
    public GameObject CGBCardPF;
    GameObject TempCGB;
    public GameObject CGBInventory;
    public GameObject GachaCGB; //»ÌÀº Â÷±úºñ
    public GameObject GachaCGBPlace;
    GameObject gachaCGB;
    public Button GachaClose;
    public Text RemainTeabags;
    public Text CGBInfo;
    public Button useTeabag;
    private int Teabags = 100;
    private static int[] arr = new int[5];
    
    public void RandomCGBOutfit() 
    {
        int temp;
        int i;
  
        for (i = 0; i < 4; i++)
        {
            switch (i)
            {
                case 0:
                    System.Random rand1 = new System.Random();
                    temp = rand1.Next(1, 3);
                    arr[i] = temp;
                    break;
                case 1:
                    System.Random rand2 = new System.Random();
                    temp = rand2.Next(1, 4);
                    arr[i] = temp;
                    break;
                case 2:
                    System.Random rand3 = new System.Random();
                    temp = rand3.Next(1, 3);
                    arr[i] = temp;
                    break;
                case 3:
                    System.Random rand4 = new System.Random();
                    temp = rand4.Next(1, 5);
                    arr[i] = temp;
                    break;
               

            }

        }
        switch (arr[0])
        {
            case 1:
                GachaCGB.GetComponent<CGBAppearanceManager>().type = CGBAppearanceManager.skins.baby;
                break;
            case 2:
                GachaCGB.GetComponent<CGBAppearanceManager>().type = CGBAppearanceManager.skins.baby;
                break;
           
    
        }
    
        switch (arr[1])
        {
            case 1:
                GachaCGB.GetComponent<CGBAppearanceManager>().brow = 1;
                break;
            case 2:
                GachaCGB.GetComponent<CGBAppearanceManager>().brow = 2;
                break;
            case 3:
                GachaCGB.GetComponent<CGBAppearanceManager>().brow = 3;
                break;

        }
        switch (arr[2])
        {
            case 1:
                GachaCGB.GetComponent<CGBAppearanceManager>().mouth = 1;
                break;
            case 2:
                GachaCGB.GetComponent<CGBAppearanceManager>().mouth = 2;
                break;

        }
        
        switch (arr[3])
        { 
        

            case 1:
                GachaCGB.GetComponent<CGBAppearanceManager>().bodyColor = CGBAppearanceManager.colors.brown;
                CGBCard.transform.SetParent(CGBInventory.transform, false);
                CGBInfo.GetComponent<Text>().text = "Ä¿ÇÇ Â÷±úºñ";
                CGBCard = Instantiate(CGBCardPF) as GameObject;
                TempCGB = Instantiate(GachaCGB, new Vector3(1f, 1f, 1f), Quaternion.identity);
                TempCGB.transform.localScale = new Vector3(50f, 50f, 50f);
                CGBCard.transform.SetParent(CGBInventory.transform, false);
                TempCGB.transform.SetParent(CGBCard.transform, false);
                break;
            case 2:
                GachaCGB.GetComponent<CGBAppearanceManager>().bodyColor = CGBAppearanceManager.colors.red;
                CGBInfo.GetComponent<Text>().text = "µþ±â Â÷±úºñ";
                CGBCard = Instantiate(CGBCardPF) as GameObject;
                TempCGB = Instantiate(GachaCGB, new Vector3(1f, 1f, 1f), Quaternion.identity);
                TempCGB.transform.localScale = new Vector3(50f, 50f, 50f);
                CGBCard.transform.SetParent(CGBInventory.transform, false);
                TempCGB.transform.SetParent(CGBCard.transform, false);
                break;
            case 3:
                GachaCGB.GetComponent<CGBAppearanceManager>().bodyColor = CGBAppearanceManager.colors.green;
                CGBInfo.GetComponent<Text>().text = "³ìÂ÷ Â÷±úºñ";
                CGBCard = Instantiate(CGBCardPF) as GameObject;
                TempCGB = Instantiate(GachaCGB, new Vector3(1f, 1f, 1f), Quaternion.identity);
                TempCGB.transform.localScale = new Vector3(50f, 50f, 50f);
                CGBCard.transform.SetParent(CGBInventory.transform, false);
                TempCGB.transform.SetParent(CGBCard.transform, false);
                break;
            case 4:
                GachaCGB.GetComponent<CGBAppearanceManager>().bodyColor = CGBAppearanceManager.colors.yellow;
                CGBInfo.GetComponent<Text>().text = "È«Â÷ Â÷±úºñ";
                CGBCard = Instantiate(CGBCardPF) as GameObject;
                TempCGB = Instantiate(GachaCGB,new Vector3(1f, 1f, 1f), Quaternion.identity);
                TempCGB.transform.localScale = new Vector3(50f, 50f, 50f);
                CGBCard.transform.SetParent(CGBInventory.transform, false);
                TempCGB.transform.SetParent(CGBCard.transform, false);
                break;

        }
        gachaCGB = Instantiate(GachaCGB) as GameObject;
        gachaCGB.transform.SetParent(GachaCGBPlace.transform, false);
        
    }
    public void UseTeabags()
    {
        if (CGBGachaPopup.activeSelf == false)
        {
            if (Teabags >= 1)
            {
                RandomCGBOutfit();
                CGBGachaPopup.SetActive(true);
                Teabags -= 1;
            }
            else
            {
                TeabagWarningPopup.SetActive(true);
                Invoke("Disablewarning", 1);
            }

        }
    }
    public void Disablewarning()
    {
        TeabagWarningPopup.SetActive(false);
    }
    public void DisableGachaPopup()
    {
        Destroy(gachaCGB);
        CGBGachaPopup.SetActive(false);
    }
    void Start()
    {
        useTeabag.onClick.AddListener(UseTeabags);
        GachaClose.onClick.AddListener(DisableGachaPopup);
    }


    void Update()
    {
        
        RemainTeabags.GetComponent<Text>().text = "    x " + Teabags.ToString();
        
    }
}
