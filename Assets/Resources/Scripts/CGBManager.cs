using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CGBManager : MonoBehaviour
{
   
    public GameObject CGBManage;
    public void OpenManager()
    {
        if (CGBManage.activeSelf == false)
            CGBManage.SetActive(true);
        else
            CGBManage.SetActive(false);

    }
    

}
