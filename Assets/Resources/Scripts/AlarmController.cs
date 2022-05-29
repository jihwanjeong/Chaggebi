using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlarmController : MonoBehaviour
{
    public GameObject alarmPanel;
    public Text mainTxt;
    public Text subTxt;
    public GameObject subTxt_obj;
    public GameObject activeBtn;
    public GameObject cost;
    public Text costTxt;
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
        cost.SetActive(false);
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
        cost.SetActive(false);
        closeBtn.gameObject.SetActive(true);
        alarmPanel.SetActive(true);
    }
    public void OpenAlarm(string _main, string _sub, int _cost, Action _onClick)
    {
        confirmClicked = _onClick;
        mainTxt.text = _main;
        if (_sub != "")
        {
            subTxt.text = _sub;
            subTxt_obj.SetActive(true);
        }
        else subTxt_obj.SetActive(false);
        if (_cost > PlayerData.instance.gold)
        {
            activeBtn.SetActive(false);
        }
        else activeBtn.SetActive(true);
        costTxt.text = _cost.ToString();
        cost.SetActive(true);
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
