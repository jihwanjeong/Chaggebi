using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using UnityEngine.UI;

public class CGBClickManager : MonoBehaviour
{
    [SerializeField] int status;
    public GameObject CGBMotionAdd;
    private bool statusActive = false;
    [SerializeField] int actionCooltime = 2;
    private SkeletonAnimation sk;
    public CGBData cgbdata = new CGBData();
    public bool isClick = false;
    public GameObject CGBManagePanel;
    public GameObject CGBobject;
    public Button CGBClickButton;
    public float cameraSpeed = 5.0f;
    public GameObject Camera;
    public GameObject UI;

    public void GetRandom()
    {
        status = Random.Range(1, 8);
        statusActive = false;
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

    
    public void CGBClick()
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
    }


    void Awake()
    {
        sk = GetComponent<SkeletonAnimation>();
        actionCooltime = Random.Range(2, 5);
        //CGBClickButton.onClick.AddListener(CGBClick);

    }


    void Update()
    {

        if (isClick != false)
        {
            Vector3 dir = CGBobject.transform.position - Camera.transform.position;
            Vector3 moveVector = new Vector3(dir.x * cameraSpeed * Time.deltaTime, dir.y * cameraSpeed * Time.deltaTime, 0.0f);
            Camera.transform.Translate(moveVector);


        }

    }
}
