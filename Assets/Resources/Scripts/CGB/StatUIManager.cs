using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Spine.Unity;

public class StatUIManager : MonoBehaviour
{
    public GameObject statPanel;
    public Button statBtn;
    public TeabagHandler makingTeabag;
    public Button teabagBtn;
    public SkeletonGraphic skeletonGraphic;
    public Slider slider_full, slider_clean, slider_happy;
    public Text txt_full, txt_clean, txt_happy, txt_scent, txt_earthy, txt_sweet, txt_sour;
    public Text name, customName, age;
    CGBData cgb;
    public CGBSpineSetter spineSetter;
    public GameObject itemDetailPanel;
    public Image detailImage;
    public Text detailName;
    public Text detailDescription;
    public Text detailStat;
    void Start()
    {
        statBtn.onClick.AddListener(()=> OpenStat(PlayerData.instance.interactingCGB.cgb));
        teabagBtn.onClick.AddListener(ViewTeabagDetail);
    }
    public void OpenStat(CGBData _cgb)
    {       
        cgb = _cgb;
        spineSetter.SetAppearance(cgb, skeletonGraphic);
        UpdateStatUI();
        makingTeabag.SetTeabagInfo(cgb.teabagID,0);
        name.text = cgb.name.ToString();
        customName.text = cgb.customName.ToString();
        age.text = "성장 " + cgb.age.ToString() + "단계";
        statPanel.SetActive(true);
    }
    public void UpdateStatUI()
    {
        slider_full.value = cgb.fullRate;
        slider_clean.value = cgb.cleanRate;
        slider_happy.value = cgb.happyRate;
        txt_full.text = cgb.fullRate.ToString();
        txt_clean.text = cgb.cleanRate.ToString();
        txt_happy.text = cgb.happyRate.ToString();
        txt_scent.text = cgb.scent.ToString();
        txt_earthy.text = cgb.earthy.ToString();
        txt_sweet.text = cgb.sweet.ToString();
        txt_sour.text = cgb.sour.ToString();
    }

    void ViewTeabagDetail()
    {
        detailImage.sprite = makingTeabag.teabag.sprite;
        detailName.text = makingTeabag.teabag.name;
        detailDescription.text = makingTeabag.teabag.description;
        detailStat.text = "달콤함 " + makingTeabag.teabag.scent + "   고소함 " + makingTeabag.teabag.earthy + "   달콤함 "
            + makingTeabag.teabag.sweet + "   상큼함 " + makingTeabag.teabag.sour;
        itemDetailPanel.SetActive(true);
    }
}
