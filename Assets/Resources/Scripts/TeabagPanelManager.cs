using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeabagPanelManager : MonoBehaviour
{
    public Image image;
    public Button button;
    public Button Next;
    public Button Extract;
    public Text Result;
    public float coolTime = 10.0f;
    public bool isClicked = false;
    float leftTime = 10.0f;
    float speed = 5.0f;

    void Update()
    {
        if (isClicked)
            if (leftTime > 0)
            {
                leftTime -= Time.deltaTime * speed;
                if (leftTime < 0)
                {
                    leftTime = 0;
                    if (button) button.enabled = true;
                    isClicked = true;
                }
                float ratio = 1.0f - (leftTime / coolTime);
                if (image) image.fillAmount = ratio;
            }

        if (((image.fillAmount < 0.695 && isClicked == false) && image.fillAmount > 0.1) || (image.fillAmount > 0.838 && isClicked == false))
        {
            Result.text = "실패..";
           
        }
        else if ((image.fillAmount > 0.695 && isClicked == false) && (image.fillAmount < 0.838 && isClicked == false))
        {
            Result.text = "성공!";
            Next.gameObject.SetActive(true);
            Extract.gameObject.SetActive(false);
        }
        else
            Result.text = "";
    }
    public void StartCoolTime()
    {
        leftTime = coolTime; 
        if(isClicked == true )
            isClicked = false; 
        else
            isClicked = true;
        if (button) button.enabled = false; 



    }
}
