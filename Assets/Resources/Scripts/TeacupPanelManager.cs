using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeacupPanelManager : MonoBehaviour
{
    public GameObject TeabagWarningPanel;
    public Text RemainTeabags;
    public Sprite chaggebi1;
    public Sprite chaggebi2;
    public Sprite chaggebi3;
    public Button useTeabag;
    public int Teabags = 3;

    public void UseTeabags()
    {
        if (Teabags >= 1)
            Teabags -= 1;
        else
        {
            TeabagWarningPanel.SetActive(true);
            Invoke("Disablewarning", 1);
        }
    
    }
    public void Disablewarning()
    {
        TeabagWarningPanel.SetActive(false);
    }
    void Start()
    {
        useTeabag.onClick.AddListener(UseTeabags);
    }


    void Update()
    {
        
        RemainTeabags.GetComponent<Text>().text = "X " + Teabags.ToString();
    }
}
