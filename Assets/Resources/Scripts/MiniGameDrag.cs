using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MiniGameDrag : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{

    RectTransform rectTransform;
   // CanvasGroup canvasGroup;
    [SerializeField] Canvas canvas;
    public GameObject enableTea;
    public GameObject teaPanel;
    public GameObject FinalPanel;
    public GameObject EnableTea;
    public GameObject middleTea;


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
        //canvasGroup.alpha = 1f;
        //canvasGroup.blocksRaycasts = true;
       
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }

    public void OnDrop(PointerEventData eventData)
    {
        if ((this.transform.localPosition.x > -43 && this.transform.localPosition.x < 47)&& (this.transform.localPosition.y > -439 && this.transform.localPosition.y < 54))
        {
            enableTea.SetActive(true);

            EnableTea.SetActive(true);
            this.gameObject.SetActive(false);
            middleTea.SetActive(true);
        }
    }

    public void nextscript()
    {
        teaPanel.SetActive(false);
        FinalPanel.SetActive(true);

    }
}

