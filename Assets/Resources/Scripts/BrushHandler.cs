using UnityEngine;
using UnityEngine.EventSystems;
using Spine.Unity;

public class BrushHandler : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
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

    public void Test()
    {
        PlayerData.instance.interactingCGB.cleanRate = 0;
        sk.Skeleton.FindSlot("dirt").SetColor(new Color(1, 1, 1, (100 - PlayerData.instance.interactingCGB.cleanRate) / 100f));
    }
    public void OpenPanel() //@Clean_btn
    {
        sk = PlayerData.instance.interactingSk;
        if (PlayerData.instance.interactingCGB.cleanRate < 100)
        {
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
    public void OnBeginDrag(PointerEventData eventData)
    {
        defaultPos = transform.position;
        if (PlayerData.instance.interactingCGB.cleanRate < 100) isClean = false;
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
                        if (PlayerData.instance.interactingCGB.cleanRate == 100)
                        {
                            transform.position = defaultPos;
                            sk.AnimationState.SetAnimation(0, "wash_end", false);
                            particleBling.Play(1, 1.5f, CGBManagePanel.position);
                            sk.AnimationState.AddAnimation(0, "happy", false,0);
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
