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
    //public GameObject GachaCGBPlace;
    //GameObject gachaCGB;
    public Button GachaClose;
    public Text RemainTeabags;
    public Text CGBInfo;
    public Button useTeabag;
    private int Teabags = 100;
    private static int[] arr = new int[5];
    public GameObject TeabagUseButton;
    public SkeletonAnimation bgAnimation;
    public SkeletonAnimation CGBAnimation;
    List<CGBData> babyCGBs = new List<CGBData>();
    CGBData newCgb = new CGBData();
    CGBSpineSetter spineSetter;

    void ListUpBabies()
    {
        foreach (CGBData cgb in DataBase.instance.AllCGBs)
        {
            if (cgb.age == 1) babyCGBs.Add(cgb);
        }
    }
    public void RandomCGBOutfit() 
    {
        newCgb = babyCGBs[Random.Range(0, babyCGBs.Count)];
        newCgb.brow = Random.Range(1, spineSetter.browCount + 1);
        newCgb.mouth = Random.Range(1, spineSetter.mouthCount + 1);
        newCgb.base1vary = Random.Range(1, spineSetter.baseVaryCount + 1);
        CGBInfo.text = newCgb.name;
        spineSetter.SetAppearance(newCgb, CGBAnimation);
        PlayerData.instance.playerCGBs.Add(newCgb);
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

    void Start()
    {
        useTeabag.onClick.AddListener(UseTeabags);
        GachaClose.onClick.AddListener(DisableGachaPopup);
        bgAnimation.AnimationState.Event += EventBG;
        spineSetter = GameObject.Find("CGBSpineManager").GetComponent<CGBSpineSetter>();
        ListUpBabies();
    }

    void Enabled()
    {
        
        RemainTeabags.GetComponent<Text>().text = "    x " + Teabags.ToString();
        
    }
}
