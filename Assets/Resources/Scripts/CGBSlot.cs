using UnityEngine;
using UnityEngine.UI;

public class CGBSlot : MonoBehaviour
{
    public int slotNum;
    public GameObject cgbPanel;
    public Text nametxt;
    public GameObject btn_place;
    public GameObject btn_unplace;
    public GameObject prefabCgb;
    public GameObject gardenCgbs;
    public CGBSpineSetter spineUpdater;
    GameObject gardenCgb;

    public void AddCGB(CGBData newCGB)
    {
        spineUpdater.SetAppearance(newCGB);
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
        gardenCgb.GetComponent<CGBSpineSetter>().SetAppearance(PlayerData.instance.playerCGBs[slotNum]);
        gardenCgb.transform.SetParent(gardenCgbs.transform, false);
        gardenCgb.transform.position = new Vector3(Random.Range(-2.5f, 2.5f), Random.Range(-2.5f, 0.2f), 1);
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
