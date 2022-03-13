using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class CGBAppearanceManager : MonoBehaviour
{
    public SkeletonAnimation skeletonAnimation;

    //차깨비 외형 정보
    public int age; //진화단계
    public enum skins { baby, strawberry }
    public skins type; //종류
    public enum colors { green, yellow, red, brown }
    public colors bodyColor; //몸색

    public int mouth;
    public int brow;

    #region 색,슬롯이름 설정
    //차깨비 몸색 별 눈썹,볼터치색
    Color greenBrow = new Color32(148, 193, 109, 255);
    Color greenCheek = new Color32(255, 255, 255, 255);
    Color yellowBrow = new Color32(255, 178, 20, 255);
    Color yellowCheek = new Color32(255, 252, 203, 232);
    Color redBrow = new Color32(253, 136, 136, 255);
    Color redCheek = new Color32(243, 180, 253, 231);
    Color brownBrow = new Color32(241, 164, 86, 255);
    Color brownCheek = new Color32(228, 225, 212, 231);

    //스파인 슬롯이름
    string bodySlot = "body";
    string mouthSlot = "mouth";
    string browRSlot = "brow_R"; string browLSlot = "brow_L";
    string cheekRSlot = "cheek_R"; string cheekLSlot = "cheek_L";
    string leg1Slot = "leg_F1"; string leg2Slot = "leg_F2"; string leg3Slot = "leg_B1"; string leg4Slot = "leg_B2";
    #endregion

    public void SetAppearance() //차깨비스파인에 외형 설정하기
    {
        skeletonAnimation.Skeleton.SetSkin(age+"_"+type.ToString());
        skeletonAnimation.Skeleton.SetAttachment(bodySlot, "1/body_" + bodyColor.ToString());
        skeletonAnimation.Skeleton.SetAttachment(leg1Slot, "1/leg_" + bodyColor.ToString());
        skeletonAnimation.Skeleton.SetAttachment(leg2Slot, "1/leg_" + bodyColor.ToString());
        skeletonAnimation.Skeleton.SetAttachment(leg3Slot, "1/leg_" + bodyColor.ToString());
        skeletonAnimation.Skeleton.SetAttachment(leg4Slot, "1/leg_" + bodyColor.ToString());
        skeletonAnimation.Skeleton.SetAttachment(mouthSlot, "face/mouth_" + mouth);
        skeletonAnimation.Skeleton.SetAttachment(browRSlot, "face/brow_" + brow);
        skeletonAnimation.Skeleton.SetAttachment(browLSlot, "face/brow_" + brow);
        //눈썹, 볼 색 변경
        switch (bodyColor)
        {
            case colors.green:
                skeletonAnimation.Skeleton.FindSlot(browRSlot).SetColor(greenBrow); skeletonAnimation.Skeleton.FindSlot(browLSlot).SetColor(greenBrow);
                skeletonAnimation.Skeleton.FindSlot(cheekRSlot).SetColor(greenCheek); skeletonAnimation.Skeleton.FindSlot(cheekLSlot).SetColor(greenCheek);
                break;

            case colors.yellow:
                skeletonAnimation.Skeleton.FindSlot(browRSlot).SetColor(yellowBrow); skeletonAnimation.Skeleton.FindSlot(browLSlot).SetColor(yellowBrow);
                skeletonAnimation.Skeleton.FindSlot(cheekRSlot).SetColor(yellowCheek); skeletonAnimation.Skeleton.FindSlot(cheekLSlot).SetColor(yellowCheek);
                break;

            case colors.red:
                skeletonAnimation.Skeleton.FindSlot(browRSlot).SetColor(redBrow); skeletonAnimation.Skeleton.FindSlot(browLSlot).SetColor(redBrow);
                skeletonAnimation.Skeleton.FindSlot(cheekRSlot).SetColor(redCheek); skeletonAnimation.Skeleton.FindSlot(cheekLSlot).SetColor(redCheek);
                break;

            case colors.brown:
                skeletonAnimation.Skeleton.FindSlot(browRSlot).SetColor(brownBrow); skeletonAnimation.Skeleton.FindSlot(browLSlot).SetColor(brownBrow);
                skeletonAnimation.Skeleton.FindSlot(cheekRSlot).SetColor(brownCheek); skeletonAnimation.Skeleton.FindSlot(cheekLSlot).SetColor(brownCheek);
                break;
        }
    }

    void Start()
    {
        SetAppearance();
    }
}