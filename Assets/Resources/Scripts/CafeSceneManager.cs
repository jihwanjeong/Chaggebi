using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CafeSceneManager : MonoBehaviour
{
    public GameObject MenuPanel;
    public GameObject ManagePanel;
    public GameObject TeabagsInventory;
    public GameObject Orderlist;


    public void MenuEnable()
    {
        if (MenuPanel.activeSelf == false)
            MenuPanel.SetActive(true);
        else
            MenuPanel.SetActive(false);

    }
    public void ManageEnable()
    {
        if (ManagePanel.activeSelf == false)
            ManagePanel.SetActive(true);
        else
            ManagePanel.SetActive(false);

    }
    public void TeabagsEnable()
    {
        if (TeabagsInventory.activeSelf == false)
            TeabagsInventory.SetActive(true);
        else
            TeabagsInventory.SetActive(false);

    }
    public void OrdersEnable()
    {
        if (Orderlist.activeSelf == false)
            Orderlist.SetActive(true);
        else
            Orderlist.SetActive(false);

    }
    public void MoveToGarden()
    {
        SceneManager.LoadScene("Main Garden");
    }
    public void MoveToMini()
    {
        SceneManager.LoadScene("Minigame");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
