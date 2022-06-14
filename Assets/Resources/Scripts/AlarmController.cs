using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlarmController : MonoBehaviour
{
    public Sprite gold;
    public Sprite dia;
    public GameObject alarmPanel;
    public Text mainTxt;
    public Text subTxt;
    public GameObject subTxt_obj;
    public GameObject activeBtn;
    public Image resourceIcon;
    public Text costTxt;
    public Text confirmTxt;
    public Button closeBtn;
    public Button confirmBtn;
    Action confirmClicked;
    void Start()
    {
        closeBtn.onClick.AddListener(CloseAlarm);
        confirmBtn.onClick.AddListener(Confirmed);
        alarmPanel.SetActive(false);
    }
    public void OpenAlarm(string _main)
    {
        confirmClicked = null;
        activeBtn.SetActive(true);
        mainTxt.text = _main;
        subTxt_obj.SetActive(false);
        resourceIcon.enabled = false;
        costTxt.enabled = false;
        confirmTxt.enabled = true;
        closeBtn.gameObject.SetActive(false);
        alarmPanel.SetActive(true);
    }
    public void OpenAlarm(string _main, string _sub, Action _onClick)
    {
        confirmClicked = _onClick;
        activeBtn.SetActive(true);
        mainTxt.text = _main;
        if (_sub != "")
        {
            subTxt.text = _sub;
            subTxt_obj.SetActive(true);
        }
        else subTxt_obj.SetActive(false);
        resourceIcon.enabled = false;
        costTxt.enabled = false;
        confirmTxt.enabled = true;
        closeBtn.gameObject.SetActive(true);
        alarmPanel.SetActive(true);
    }
    public void OpenAlarm(int resourceType, string _main, string _sub, int _cost, Action _onClick)
    {
        confirmClicked = _onClick;
        mainTxt.text = _main;
        if (_sub != "")
        {
            subTxt.text = _sub;
            subTxt_obj.SetActive(true);
        }
        else subTxt_obj.SetActive(false);
        switch(resourceType)
        {
            case 0:
                resourceIcon.sprite = gold;
                if (_cost > PlayerData.instance.gold)
                {
                    activeBtn.SetActive(false);
                }
                else activeBtn.SetActive(true);
                break;
            case 1:
                resourceIcon.sprite = dia;
                if (_cost > PlayerData.instance.dia)
                {
                    activeBtn.SetActive(false);
                }
                else activeBtn.SetActive(true);
                break;
        }
        resourceIcon.enabled = true;
        costTxt.text = _cost.ToString();
        confirmTxt.enabled = false;
        closeBtn.gameObject.SetActive(true);
        alarmPanel.SetActive(true);
    }
    void Confirmed()
    {
        CloseAlarm();
        if (confirmClicked != null) confirmClicked.Invoke();
    }
    public void CloseAlarm()
    {
        alarmPanel.SetActive(false);
    }
}
