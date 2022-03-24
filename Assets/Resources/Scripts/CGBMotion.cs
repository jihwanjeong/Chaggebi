using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class CGBMotion : MonoBehaviour
{
    [SerializeField] int status;
    [SerializeField] bool dir = true;
    public GameObject CGBMotionAdd;
    public int horizontal = -1;
    public int vertical = -1;
    public GameObject teabagRed, teabagBrown, teabagYellow, teabagGreen;
    private bool statusActive = false;
    [SerializeField] int actionCooltime = 2;
    private SkeletonAnimation sk;
    CGBData cgbdata = new CGBData();
    private Vector3 currentpos;
    public GameObject Gpanel;


    public void GetRandom()
    {
        status = Random.Range(1, 8);
        statusActive = false;
    }
    public void Run()

    {
        if ((this.gameObject.transform.position.x <= -3f || this.gameObject.transform.position.x >= 5f))
            ChangeDir();

        /*else if ((this.gameObject.transform.position.y <= -2f || this.gameObject.transform.position.x >= 2.4f))
        {
            if (dir == true)
            {
                //vertical = Random.Range(-2, 2);
                transform.Translate(new Vector3(0, 0, 0) * 1.0f * Time.deltaTime);
                if (statusActive == false)
                {
                    sk.AnimationState.SetAnimation(0, "run", true);
                    statusActive = true;
                }
            }
            if (dir == false)
            {
                //vertical = Random.Range(-2, 2);
                transform.Translate(new Vector3(0, 0, 0) * 1.0f * Time.deltaTime);
                if (statusActive == false)
                {
                    sk.AnimationState.SetAnimation(0, "run", true);
                    statusActive = true;
                }
            }
        }*/
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
            if (this.cgbdata.bodyColor==CGBData.colors.red)
            {
                currentpos.x = this.gameObject.transform.position.x;
                currentpos.y = this.gameObject.transform.position.y;
                currentpos.z = 0f;
                Instantiate(teabagRed, currentpos, Quaternion.identity);
            }
            else if (this.cgbdata.bodyColor == CGBData.colors.brown)
            {
                currentpos = this.gameObject.transform.position;
                Instantiate(teabagBrown, currentpos, Quaternion.identity);
            }
            else if (this.cgbdata.bodyColor == CGBData.colors.yellow)
            {
                currentpos = this.gameObject.transform.position;
                Instantiate(teabagYellow, currentpos, Quaternion.identity);
            }
            else if (this.cgbdata.bodyColor == CGBData.colors.green)
            {
                currentpos.x = this.gameObject.transform.position.x;
                currentpos.y = this.gameObject.transform.position.y;
                currentpos.z = 0f;
                GameObject tea = Instantiate(teabagGreen, currentpos, Quaternion.identity);
                tea.transform.SetParent(Gpanel.transform);
            }
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

    void Start()
    {
        actionCooltime = Random.Range(2, 5);
        sk = GetComponent<SkeletonAnimation>();
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
