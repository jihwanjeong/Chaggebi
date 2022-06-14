using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class CGBStatHandler : MonoBehaviour
{
    public int teabagCicleSec;
    public int fullDecreaseRate;
    public int cleanDecreaseRate;
    public int happyDecreaseRate;
    public CGBData cgb;
    public GameObject teabagPrefab;
    SkeletonAnimation sk;
    bool isHungry;
    bool isDirty;
    bool isUnhappy;
    //move
    int horizontal = -1;
    int vertical = -1;
    IEnumerator moveCoroutine;
    bool isCooltime;
    //float time = 0;
    //int duration;
    //Vector3 startPos, endPos;

    void Awake()
    {
        sk = GetComponent<SkeletonAnimation>();
        StartCoroutine(StartCicle());
    }
    public IEnumerator StartCicle()
    {
        sk.AnimationState.SetAnimation(0, "placed", true);
        sk.AnimationState.AddAnimation(0, "idle", true, 0);
        yield return new WaitForSecondsRealtime(10);
        StartCoroutine(RandomMove());
        while(true)
        {
            yield return new WaitForSecondsRealtime(teabagCicleSec);
            CreateTeabag();
        }
    }
    void CreateTeabag()
    {
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

    IEnumerator RandomMove()
    {
        while(true)
        {
            int r = Random.Range(0, 4);
            //if (r < 40)
            //{
            //    Idle();
            //    yield return new WaitForSecondsRealtime(Random.Range(2, 10));
            //}
            //else if(r < 70)
            //{
            //    moveCoroutine = Walk();
            //    StartCoroutine(moveCoroutine);
            //    yield return new WaitForSecondsRealtime(Random.Range(1, 6));
            //    StopCoroutine(moveCoroutine);
            //}
            //else if (r < 90)
            //{
            //    moveCoroutine = Run();
            //    StartCoroutine(moveCoroutine);
            //    yield return new WaitForSecondsRealtime(Random.Range(2, 6));
            //    StopCoroutine(moveCoroutine);
            //}
            //else if (r < 100)
            //{
            //    Sleep();
            //    yield return new WaitForSecondsRealtime(Random.Range(10, 20));
            //}
            switch (r)
            {
                case 0:
                    Idle();
                    yield return new WaitForSecondsRealtime(Random.Range(5, 20));
                    break;
                case 1:
                    moveCoroutine = Walk();
                    StartCoroutine(moveCoroutine);
                    yield return new WaitForSecondsRealtime(Random.Range(3, 8));
                    StopCoroutine(moveCoroutine);
                    break;
                case 2:
                    moveCoroutine = Run();
                    StartCoroutine(moveCoroutine);
                    yield return new WaitForSecondsRealtime(Random.Range(3, 6));
                    StopCoroutine(moveCoroutine);
                    break;
                case 3:
                    Sleep();
                    yield return new WaitForSecondsRealtime(Random.Range(10, 20));
                    break;
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
        sk.AnimationState.SetAnimation(0, "idle", true);
    }
    public void Sleep()
    {
        sk.AnimationState.SetAnimation(0, "sleep", true);
    }
    IEnumerator Walk()
    {
        sk.AnimationState.SetAnimation(0, "walk", true);
        isCooltime = false;
        while (true)
        {
            if ((this.gameObject.transform.position.x <= -12f || this.gameObject.transform.position.x >= 12f))
            {
                if(!isCooltime) ChangeDir();
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
}
