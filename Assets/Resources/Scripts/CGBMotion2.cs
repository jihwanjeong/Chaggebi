using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using UnityEngine.UI;

public class CGBMotion2 : MonoBehaviour
{
    [SerializeField] int status;
    [SerializeField] bool dir = true;
    public int horizontal = -1;
    public int vertical = -1;
    public GameObject teabag;
    public GameObject CGBMotionAdd;
    private bool statusActive = false;
    [SerializeField] int actionCooltime = 2;
    private SkeletonAnimation sk;
    public CGBData cgbdata = new CGBData();
    private Vector3 currentpos;
    public bool isClick = false;
    public GameObject CGBManagePanel;
    public GameObject CGBobject;
    //public Button CGBClickButton;
    public float cameraSpeed = 5.0f;
    public GameObject Camera;
    public GameObject UI;

    public void GetRandom()
    {
        status = Random.Range(1, 8);
        statusActive = false;
    }
    public void Run()

    {
        if ((CGBMotionAdd.gameObject.transform.position.x <= -3f || CGBMotionAdd.gameObject.transform.position.x >= 5f))
            ChangeDir();

        else
        {
            if (dir == true)
            {
                vertical = Random.Range(-2, 2);
                transform.Translate(new Vector3(horizontal, vertical, 0) * 1.0f * Time.deltaTime);
                if (statusActive == false)
                {
                    CGBMotionAdd.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "run", true);
                    statusActive = true;
                }
            }
            if (dir == false)
            {
                vertical = Random.Range(-2, 2);
                transform.Translate(new Vector3(horizontal, vertical, 0) * 1.0f * Time.deltaTime);
                if (statusActive == false)
                {
                    CGBMotionAdd.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "run", true);
                    statusActive = true;
                }
            }
        }

    }

    public void Idle()
    {
        CGBMotionAdd.transform.Translate(new Vector3(1, 0, 0) * 0.0f * Time.deltaTime);
        if (statusActive == false)
        {
            CGBMotionAdd.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "idle", true);
            statusActive = true;
        }


    }

    public void ChangeDir()
    {
        if (statusActive == false)
        {
            CancelInvoke("GetRandom");
            actionCooltime = Random.Range(2, 5);
            InvokeRepeating("GetRandom", 0, actionCooltime);
            CGBMotionAdd.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "idle", true);


            if (dir == true)
            {
                horizontal = 1;
                dir = false;
                CGBMotionAdd.GetComponent<SkeletonAnimation>().skeleton.ScaleX = -Mathf.Abs(CGBMotionAdd.GetComponent<SkeletonAnimation>().skeleton.ScaleX);
            }
            else if (dir == false)
            {
                horizontal = -1;
                dir = true;
                CGBMotionAdd.GetComponent<SkeletonAnimation>().skeleton.ScaleX = Mathf.Abs(CGBMotionAdd.GetComponent<SkeletonAnimation>().skeleton.ScaleX);
            }

            statusActive = true;

        }


    }
    public void sleep()
    {
        if (statusActive == false)
        {
            CGBMotionAdd.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "sleep", true);
            StartCoroutine(SleepDelay());
            statusActive = true;
        }


    }
    public void Walk()
    {
        if ((CGBMotionAdd.gameObject.transform.position.x <= -5f || CGBMotionAdd.gameObject.transform.position.x >= 5f))
            ChangeDir();

        else
        {
            if (dir == true)
            {
                vertical = Random.Range(0, 2);
                CGBMotionAdd.transform.Translate(new Vector3(horizontal, vertical, 0) * 1.0f * Time.deltaTime);
                if (statusActive == false)
                {
                    CGBMotionAdd.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "walk", true);
                    statusActive = true;
                }
            }
            if (dir == false)
            {
                vertical = Random.Range(-1, 1);
                CGBMotionAdd.transform.Translate(new Vector3(horizontal, vertical, 0) * 1.0f * Time.deltaTime);
                if (statusActive == false)
                {
                    CGBMotionAdd.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "walk", true);
                    statusActive = true;
                }
            }
        }

    }

    public void Happy()
    {
        if (statusActive == false)
        {
            CGBMotionAdd.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "happy", true);
            statusActive = true;
        }


    }

    public void CreateTeabag()
    {
        if (statusActive == false)
        {
            CGBMotionAdd.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "idle", true);
            currentpos = new Vector3(this.gameObject.transform.position.x + Random.Range(-0.9f, 0.9f), this.gameObject.transform.position.y, 1);
            GameObject tea = Instantiate(teabag, currentpos, Quaternion.identity);
            tea.GetComponent<TeabagHandler>().SetTeabagInfo(cgbdata.teabagID, 1);
            tea.transform.SetParent(this.transform.parent);
            statusActive = true;
        }


    }
    public IEnumerator SleepDelay()
    {
        CancelInvoke("GetRandom");
        yield return new WaitForSecondsRealtime(10.0f);
        actionCooltime = Random.Range(2, 5);
        InvokeRepeating("GetRandom", 0, actionCooltime);

    }
    /*public void CGBClick()
    {
        if (isClick == false)
        {
            CancelInvoke("GetRandom");
            CGBMotionAdd.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "idle", true);
            statusActive = true;
            Debug.Log(CGBobject.gameObject.transform.position.x);
            CGBManagePanel.SetActive(true);
            UI.SetActive(false);
            isClick = true;
        }
        else if (isClick == true)
        {

            InvokeRepeating("GetRandom", 0, actionCooltime);
            CGBManagePanel.SetActive(false);
            Vector3 originVector = new Vector3(0f, 0f, 0f);
            Camera.transform.position = originVector;
            UI.SetActive(true);
            isClick = false;
        }
    }*/


    void Awake()
    {
        sk = GetComponent<SkeletonAnimation>();
        actionCooltime = Random.Range(2, 5);
        InvokeRepeating("GetRandom", 0, actionCooltime);
        //CGBClickButton.onClick.AddListener(CGBClick);
    }


    void Update()
    {

        if (CGBMotionAdd.gameObject.transform.position.x >= 100f)
            statusActive = true;
        else
        {
            if (status == 1)
                ChangeDir();
            else if (status == 2)
                Idle();
            else if (status == 3)
                Run();
            else if (status == 4)
                sleep();
            else if (status == 5)
                Walk();
            else if (status == 6)
                Happy();
            //else if (status == 7)
            // CreateTeabag();
        }
        /*if (isClick != false)
        {
            Vector3 dir = CGBobject.transform.position - Camera.transform.position;
            Vector3 moveVector = new Vector3(dir.x * cameraSpeed * Time.deltaTime, dir.y * cameraSpeed * Time.deltaTime, 0.0f);
            Camera.transform.Translate(moveVector);


        }*/


    }
}
