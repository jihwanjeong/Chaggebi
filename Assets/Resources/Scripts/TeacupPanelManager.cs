using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Spine;
using Spine.Unity;

public class TeacupPanelManager : MonoBehaviour
{
    public int summonFoodCount;
    public GameObject foodAddBtnObject;
    public Button foodAddBtn;
    public GameObject foodImg;
    public Button closeFoodInvenBtn;
    public GameObject foodInven;
    public Transform foodSlotsParent;
    public GameObject useBtn;
    Image foodImg_img;
    ItemSlot[] slots;
    Button[] slotBtns;
    Item selectedItem;
    public GameObject CGBGachaPopup;
    //public GameObject CGBInventory;
    public GameObject GachaCGB; //»ÌÀº Â÷±úºñ
    //public Button PanelOpenBtn;
    public Button GachaClose;
    //public Text RemainTeabags;
    public Text CGBInfo;
    //public Button useTeabag;
    //private int Teabags = 100;
    //public GameObject TeabagUseButton;
    public SkeletonAnimation bgAnimation;
    public SkeletonAnimation CGBAnimation;
    public AlarmController alarm;
    List<CGBData> babyCGBs = new List<CGBData>();
    CGBSpineSetter spineSetter;

    void Start()
    {
        //useBtn.onClick.AddListener(SummonCgb);
        GachaClose.onClick.AddListener(DisableGachaPopup);
        foodAddBtn.onClick.AddListener(OpenFoodInven);
        closeFoodInvenBtn.onClick.AddListener(CloseFoodInven);
        //PanelOpenBtn.onClick.AddListener(UpdateTeabag);
        //bgAnimation.AnimationState.Event += EventBG;
        spineSetter = GameObject.Find("CGBSpineManager").GetComponent<CGBSpineSetter>();
        ListUpBabies();
        foodImg_img = foodImg.GetComponent<Image>();
        slots = foodSlotsParent.GetComponentsInChildren<ItemSlot>();
        slotBtns = new Button[slots.Length];
        for (int i = 0; i < slots.Length; i++)
        {
            slotBtns[i] = slots[i].gameObject.GetComponent<Button>();
            int index = i;
            slotBtns[i].onClick.AddListener(() => SelectItem(index));
        }
    }
    void CloseFoodInven()
    {
        foodInven.SetActive(false);
    }
    void OpenFoodInven()
    {
        foodInven.SetActive(true);
        useBtn.SetActive(false);
        int itemCount = PlayerData.instance.playerFoods.Count;
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].SelectActive(false);
            if (i < itemCount && PlayerData.instance.playerFoods[i].count >= summonFoodCount)
            {
                slots[i].AddItem(PlayerData.instance.playerFoods[i]);
            }
            else
            {
                slots[i].RemoveItem();
            }
        }
    }
    void SelectItem(int _i)
    {
        selectedItem = slots[_i].item;
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].SelectActive(i == _i);
        }
        useBtn.SetActive(true);
    }

    void ListUpBabies()
    {
        foreach (CGBData cgb in DataBase.instance.AllCGBs)
        {
            if (cgb.age == 1) babyCGBs.Add(cgb);
        }
    }
    public void SummonCgb()
    {
        //TeabagUseButton.SetActive(false);
        CloseFoodInven();
        foodAddBtnObject.SetActive(false);
        bgAnimation.AnimationState.SetAnimation(0, "summon", false);
        bgAnimation.AnimationState.AddAnimation(0, "idle", true, 0f);
        foodImg_img.sprite = selectedItem.sprite;
        StartCoroutine(Summoning());
    }
    IEnumerator Summoning()
    {
        foodImg.SetActive(true);
        yield return new WaitForSecondsRealtime(1f);
        foodImg.SetActive(false);
        yield return new WaitForSecondsRealtime(1f);
        RandomCGBOutfit();
        GachaCGB.SetActive(true);
        CGBAnimation.AnimationState.SetAnimation(0, "summon", false);
        CGBAnimation.AnimationState.AddAnimation(0, "summon_idle", true, 0f);
        yield return new WaitForSecondsRealtime(1.2f);
        CGBGachaPopup.SetActive(true);
    }
    ////¹è°æ »Ì±â¾Ö´Ï ³¡³µÀ»¶§ ½ÇÇà
    //void EventBG(TrackEntry trackEntry, Spine.Event e)
    //{
    //    if (e.Data.Name == "cgb")
    //    {
    //        GachaCGB.SetActive(true);
    //        RandomCGBOutfit();
    //        CGBAnimation.AnimationState.SetAnimation(0, "summon", false);
    //        CGBAnimation.AnimationState.AddAnimation(0, "summon_idle", true,0f);
    //    }
    //    else if (e.Data.Name == "endBG")
    //    {
    //        CGBGachaPopup.SetActive(true);
    //        //Teabags -= 1;
    //    }
    //}
    public void DisableGachaPopup()
    {
        GachaCGB.SetActive(false);
        CGBGachaPopup.SetActive(false);
        foodAddBtnObject.SetActive(true);
        //TeabagUseButton.SetActive(true);
        //UpdateTeabag();
    }
    public void RandomCGBOutfit()
    {
        PlayerData.instance.RemoveFood(selectedItem.id, summonFoodCount);
        CGBData newCgb = babyCGBs.Find(x => x.type == selectedItem.type);
        //CGBData newCgb = babyCGBs[Random.Range(0, babyCGBs.Count)].GetCGB();
        newCgb.brow = Random.Range(1, spineSetter.browCount + 1);
        newCgb.mouth = Random.Range(1, spineSetter.mouthCount + 1);
        //newCgb.base1vary = Random.Range(1, spineSetter.baseVaryCount + 1);
        CGBInfo.text = newCgb.name;
        spineSetter.SetAppearance(newCgb, CGBAnimation);
        PlayerData.instance.playerCGBs.Add(newCgb);
    }
    //void UpdateTeabag()
    //{

    //    RemainTeabags.GetComponent<Text>().text = "    x " + Teabags.ToString();

    //}
}
