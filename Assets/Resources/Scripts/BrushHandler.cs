using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BrushHandler : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    Vector3 defaultPos;
    Vector2 mousePos;
    public ParticleSystem particle;
    float cleanTime;
    [Header("영역, 소요시간 설정")]
    public int areaSize = 300;
    public float washTimeSec = 0.5f;

    public void OnBeginDrag(PointerEventData eventData)
    {
        defaultPos = transform.position;
    }
    public void OnDrag(PointerEventData eventData)
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePos.x, mousePos.y, 27f);
        if(Mathf.Abs(transform.position.x) < areaSize && Mathf.Abs(transform.position.y) < areaSize)
        {
            if (particle.particleCount > 20)
            {
                cleanTime += Time.deltaTime;
                if (cleanTime > washTimeSec)
                {
                    PlayerData.instance.interactingCGB.cleanRate++;
                    cleanTime = 0;
                }
            }
        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = defaultPos;
    }
}
