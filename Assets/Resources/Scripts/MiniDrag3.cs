using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class MiniDrag3 : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{

    RectTransform rectTransform;
    //CanvasGroup canvasGroup;
    [SerializeField] Canvas canvas;
    public GameObject TC1;
    public GameObject TC2;
    public GameObject T1;
    public GameObject T2;
    public GameObject T1pos;
    public GameObject T2pos;
    public GameObject TC3;
    public GameObject TC4;
    public GameObject TC5;
    public GameObject TC6;




    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        //canvasGroup = GetComponent<CanvasGroup>();
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        //canvasGroup.alpha = .6f;
       // canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
       // canvasGroup.alpha = 1f;
        //canvasGroup.blocksRaycasts = true;

    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }

    public void OnDrop(PointerEventData eventData)
    {
        if ((this.transform.localPosition.x > -186 && this.transform.localPosition.x < -86) && (this.transform.localPosition.y > -50 && this.transform.localPosition.y < 50))
        {
            TC2.SetActive(true);
            //T2.SetActive(false);
            //T2.transform.localPosition = T2pos.transform.position;


        }
        if ((this.transform.localPosition.x > -50 && this.transform.localPosition.x < 50) && (this.transform.localPosition.y > -50 && this.transform.localPosition.y < 50))
        {
            TC4.SetActive(true);
            //T1.SetActive(false);



        }
        if ((this.transform.localPosition.x > 86 && this.transform.localPosition.x < 186) && (this.transform.localPosition.y > -50 && this.transform.localPosition.y < 50))
        {
            TC6.SetActive(true);
            //T1.SetActive(false);



        }
    }
    
    

}



