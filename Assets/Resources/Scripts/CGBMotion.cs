using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using UnityEngine.UI;

public class CGBMotion : MonoBehaviour
{
    [SerializeField] int status;
    [SerializeField] bool dir = true;
    //public GameObject CGBMotionAdd;
    public int horizontal = -1;
    public int vertical = -1;
    public GameObject teabag;
    //public GameObject teabagRed, teabagBrown, teabagYellow, teabagGreen;
    private bool statusActive = false;
    [SerializeField] int actionCooltime = 2;
    private SkeletonAnimation sk;
    public CGBData cgbdata = new CGBData();
    private Vector3 currentpos;

    public void GetRandom()
    {
        status = Random.Range(1, 8);
        statusActive = false;
    }
    public void Run()

    {
        if ((this.gameObject.transform.position.x <= -3f || this.gameObject.transform.position.x >= 5f))
            ChangeDir();

        else
        {
            if (dir == true)
            {
                vertical = Random.Range(-2, 2);
                transform.Translate(new Vector3(horizontal, vertical, 0) * 1.0f * Time.deltaTime);
                if (statusActive == false)
                {
                    sk.AnimationState.SetAnimation(0, "run", true);
                    statusActive = true;
                }
            }
            if (dir == false)
            {
                vertical = Random.Range(-2, 2);
                transform.Translate(new Vector3(horizontal, vertical, 0) * 1.0f * Time.deltaTime);
                if (statusActive == false)
                {
                    sk.AnimationState.SetAnimation(0, "run", true);
                    statusActive = true;
                }
            }
        }

    }

    public void Idle()
    {
        transform.Translate(new Vector3(1, 0, 0) * 0.0f * Time.deltaTime);
        if (statusActive == false)
        {
            sk.AnimationState.SetAnimation(0, "idle", true);
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
            sk.AnimationState.SetAnimation(0, "idle", true);


            if (dir == true)
            {
                horizontal = 1;
                dir = false;
                sk.skeleton.ScaleX = -Mathf.Abs(sk.skeleton.ScaleX);
            }
            else if (dir == false)
            {
                horizontal = -1;
                dir = true;
                sk.skeleton.ScaleX = Mathf.Abs(sk.skeleton.ScaleX);
            }

            statusActive = true;

        }


    }
    public void sleep()
    {
        if (statusActive == false)
        {
            sk.AnimationState.SetAnimation(0, "sleep", true);
            StartCoroutine(SleepDelay());
            statusActive = true;
        }


    }
    public void Walk()
    {
        if ((this.gameObject.transform.position.x <= -5f || this.gameObject.transform.position.x >= 5f))
            ChangeDir();
     
        else
        {
            if (dir == true)
            {
                vertical = Random.Range(0, 2);
                transform.Translate(new Vector3(horizontal, vertical, 0) * 1.0f * Time.deltaTime);
                if (statusActive == false)
                {
                    sk.AnimationState.SetAnimation(0, "walk", true);
                    statusActive = true;
                }
            }
            if (dir == false)
            {
                vertical = Random.Range(-1, 1);
                transform.Translate(new Vector3(horizontal, vertical, 0) * 1.0f * Time.deltaTime);
                if (statusActive == false)
                {
                    sk.AnimationState.SetAnimation(0, "walk", true);
                    statusActive = true;
                }
            }
        }

    }

    public void Happy()
    {
        if (statusActive == false)
        {
            sk.AnimationState.SetAnimation(0, "happy", true);
            statusActive = true;
        }


    }
    
    public void CreateTeabag()
    {
        if (statusActive == false)
        {
            sk.AnimationState.SetAnimation(0, "idle", true);
            currentpos = new Vector3(this.gameObject.transform.position.x + Random.Range(-0.9f, 0.9f), this.gameObject.transform.position.y, 1);          
            GameObject tea = Instantiate(teabag, currentpos, Quaternion.identity);
            tea.GetComponent<TeabagHandler>().SetTeabagInfo(DataBase.instance.FindTeabag(cgbdata.teabagID));
            tea.transform.SetParent(this.transform.parent);

            //if (this.cgbdata.base1=="red")
            //{
            //    currentpos = this.gameObject.transform.position;
            //    GameObject tea = Instantiate(teabagRed, currentpos, Quaternion.identity);
            //    tea.transform.SetParent(Gpanel.transform);
            //}
            //else if (this.cgbdata.base1 == "brown")
            //{
            //    currentpos = this.gameObject.transform.position;
            //    GameObject tea = Instantiate(teabagBrown, currentpos, Quaternion.identity);
            //    tea.transform.SetParent(Gpanel.transform);
            //}
            //else if (this.cgbdata.base1 == "yellow")
            //{
            //    currentpos = this.gameObject.transform.position;
            //    GameObject tea = Instantiate(teabagYellow, currentpos, Quaternion.identity);
            //    tea.transform.SetParent(Gpanel.transform);
            //}
            //else if (this.cgbdata.base1 == "green")
            //{
            //    currentpos = this.gameObject.transform.position;
            //    GameObject tea = Instantiate(teabagGreen, currentpos, Quaternion.identity);
            //    tea.transform.SetParent(Gpanel.transform);
            //}
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

    void Awake()
    {
        sk = GetComponent<SkeletonAnimation>();
        actionCooltime = Random.Range(2, 5);
        InvokeRepeating("GetRandom", 0, actionCooltime);
    }


    void Update()
    {
        if (this.gameObject.transform.position.x >= 100f)
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
            else if (status == 7)
                CreateTeabag();
        }
    }
}
