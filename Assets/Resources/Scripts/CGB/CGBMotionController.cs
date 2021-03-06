using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using Spine.Unity;
using UnityEngine.UI;

public class CGBMotionController : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    int lvUpFlavorRate = 100;
    public int teabagCicleSec;
    public int fullDecreaseSec;
    public int cleanDecreaseSec;
    public int happyDecreaseSec;
    public CGBData cgb;
    public GameObject teabagPrefab;
    public Button cgbBtn;
    public SkeletonAnimation sk;
    public Transform teaParent;
    bool isHungry;
    public bool isDirty;
    bool isUnhappy;
    //move
    int horizontal = -1;
    int vertical = -1;
    public Coroutine moveCor;
    Coroutine moveCor2;
    Coroutine teabagCor;
    Coroutine fullCor;
    public Coroutine cleanCor;
    Coroutine happyCor;
    bool isCooltime;
    [HideInInspector] public bool isPlaced;
    void Awake()
    {
        isPlaced = false;
        sk.AnimationState.SetAnimation(0, "placed", true);
        StartCicle();
        cgbBtn.onClick.AddListener(CGBClick);
    }
    public void StartCicle()
    {
        if(!cgb.isGrowPrepare)
        {
            moveCor = StartCoroutine(RandomMove());
            teabagCor = StartCoroutine(CreateTeabag());
            fullCor = StartCoroutine(FullTimer());
            cleanCor = StartCoroutine(CleanTimer());
            happyCor = StartCoroutine(HappyTimer());
        }
    }
    IEnumerator FullTimer()
    {
        while(true)
        {
            yield return new WaitForSecondsRealtime(fullDecreaseSec);
            SetFull(-1);
            if (isHungry) SetHappy(-2);
        }
    }
    public IEnumerator CleanTimer()
    {
        while(true)
        {
            yield return new WaitForSecondsRealtime(cleanDecreaseSec);
            SetClean(-5);
            if (isDirty) SetHappy(-2);
        }
    }
    IEnumerator HappyTimer()
    {
        while(true)
        {
            yield return new WaitForSecondsRealtime(fullDecreaseSec);
            SetHappy(-1);
            if (isUnhappy) SetFull(-3);
        }
    }
    IEnumerator CreateTeabag()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(teabagCicleSec);
            Vector3 currentpos = new Vector3(this.gameObject.transform.position.x + Random.Range(-0.9f, 0.9f), this.gameObject.transform.position.y, 1);
            GameObject tea = Instantiate(teabagPrefab, currentpos, Quaternion.identity);
            tea.GetComponent<TeabagHandler>().SetTeabagInfo(cgb.teabagID, 1);
            tea.transform.SetParent(teaParent);
        }
    }
    
    public void SetFull(int _rate)
    {
        cgb.fullRate += _rate;
        if (cgb.fullRate < 0) cgb.fullRate = 0;
        else if (cgb.fullRate > 100) cgb.fullRate = 100;
        if (cgb.fullRate < 10)
        {
            isHungry = true;
        }
        else isHungry = false;
    }
    public void SetClean(int _rate)
    {
        cgb.cleanRate += _rate;
        if (cgb.cleanRate < 0) cgb.cleanRate = 0;
        else if (cgb.cleanRate > 100) cgb.cleanRate = 100;
        if (cgb.cleanRate < 50)
        {
            isDirty = true;
            sk.Skeleton.FindSlot("dirt").SetColor(new Color(1, 1, 1, (100 - cgb.cleanRate) / 100f));
        }
        else
        {
            isDirty = false;
            sk.Skeleton.FindSlot("dirt").SetColor(new Color(1, 1, 1, 0));
        }
    }
    public void SetHappy(int _rate)
    {
        cgb.happyRate += _rate;
        if (cgb.happyRate < 0) cgb.happyRate = 0;
        else if (cgb.happyRate > 100) cgb.happyRate = 100;
        if (cgb.happyRate < 10)
        {
            isUnhappy = true;
        }
        else isUnhappy = false;
    }
    public void SetScent(int _rate)
    {
        cgb.scent += _rate;
        if (cgb.age == 1 && cgb.scent >= lvUpFlavorRate)
        {
            cgb.flavorPrepare = "scent";
            cgb.isGrowPrepare = true;
            StopAllCoroutines();
        }
    }
    public void SetSweet(int _rate)
    {
        cgb.sweet += _rate;
        if (cgb.age == 1 && cgb.sweet >= lvUpFlavorRate)
        {
            cgb.flavorPrepare = "sweet";
            cgb.isGrowPrepare = true;
            StopAllCoroutines();
        }
    }
    public void SetEarthy(int _rate)
    {
        cgb.earthy += _rate;
        if (cgb.age == 1 && cgb.earthy >= lvUpFlavorRate)
        {
            cgb.flavorPrepare = "earthy";
            cgb.isGrowPrepare = true;
            StopAllCoroutines();
        }
    }
    public void SetSour(int _rate)
    {
        cgb.sour += _rate;
        if (cgb.age == 1 && cgb.sour >= lvUpFlavorRate)
        {
            cgb.flavorPrepare = "sour";
            cgb.isGrowPrepare = true;
            StopAllCoroutines();
        }
    }
    public IEnumerator RandomMove()
    {
        //sk.AnimationState.AddAnimation(0, "idle", true, 0);
        yield return new WaitForSecondsRealtime(7);
        isPlaced = true;
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
                moveCor2 = StartCoroutine(Walk());
                yield return new WaitForSecondsRealtime(Random.Range(1, 6));
                StopCoroutine(moveCor2);
            }
            else if (r < 90)
            {
                moveCor2 = StartCoroutine(Run());
                yield return new WaitForSecondsRealtime(Random.Range(2, 6));
                StopCoroutine(moveCor2);
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
        if (isHungry) sk.AnimationState.SetAnimation(0, "idle_hungry", true);
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
        vertical = Random.Range(-2, 2);
        while (true)
        {
            if ((this.gameObject.transform.position.x <= -12f || this.gameObject.transform.position.x >= 12f))
            {
                if (!isCooltime) ChangeDir();
            }
            if (this.gameObject.transform.localPosition.y > 0) vertical = -1;
            else if (this.gameObject.transform.localPosition.y < -2) vertical = 1;
            transform.Translate(new Vector3(horizontal * 0.5f, vertical, 0) * 1.0f * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }
    IEnumerator Run()
    {
        sk.AnimationState.SetAnimation(0, "run", true);
        isCooltime = false;
        vertical = Random.Range(-2, 2);
        while (true)
        {
            if ((this.gameObject.transform.position.x <= -12f || this.gameObject.transform.position.x >= 12f))
            {
                if (!isCooltime) ChangeDir();
            }
            if (this.gameObject.transform.localPosition.y > 0) vertical = -1;
            else if (this.gameObject.transform.localPosition.y < -2) vertical = 1;
            transform.Translate(new Vector3(horizontal * 2, vertical, 0) * 1.0f * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        if(isPlaced && PlayerData.instance.interactingCGB == null && !cgb.isGrowPrepare)
        {
            StopCoroutine(moveCor);
            if (moveCor2 != null) StopCoroutine(moveCor2);
            StopCoroutine(teabagCor);
            int r = Random.Range(0, 2);
            if (r == 0) sk.AnimationState.SetAnimation(0, "hang1", true);
            else sk.AnimationState.SetAnimation(0, "hang2", true);
        }
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        if(isPlaced && PlayerData.instance.interactingCGB == null && !cgb.isGrowPrepare)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            this.transform.position = new Vector3(mousePos.x, mousePos.y - 1.8f, 27f);
        }
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        if(isPlaced && PlayerData.instance.interactingCGB == null && !cgb.isGrowPrepare)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            sk.AnimationState.SetAnimation(0, "idle", true);
            float yPos;
            if (mousePos.y - 1.5f > 0) yPos = 1;
            else if (mousePos.y - 1.5f < -3) yPos = -1;
            else yPos = mousePos.y;
            this.transform.localPosition = new Vector3(mousePos.x, yPos - 1.5f, 27f);
            moveCor = StartCoroutine(RandomMove());
            teabagCor = StartCoroutine(CreateTeabag());
        }
    }

    public void CGBClick()
    {
        if (isPlaced && PlayerData.instance.interactingCGB == null && !cgb.isGrowPrepare)
        {
            StopCoroutine(moveCor);
            if (moveCor2 != null) StopCoroutine(moveCor2);
            sk.AnimationState.SetAnimation(0, "idle", true);
            PlayerData.instance.interactingCGB = this;
            PlayerData.instance.interactingSk = sk;
        }
    }
}
