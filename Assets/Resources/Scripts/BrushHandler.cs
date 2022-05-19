using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Spine.Unity;

public class BrushHandler : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public GameObject cleanPanel;
    Vector3 defaultPos;
    Vector2 mousePos;
    public ParticleSystem particle;
    float cleanTime;
    [Header("영역, 소요시간 설정")]
    public int areaSize = 300;
    public float washSpeed = 0.1f;
    bool isClean;
    SkeletonAnimation sk;

    public void OpenPanel()
    {
        if (PlayerData.instance.interactingCGB.cleanRate < 100) cleanPanel.SetActive(true);
        else
        {
            sk.AnimationState.SetAnimation(0, "no", false);
            sk.AnimationState.AddAnimation(0, "idle", false, 0);
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        defaultPos = transform.position;
        if (PlayerData.instance.interactingCGB.cleanRate < 100) isClean = false;
        else isClean = true;
        sk = PlayerData.instance.interactingSk;
    }
    public void OnDrag(PointerEventData eventData)
    {
        if(!isClean)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePos.x, mousePos.y, 27f);
            if (Mathf.Abs(transform.position.x) < areaSize && Mathf.Abs(transform.position.y) < areaSize)
            {
                if (particle.particleCount > 10)
                {
                    cleanTime += Time.deltaTime;
                    if (cleanTime > washSpeed)
                    {
                        if (PlayerData.instance.interactingCGB.cleanRate == 100)
                        {
                            transform.position = defaultPos;
                            sk.AnimationState.SetAnimation(0, "happy", false);
                            sk.AnimationState.AddAnimation(0, "idle", true, 0f);
                            isClean = true;
                            cleanPanel.SetActive(false);
                        }
                        else
                        {
                            PlayerData.instance.interactingCGB.cleanRate++;
                            sk.Skeleton.FindSlot("dirt").SetColor(new Color(1, 1, 1, (100 - PlayerData.instance.interactingCGB.cleanRate) / 100f));
                        }
                        cleanTime = 0;
                    }
                }
            }
        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = defaultPos;
    }

}
