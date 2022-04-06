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
    public bool statusActive = false;
    [SerializeField] int actionCooltime = 2;
    private SkeletonAnimation sk;
    CGBData cgbdata = new CGBData();
    private Vector3 currentpos;
    public GameObject Gpanel;
    public GameObject Camera;

    
    


    public void GetRandom()
    {
       
            status = Random.Range(1, 8);
            statusActive = false;
        
    }
    public void Run()

    {
        //if (statusActive == false)
       // {
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
           //gyy }
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
        //if (statusActive == false)
        //{
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
           // }
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

    public void CGBClick()
    {
        CancelInvoke("GetRandom");
        transform.Translate(new Vector3(1, 0, 0) * 0.0f * Time.deltaTime);
        sk.AnimationState.SetAnimation(0, "idle", true);
        statusActive = true;
        Camera.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, Camera.transform.position.z);

    }
  

    void Start()
    {
        actionCooltime = Random.Range(2, 5);
        sk = GetComponent<SkeletonAnimation>();
        InvokeRepeating("GetRandom", 0, actionCooltime);
    }


    void Update()
    {
        

        if (this.gameObject.transform.position.y > 5)
        {
            sk.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -30;
            teabagBrown.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -30;
            teabagRed.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -30;
            teabagGreen.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -30;
            teabagYellow.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -30;

        }
        else if (this.gameObject.transform.position.y > 4.5&& this.gameObject.transform.position.y <= 5)
        {
            sk.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -29;
            teabagBrown.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -29;
            teabagRed.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -29;
            teabagGreen.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -29;
            teabagYellow.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -29;

        }
        else if (this.gameObject.transform.position.y > 4 && this.gameObject.transform.position.y <= 4.5)
        {
            sk.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -28;
            teabagBrown.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -28;
            teabagRed.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -28;
            teabagGreen.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -28;
            teabagYellow.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -28;

        }
        else if (this.gameObject.transform.position.y > 3.5 && this.gameObject.transform.position.y <= 4)
        {
            sk.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -27;
            teabagBrown.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -27;
            teabagRed.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -27;
            teabagGreen.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -27;
            teabagYellow.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -27;

        }
        else if (this.gameObject.transform.position.y > 3&& this.gameObject.transform.position.y <= 3.5)
        {
            sk.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -26;
            teabagBrown.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -26;
            teabagRed.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -26;
            teabagGreen.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -26;
            teabagYellow.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -26;

        }
        else if (this.gameObject.transform.position.y > 2.5 && this.gameObject.transform.position.y <= 3)
        {
            sk.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -25;
            teabagBrown.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -25;
            teabagRed.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -25;
            teabagGreen.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -25;
            teabagYellow.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -25;

        }
        else if (this.gameObject.transform.position.y > 2 && this.gameObject.transform.position.y <= 2.5)
        {
            sk.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -24;
            teabagBrown.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -24;
            teabagRed.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -24;
            teabagGreen.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -24;
            teabagYellow.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -24;

        }
        else if (this.gameObject.transform.position.y > 1.5 && this.gameObject.transform.position.y <= 2)
        {
            sk.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -23;
            teabagBrown.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -23;
            teabagRed.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -23;
            teabagGreen.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -23;
            teabagYellow.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -23;

        }
        else if (this.gameObject.transform.position.y > 1 && this.gameObject.transform.position.y <= 1.5)
        {
            sk.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -22;
            teabagBrown.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -22;
            teabagRed.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -22;
            teabagGreen.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -22;
            teabagYellow.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -22;

        }
        else if (this.gameObject.transform.position.y > 0.5 && this.gameObject.transform.position.y <= 1)
        {
            sk.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -21;
            teabagBrown.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -21;
            teabagRed.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -21;
            teabagGreen.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -21;
            teabagYellow.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -21;

        }
        else if (this.gameObject.transform.position.y > 0 && this.gameObject.transform.position.y <= 0.5)
        {
            sk.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -20;
            teabagBrown.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -20;
            teabagRed.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -20;
            teabagGreen.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -20;
            teabagYellow.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -20;
        }
        else if (this.gameObject.transform.position.y > -0.5 && this.gameObject.transform.position.y <= 0)
        {
            sk.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -19;
            teabagBrown.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -19;
            teabagRed.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -19;
            teabagGreen.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -19;
            teabagYellow.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -19;

        }
        else if (this.gameObject.transform.position.y > -1 && this.gameObject.transform.position.y <= -0.5)
        {
            sk.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -18;
            teabagBrown.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -18;
            teabagRed.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -18;
            teabagGreen.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -18;
            teabagYellow.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -18;

        }
        else if (this.gameObject.transform.position.y > -1.5 && this.gameObject.transform.position.y <= -1)
        {
            sk.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -17;
            teabagBrown.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -17;
            teabagRed.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -17;
            teabagGreen.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -17;
            teabagYellow.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -17;

        }
        else if (this.gameObject.transform.position.y > -2 && this.gameObject.transform.position.y <= -1.5)
        {
            sk.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -16;
            teabagBrown.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = 16;
            teabagRed.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -16;
            teabagGreen.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -16;
            teabagYellow.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -16;

        }
        else if (this.gameObject.transform.position.y > -2.5 && this.gameObject.transform.position.y <= -2)
        {
            sk.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -15;
            teabagBrown.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -15;
            teabagRed.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -15;
            teabagGreen.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -15;
            teabagYellow.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -15;

        }
        else if (this.gameObject.transform.position.y > -3 && this.gameObject.transform.position.y <= -2.5)
        {
            sk.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -14;
            teabagBrown.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -14;
            teabagRed.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -14;
            teabagGreen.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -14;
            teabagYellow.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -14;

        }
        else if (this.gameObject.transform.position.y > -3.5 && this.gameObject.transform.position.y <= -3)
        {
            sk.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -13;
            teabagBrown.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -13;
            teabagRed.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -13;
            teabagGreen.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -13;
            teabagYellow.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -13;

        }
        else if (this.gameObject.transform.position.y > -4 && this.gameObject.transform.position.y <= -3.5)
        {
            sk.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -12;
            teabagBrown.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -12;
            teabagRed.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -12;
            teabagGreen.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -12;
            teabagYellow.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -12;

        }
        else if ( this.gameObject.transform.position.y <= -4)
        {
            sk.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -11;
            teabagBrown.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -11;
            teabagRed.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -11;
            teabagGreen.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -11;
            teabagYellow.gameObject.transform.GetComponent<MeshRenderer>().sortingOrder = -11;

        }
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
