using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGame : MonoBehaviour
{

    public Button Cup1;
    public Button Cup2;
    public Button Cup3;
    public Button Next;
    public Text Selected;
    public GameObject CupPanel;
    public GameObject TeabagPanel;
    //public GameObject CupinTeabag;
    public GameObject OrderPanel;
    public Image Cupimage;
    public Image Cupimage2;
    public GameObject B1, B2, B3;
    public GameObject if1, if2, if3;


    public int CupSel = 0;
    public int CupResult = 0;

    public void SelectCup1()
    {
        Selected.text = "1¹øÄÅ ¼±ÅÃµÊ";
        CupSel = 1;

    }
    public void SelectCup2()
    {
        Selected.text = "2¹øÄÅ ¼±ÅÃµÊ";
        CupSel = 2;

    }
    public void SelectCup3()
    {
        Selected.text = "3¹øÄÅ ¼±ÅÃµÊ";
        CupSel = 3;

    }

    public void ResultCup()
    {
        CupResult = CupSel;
        if (CupResult != 0)
        {
            CupPanel.SetActive(false);
            TeabagPanel.SetActive(true);
        }
        else
            Selected.text = "ÄÅÀ» °í¸£½Ã¿À";

    }
    public void OrderPanelControl()
    {
        if (OrderPanel.activeSelf == true)
            OrderPanel.SetActive(false);
        else
            OrderPanel.SetActive(true);

    }

    public void TeabagCupSel()
    {
        if (CupResult == 0)
        {
            Cupimage.sprite = Resources.Load<Sprite>("Images/cup1") as Sprite;
            Cupimage2.sprite = Resources.Load<Sprite>("Images/cup1") as Sprite;
        }
        else if (CupResult == 1)
            
        {
            Cupimage.sprite = Resources.Load<Sprite>("Images/cup1") as Sprite;
            Cupimage2.sprite = Resources.Load<Sprite>("Images/cup1") as Sprite;
        }
        else if (CupResult == 2)
        {
            Cupimage.sprite = Resources.Load<Sprite>("Images/cup2") as Sprite;
            Cupimage2.sprite = Resources.Load<Sprite>("Images/cup2") as Sprite;
        }

        else if (CupResult == 3)
        {
            Cupimage.sprite = Resources.Load<Sprite>("Images/cup3") as Sprite;
            Cupimage2.sprite = Resources.Load<Sprite>("Images/cup3") as Sprite;
        }


    }
    public void EnableB1()
    {
        B1.SetActive(true);
        B2.SetActive(false);
        B3.SetActive(false);
    }
    public void EnableB2()
    {
        B1.SetActive(false);
        B2.SetActive(true);
        B3.SetActive(false);
    }
    public void EnableB3()
    {
        B1.SetActive(false);
        B2.SetActive(false);
        B3.SetActive(true);
    }


    void Start()
    {
        Cup1.onClick.AddListener(SelectCup1);
        Cup2.onClick.AddListener(SelectCup2);
        Cup3.onClick.AddListener(SelectCup3);
        Next.onClick.AddListener(ResultCup);
    }


    void Update()
    {
        TeabagCupSel();
        if (B1.activeSelf == true)
        {
            if1.SetActive(true);
            if2.SetActive(false);
            if3.SetActive(false);

        }
        else if (B2.activeSelf == true)
        {
            if1.SetActive(false);
            if2.SetActive(true);
            if3.SetActive(false);

        }
        else if (B3.activeSelf == true)
        {
            if1.SetActive(false);
            if2.SetActive(false);
            if3.SetActive(true);

        }

    }
}
