using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseInvenManager : MonoBehaviour
{
    public Button invenBtn;
    public Button cleanBtn;
    public GameObject invenPanel;
    public Transform slotsParent;
    public GameObject useBtn;
    public GameObject flyingFood;
    Image flyingFood_img;
    public Text[] upTxt;

    ItemSlot[] slots;
    Button[] slotBtns;
    Item selectedItem;
    void Start()
    {
        cleanBtn.onClick.AddListener(() => StopAllCoroutines());
        invenPanel.SetActive(false);
        invenBtn.onClick.AddListener(OpenPanel);
        slots = slotsParent.GetComponentsInChildren<ItemSlot>();
        slotBtns = new Button[slots.Length];
        for (int i = 0; i < slots.Length; i++)
        {
            slotBtns[i] = slots[i].gameObject.GetComponent<Button>();
            int index = i;
            slotBtns[i].onClick.AddListener(() => SelectItem(index));
        }
        flyingFood_img = flyingFood.GetComponent<Image>();
    }

    void OpenPanel()
    {
        if (PlayerData.instance.interactingCGB.cgb.fullRate < 85)
        {
            UpdateInven();
            invenPanel.SetActive(true);
        }
        else
        {
            PlayerData.instance.interactingSk.AnimationState.SetAnimation(0, "no", false);
            PlayerData.instance.interactingSk.AnimationState.AddAnimation(0, "idle", false, 0);
        }
    }
    void UpdateInven()
    {
        useBtn.SetActive(false);
        int itemCount = PlayerData.instance.playerFoods.Count;
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].SelectActive(false);
            if (i < itemCount)
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
            slots[i].SelectActive(i==_i);
        }       
        useBtn.SetActive(true);
    }

    public void UseItem()
    {
        invenPanel.SetActive(false);
        if (PlayerData.instance.interactingCGB.cgb.fullRate < 85)
        {
            StopAllCoroutines();
            PlayerData.instance.RemoveFood(selectedItem.id, 1);
            PlayerData.instance.interactingCGB.cgb.scent += selectedItem.scent;
            PlayerData.instance.interactingCGB.cgb.earthy += selectedItem.earthy;
            PlayerData.instance.interactingCGB.cgb.sweet += selectedItem.sweet;
            PlayerData.instance.interactingCGB.cgb.sour += selectedItem.sour;
            PlayerData.instance.interactingCGB.cgb.fullRate += 20;
            StartCoroutine(Eat());
        }
        else PlayerData.instance.interactingSk.AnimationState.SetAnimation(0, "no", false);
    }

    IEnumerator Eat()
    {
        flyingFood_img.sprite = selectedItem.sprite;
        flyingFood.SetActive(true);
        PlayerData.instance.interactingSk.AnimationState.SetAnimation(0, "eat", true);
        yield return new WaitForSecondsRealtime(0.5f);
        flyingFood.SetActive(false);
        if(selectedItem.scent>0) StartCoroutine(ActiveUpTxt("향긋함", selectedItem.scent));
        yield return new WaitForSecondsRealtime(0.4f);
        if (selectedItem.earthy > 0) StartCoroutine(ActiveUpTxt("고소함", selectedItem.earthy));
        yield return new WaitForSecondsRealtime(0.4f);
        if (selectedItem.sweet > 0) StartCoroutine(ActiveUpTxt("달콤함", selectedItem.sweet));
        yield return new WaitForSecondsRealtime(0.4f);
        if (selectedItem.sour > 0) StartCoroutine(ActiveUpTxt("상큼함", selectedItem.sour));
        yield return new WaitForSecondsRealtime(3f);
        PlayerData.instance.interactingSk.AnimationState.SetAnimation(0, "happy", false);
        PlayerData.instance.interactingSk.AnimationState.AddAnimation(0, "idle", true, 0f);
    }

    IEnumerator ActiveUpTxt(string _stat, int _amount)
    {
        for (int i = 0; i < upTxt.Length; i++)
        {
            if (!upTxt[i].gameObject.activeSelf)
            {
                upTxt[i].text = _stat + " +" + _amount;
                upTxt[i].gameObject.SetActive(true);
                yield return new WaitForSeconds(0.45f);
                upTxt[i].gameObject.SetActive(false);
                break;
            }
        }
    }
}
