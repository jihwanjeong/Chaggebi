using UnityEngine;
using UnityEngine.UI;
using Spine.Unity;

public class CGBSlot : MonoBehaviour
{
    public int slotNum;
    public GameObject cgbPanel;
    public Text nametxt;
    public GameObject btn_place;
    public GameObject btn_unplace;
    public GameObject prefabCgb;
    public GameObject gardenCgbs;
    public SkeletonGraphic skeletonGraphic;
    public CGBSpineSetter spineSetter;
    public Chaggebi.ChaggebiPanelManager cgbPanelManager;
    public Transform teabagParent;
    GameObject gardenCgb;
    CGBMotionController controller;
    CGBData cgb;

    public void AddCGB(CGBData newCGB)
    {
        cgb = newCGB;
        spineSetter.SetAppearance(cgb, skeletonGraphic);
        cgbPanel.SetActive(true);
        nametxt.text = cgb.name;
        btn_place.SetActive(!cgb.isPlaced);
        btn_unplace.SetActive(cgb.isPlaced);
        //prefabCgb.GetComponent<CGBMotionController>().cgb = cgb;
    }

    public void RemoveCGB()
    {
        nametxt.text = "";
        cgbPanel.SetActive(false);
    }
 

    public void Place()
    {
        gardenCgb = Instantiate(prefabCgb) as GameObject;
        gardenCgb.transform.SetParent(gardenCgbs.transform, false);
        spineSetter.SetAppearance(cgb, gardenCgb.GetComponent<SkeletonAnimation>());
        gardenCgb.transform.localPosition = new Vector3(Random.Range(-2.5f, 2.5f), Random.Range(-3.5f, -0.1f), 1);
        controller = gardenCgb.GetComponent<CGBMotionController>();
        controller.cgb = cgb;
        controller.cgbBtn.onClick.AddListener(() => cgbPanelManager.ClickCGB(controller));
        controller.teaParent = teabagParent;
        btn_place.SetActive(false);
        btn_unplace.SetActive(true);
        cgb.isPlaced = true;
    }
    public void Unplace()
    {
        controller.StopAllCoroutines();
        cgb.isPlaced = false;
        Destroy(gardenCgb);
        btn_place.SetActive(true);
        btn_unplace.SetActive(false);
    }

}
