using UnityEngine;
using UnityEngine.EventSystems;
using Spine.Unity;

public class BrushHandler : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public GameObject mainBtns;
    public GameObject cleanPanel;
    public Transform CGBManagePanel;
    Vector3 defaultPos;
    Vector2 mousePos;
    public ParticleSystem particleBubble;
    public ParticleController particleBling;
    float cleanTime;
    [Header("영역, 소요시간 설정")]
    public int areaSize = 300;
    public float washSpeed = 0.1f;
    bool isClean;
    SkeletonAnimation sk;
    CGBMotionController controller;

    public void Test()
    {
        sk = PlayerData.instance.interactingSk;
        PlayerData.instance.interactingCGB.cgb.cleanRate = 0;
        sk.Skeleton.FindSlot("dirt").SetColor(new Color(1, 1, 1, (100 - controller.cgb.cleanRate) / 100f));
    }
    public void OpenPanel() //@Clean_btn
    {
        sk = PlayerData.instance.interactingSk;
        controller = PlayerData.instance.interactingCGB;
        if (controller.cgb.cleanRate < 50)
        {
            controller.StopCoroutine(controller.cleanCor);
            mainBtns.SetActive(false);
            cleanPanel.SetActive(true);
            sk.AnimationState.SetAnimation(0, "wash_start", false);
            sk.AnimationState.AddAnimation(0, "wash_idle", false, 0);
        }
        else
        {
            sk.AnimationState.SetAnimation(0, "no", false);
            sk.AnimationState.AddAnimation(0, "idle", false, 0);
        }
    }
    public void ClosePanel()
    {
        cleanPanel.SetActive(false);
        sk.AnimationState.SetAnimation(0, "wash_end", false);
        sk.AnimationState.AddAnimation(0, "idle", true, 0f);
        mainBtns.SetActive(true);
        controller.cleanCor = controller.StartCoroutine(controller.CleanTimer());
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        defaultPos = transform.position;
        if (controller.cgb.cleanRate < 100) isClean = false;
        else isClean = true;
    }
    public void OnDrag(PointerEventData eventData)
    {
        if(!isClean)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePos.x, mousePos.y, transform.position.z);
            if (Mathf.Abs(transform.position.x) < areaSize && Mathf.Abs(transform.position.y) < areaSize)
            {
                if (particleBubble.particleCount > 10)
                {
                    cleanTime += Time.deltaTime;
                    if (cleanTime > washSpeed)
                    {
                        if (controller.cgb.cleanRate == 100)
                        {
                            transform.position = defaultPos;
                            sk.AnimationState.SetAnimation(0, "wash_end", false);
                            particleBling.Play(1, 1.5f, CGBManagePanel.position);
                            sk.AnimationState.AddAnimation(0, "happy", false,0);
                            sk.AnimationState.AddAnimation(0, "idle", true, 0f);
                            isClean = true;
                            cleanPanel.SetActive(false);
                            mainBtns.SetActive(true);
                            controller.cleanCor = controller.StartCoroutine(controller.CleanTimer());
                        }
                        else
                        {
                            controller.cgb.cleanRate++;
                            if (controller.cgb.cleanRate >= 50) controller.isDirty = false;
                            sk.Skeleton.FindSlot("dirt").SetColor(new Color(1, 1, 1, (100 - controller.cgb.cleanRate) / 100f));
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
