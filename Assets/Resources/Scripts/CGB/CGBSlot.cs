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
    GameObject gardenCgb;

    public void AddCGB(CGBData newCGB)
    {
        spineSetter.SetAppearance(newCGB, skeletonGraphic);
        cgbPanel.SetActive(true);
        nametxt.text = newCGB.name;
        btn_place.SetActive(!newCGB.isPlaced);
        btn_unplace.SetActive(newCGB.isPlaced);
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
        spineSetter.SetAppearance(PlayerData.instance.playerCGBs[slotNum], gardenCgb.GetComponent<SkeletonAnimation>());
        gardenCgb.transform.localPosition = new Vector3(Random.Range(-2.5f, 2.5f), Random.Range(-3.5f, -0.1f), 1);
        CGBMotionController controller = gardenCgb.GetComponent<CGBMotionController>();
        controller.cgb = PlayerData.instance.playerCGBs[slotNum];
        controller.cgbBtn.onClick.AddListener(() => cgbPanelManager.ClickCGB(controller));
        btn_place.SetActive(false);
        btn_unplace.SetActive(true);
        PlayerData.instance.playerCGBs[slotNum].isPlaced = true;
    }
    public void Unplace()
    {
        Destroy(gardenCgb);
        btn_place.SetActive(true);
        btn_unplace.SetActive(false);
        PlayerData.instance.playerCGBs[slotNum].isPlaced = false;
    }

}
