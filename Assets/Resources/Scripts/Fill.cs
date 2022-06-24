using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Fill : MonoBehaviour
{
    public float totalTime;
    public float fillAmount = 1;
    public Image myImage;
    public GameObject Order33;

    private void Awake()
    {
        myImage = GetComponent<Image>();
    }

    void Update()
    {
        if (fillAmount > 0)
        {
            fillAmount = fillAmount - (Time.deltaTime / (totalTime - 1));
            myImage.fillAmount = fillAmount;
            Order33.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/cup3_filled") as Sprite;
        }
    }
}