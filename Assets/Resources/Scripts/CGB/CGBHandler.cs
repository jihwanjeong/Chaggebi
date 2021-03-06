using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Spine.Unity;
using UnityEngine.UI;

public class CGBHandler : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public int teabagCicleSec;
    public int fullDecreaseRate;
    public int cleanDecreaseRate;
    public int happyDecreaseRate;
    public CGBData cgb;
    public GameObject teabagPrefab;
    public Button cgbBtn;
    SkeletonAnimation sk;
    bool isHungry;
    bool isDirty;
    bool isUnhappy;
    //move
    int horizontal = -1;
    int vertical = -1;
    IEnumerator moveCoroutine;
    bool isCooltime;

    void Awake()
    {
        sk = GetComponent<SkeletonAnimation>();
        sk.AnimationState.SetAnimation(0, "placed", true);
        StartCicle();
        cgbBtn.onClick.AddListener(CGBClick);
    }
    public void StartCicle()
    {
        StartCoroutine(RandomMove());
        StartCoroutine(CreateTeabag());
    }
    IEnumerator CreateTeabag()
    {
        while(true)
        {
            yield return new WaitForSecondsRealtime(teabagCicleSec);
            Vector3 currentpos = new Vector3(this.gameObject.transform.position.x + Random.Range(-0.9f, 0.9f), this.gameObject.transform.position.y, 1);
            GameObject tea = Instantiate(teabagPrefab, currentpos, Quaternion.identity);
            tea.GetComponent<TeabagHandler>().SetTeabagInfo(cgb.teabagID, 1);
            tea.transform.SetParent(this.transform.parent);
            SetFull(-fullDecreaseRate);
            SetClean(-cleanDecreaseRate);
            SetHappy(-happyDecreaseRate);
            if (isHungry) SetHappy(-2);
            if (isDirty) SetHappy(-2);
            if (isUnhappy) SetFull(-3);
        }
    }

    void SetFull(int _rate)
    {
        cgb.fullRate += _rate;
        if (cgb.fullRate < 10)
        {
            isHungry = true;
        }
        else isHungry = false;
    }
    void SetClean(int _rate)
    {
        cgb.cleanRate += _rate;
        if (cgb.cleanRate < 50)
        {
            isDirty = true;
        }
        else isDirty = false;
    }
    void SetHappy(int _rate)
    {
        cgb.happyRate += _rate;
        if (cgb.happyRate < 10)
        {
            isUnhappy = true;
        }
        else isUnhappy = false;
    }

    public IEnumerator RandomMove()
    {
        sk.AnimationState.AddAnimation(0, "idle", true, 0);
        yield return new WaitForSecondsRealtime(10);
        while (true)
        {
            Idle();
            yield return new WaitForSecondsRealtime(Random.Range(5, 20));
            int r = Random.Range(0, 100);
            if (r < 30)
            {
                Idle();
                yield return new WaitForSecondsRealtime(Random.Range(2, 10));
            }
            else if (r < 70)
            {
                moveCoroutine = Walk();
                StartCoroutine(moveCoroutine);
                yield return new WaitForSecondsRealtime(Random.Range(1, 6));
                StopCoroutine(moveCoroutine);
            }
            else if (r < 90)
            {
                moveCoroutine = Run();
                StartCoroutine(moveCoroutine);
                yield return new WaitForSecondsRealtime(Random.Range(2, 6));
                StopCoroutine(moveCoroutine);
            }
            else if (r < 100)
            {
                Sleep();
                yield return new WaitForSecondsRealtime(Random.Range(10, 20));
            }
        }
    }
    public void ChangeDir()
    {
        isCooltime = true;
        horizontal *= -1;
        sk.skeleton.ScaleX *= -1;
    }

    public void Idle()
    {
        int r = Random.Range(0, 2);
        if (r == 0) ChangeDir();
        if(isHungry) sk.AnimationState.SetAnimation(0, "idle_hungry", true);
        else sk.AnimationState.SetAnimation(0, "idle", true);
    }
    public void Sleep()
    {
        sk.AnimationState.SetAnimation(0, "sleep", true);
    }
    IEnumerator Walk()
    {
        if (isHungry) sk.AnimationState.SetAnimation(0, "walk_hungry", true);
        else sk.AnimationState.SetAnimation(0, "walk", true);
        isCooltime = false;
        while (true)
        {
            if ((this.gameObject.transform.position.x <= -12f || this.gameObject.transform.position.x >= 12f))
            {
                if (!isCooltime) ChangeDir();
            }
            if (this.gameObject.transform.position.y > 0) vertical = -1;
            else if (this.gameObject.transform.position.y < -2) vertical = 1;
            else vertical = Random.Range(-2, 2);
            transform.Translate(new Vector3(horizontal * 0.5f, vertical, 0) * 1.0f * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }
    IEnumerator Run()
    {
        sk.AnimationState.SetAnimation(0, "run", true);
        isCooltime = false;
        while (true)
        {
            if ((this.gameObject.transform.position.x <= -12f || this.gameObject.transform.position.x >= 12f))
            {
                if (!isCooltime) ChangeDir();
            }
            if (this.gameObject.transform.position.y > 0) vertical = -1;
            else if (this.gameObject.transform.position.y < -2) vertical = 1;
            else vertical = Random.Range(-2, 2);
            transform.Translate(new Vector3(horizontal * 2, vertical, 0) * 1.0f * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        StopAllCoroutines();
        int r = Random.Range(0, 2);
        if (r == 0) sk.AnimationState.SetAnimation(0, "hang1", true);
        else sk.AnimationState.SetAnimation(0, "hang2", true);
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.transform.position = new Vector3(mousePos.x, mousePos.y - 1.8f, 27f);
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        sk.AnimationState.SetAnimation(0, "idle", true);
        this.transform.position = new Vector3(mousePos.x, mousePos.y - 2.5f, 27f);
        StartCoroutine(RandomMove());
        StartCoroutine(CreateTeabag());
    }

    public void CGBClick()
    {
        StopAllCoroutines();
        sk.AnimationState.SetAnimation(0, "idle", true);
        PlayerData.instance.interactingCGB.cgb = cgb;
        PlayerData.instance.interactingSk = sk;
    }
}
