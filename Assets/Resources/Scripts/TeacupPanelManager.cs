using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Spine;
using Spine.Unity;

public class TeacupPanelManager : MonoBehaviour
{
    public GameObject TeabagWarningPopup;
    public GameObject CGBGachaPopup;
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
    public GameObject TeabagUseButton;
    public SkeletonAnimation bgAnimation;
    public SkeletonAnimation CGBAnimation;
    CGBData cgbData = new CGBData();
    CGBSpineSetter cgbSpineUpdater;

    public void RandomCGBOutfit() 
    {
        //·£´ýÁ¤º¸¼³Á¤
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
                    temp = rand2.Next(1, 5);
                    arr[i] = temp;
                    break;
                case 2:
                    System.Random rand3 = new System.Random();
                    temp = rand3.Next(1, 4);
                    arr[i] = temp;
                    break;
                case 3:
                    System.Random rand4 = new System.Random();
                    temp = rand4.Next(1, 3);
                    arr[i] = temp;
                    break;


            }

        }
        switch (arr[0])
        {
            case 1:
                cgbData.skin = CGBData.skins.baby;
                break;
            case 2:
                cgbData.skin = CGBData.skins.baby;
                break;


        }
        switch (arr[1])
        {
            case 1:
                cgbData.bodyColor = CGBData.colors.brown;
                cgbData.name = "È«Â÷ Â÷±úºñ";
                cgbData.description = "Çâ±ßÇÑ È«Â÷ÇâÀÌ ³ª´Â Â÷±úºñ";
                CGBInfo.text = "È«Â÷ Â÷±úºñ";
                break;
            case 2:
                cgbData.bodyColor = CGBData.colors.red;
                cgbData.name = "µþ±â Â÷±úºñ";
                cgbData.description = "´ÞÄÞÇÑ µþ±âÇâÀÌ ³ª´Â Â÷±úºñ";
                CGBInfo.text = "µþ±â Â÷±úºñ";
                break;
            case 3:
                cgbData.bodyColor = CGBData.colors.green;
                cgbData.name = "³ìÂ÷ Â÷±úºñ";
                cgbData.description = "°í¼ÒÇÑ ³ìÂ÷ÇâÀÌ ³ª´Â Â÷±úºñ";
                CGBInfo.text = "³ìÂ÷ Â÷±úºñ";
                break;
            case 4:
                cgbData.bodyColor = CGBData.colors.yellow;
                cgbData.name = "·¹¸ó Â÷±úºñ";
                cgbData.description = "»óÅ­ÇÑ È«Â÷ÇâÀÌ ³ª´Â Â÷±úºñ";
                CGBInfo.text = "·¹¸ó Â÷±úºñ";
                break;

        }
        switch (arr[2])
        {
            case 1:
                cgbData.brow = 1;
                break;
            case 2:
                cgbData.brow = 2;
                break;
            case 3:
                cgbData.brow = 3;
                break;

        }
        switch (arr[3])
        {
            case 1:
                cgbData.mouth = 1;
                break;
            case 2:
                cgbData.mouth = 2;
                break;

        }

        //¿ÜÇüÁ¤º¸ Àû¿ë, ÀúÀå
        cgbSpineUpdater.SetAppearance(cgbData);
        PlayerData.instance.playerCGBs.Add(new CGBData
        {
            name = cgbData.name,
            description = cgbData.description,
            bodyColor = cgbData.bodyColor,
            brow = cgbData.brow,
            mouth = cgbData.mouth,
            skin = cgbData.skin
        });
    }
    public void UseTeabags()
    {
        if (CGBGachaPopup.activeSelf == false)
        {
            if (Teabags >= 1)
            {
                TeabagUseButton.SetActive(false);
                bgAnimation.AnimationState.SetAnimation(0, "use", false);
                bgAnimation.AnimationState.AddAnimation(0, "idle", true, 0f);
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
        GachaCGB.SetActive(false);
        CGBGachaPopup.SetActive(false);
        TeabagUseButton.SetActive(true);
        RemainTeabags.GetComponent<Text>().text = "    x " + Teabags.ToString();
    }

    //¹è°æ »Ì±â¾Ö´Ï ³¡³µÀ»¶§ ½ÇÇà
    void EventBG(TrackEntry trackEntry, Spine.Event e)
    {
        if (e.Data.Name == "cgb")
        {
            GachaCGB.SetActive(true);
            RandomCGBOutfit();
            CGBAnimation.AnimationState.SetAnimation(0, "summon", false);
            CGBAnimation.AnimationState.AddAnimation(0, "summon_idle", true,0f);
        }
        else if (e.Data.Name == "endBG")
        {
            CGBGachaPopup.SetActive(true);
            Teabags -= 1;
        }
    }
    ////Â÷±úºñ »Ì±â¾Ö´Ï ³¡³µÀ»¶§ ½ÇÇà
    //void EventCGB(TrackEntry trackEntry, Spine.Event e)
    //{
    //    CGBAnimation.AnimationState.SetAnimation(0, "summon_idle", true);
    //    if (e.Data.Name == "endCGB")
    //    {
    //        CGBGachaPopup.SetActive(true);
    //        Teabags -= 1;
    //    }
    //}

    void Start()
    {
        useTeabag.onClick.AddListener(UseTeabags);
        GachaClose.onClick.AddListener(DisableGachaPopup);
        cgbSpineUpdater = GachaCGB.GetComponent<CGBSpineSetter>();
        bgAnimation.AnimationState.Event += EventBG;
        //CGBAnimation.AnimationState.Event += EventCGB;
    }

    void Enabled()
    {
        
        RemainTeabags.GetComponent<Text>().text = "    x " + Teabags.ToString();
        
    }
}
