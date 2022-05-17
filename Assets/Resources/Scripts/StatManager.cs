using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Spine.Unity;

public class StatManager : MonoBehaviour
{
    public GameObject statPanel;
    public Button statBtn;
    public SkeletonGraphic skeletonGraphic;
    public Slider slider_full, slider_clean, slider_happy;
    public Text txt_full, txt_clean, txt_happy, txt_scent, txt_earthy, txt_sweet, txt_sour;
    CGBData cgb;
    public CGBSpineSetter spineSetter;

    void Start()
    {
        statBtn.onClick.AddListener(()=> OpenStat(PlayerData.instance.interactingCGB));
    }
    public void OpenStat(CGBData _cgb)
    {       
        cgb = _cgb;
        spineSetter.SetAppearance(cgb, skeletonGraphic);
        statPanel.SetActive(true);
        UpdateStatUI();
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
}
