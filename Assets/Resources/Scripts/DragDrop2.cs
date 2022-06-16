using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Spine.Unity;

public class DragDrop2 : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    //private SkeletonAnimation sk;
    public GameObject CGBMotionAdd;
    public int status;
    public static Vector3 DefaultPos;
    public bool drag = false;
    public void GetRandom()
    {
        status = Random.Range(1, 3);

    }
    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        DefaultPos = CGBMotionAdd.transform.position;
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        //Vector3 currentPos = eventData.position;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // this.transform.position = new Vector3(currentPos.x, currentPos.y, 33f);
        CGBMotionAdd.transform.position = new Vector3(mousePos.x, mousePos.y, 27f);
        drag = true;
        if (status == 1 && drag == true)
            CGBMotionAdd.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "hang1", true);
        else if (status == 2 && drag == true)
            CGBMotionAdd.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "hang2", true);


    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        CGBMotionAdd.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "idle", true);
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        CGBMotionAdd.transform.position = new Vector3(mousePos.x, mousePos.y, 27f);
        drag = false;
    }

    void Awake()
    {
        //sk = GetComponent<SkeletonAnimation>();

    }
    void Update()
    {
        if (drag == false)
            GetRandom();
    }
}
