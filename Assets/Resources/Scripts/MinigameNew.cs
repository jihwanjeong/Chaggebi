using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MinigameNew : MonoBehaviour
{
    public Button Cup1;
    public Button Cup2;
    public Button Cup3;
    public Button Next;
    public Button Order1;
    //public Button Order2;
    //public Button Order3;
    public Text Selected;
    public GameObject CupPanel;
    public GameObject TeabagPanel;
    public GameObject OrderPanel;
    public Image Cupimage;
    public Image Cupimage2;



    public int CupSel = 0;
    public int CupResult = 0;

    public void SelectCup1()
    {
        Selected.text = "1???? ???õ?";
        CupSel = 1;

    }
    public void SelectCup2()
    {
        Selected.text = "2???? ???õ?";
        CupSel = 2;

    }
    public void SelectCup3()
    {
        Selected.text = "3???? ???õ?";
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
            Selected.text = "???? ?????ÿ?";

    }
    public void OrderPanelControl()
    {
        if (OrderPanel.activeSelf == true)
            OrderPanel.SetActive(false);
        else
            OrderPanel.SetActive(true);

    }
    public void TeabagCupSelOrder1()
    {
        if (CupSel == 0)
        {
            Order1.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/cup1") as Sprite;
        }
        else if (CupSel == 1)

        {
            Order1.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/cup1") as Sprite;

        }
        else if (CupSel == 2)
        {
            Order1.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/cup2") as Sprite;
        }

        else if (CupSel == 3)
        {
            Order1.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/cup3") as Sprite;
        }


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


    void Start()
    {
        Cup1.onClick.AddListener(SelectCup1);
        Cup2.onClick.AddListener(SelectCup2);
        Cup3.onClick.AddListener(SelectCup3);
        Next.onClick.AddListener(ResultCup);
    }


    void Update()
    {


    }
}
