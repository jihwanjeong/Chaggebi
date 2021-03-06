using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

[System.Serializable]
public class CGBBaseColor
{
    public string skin;
    public Color brow;
    public Color cheek;
}
public class CGBSpineSetter : MonoBehaviour
{
    public int browCount;
    public int mouthCount;
    //public int baseVaryCount;
    public List<CGBBaseColor> CGBBaseColors = new List<CGBBaseColor>();

    //스파인 슬롯이름
    //string bodySlot = "body";
    string mouthSlot = "mouth";
    string browRSlot = "brow_R"; string browLSlot = "brow_L";
    string cheekRSlot = "cheek_R"; string cheekLSlot = "cheek_L";
    //string leg1Slot = "leg_F1"; string leg2Slot = "leg_F2"; string leg3Slot = "leg_B1"; string leg4Slot = "leg_B2"; string leg3Slot_f = "leg_B1_front";
    string skin;

    public void SetAppearance(CGBData cgb, SkeletonAnimation skeletonAnimation) //차깨비스파인에 외형 설정하기
    {
        skin = cgb.age + "_" + cgb.type + "_" + cgb.flavor;
        skeletonAnimation.Skeleton.SetSkin(skin);
        //skeletonAnimation.Skeleton.SetAttachment(bodySlot, "1/body_" + cgb.type + cgb.base1vary);
        //skeletonAnimation.Skeleton.SetAttachment(leg1Slot, "1/leg_" + cgb.type + cgb.base1vary);
        //skeletonAnimation.Skeleton.SetAttachment(leg2Slot, "1/leg_" + cgb.type + cgb.base1vary);
        //skeletonAnimation.Skeleton.SetAttachment(leg3Slot, "1/leg_" + cgb.type + cgb.base1vary);
        //skeletonAnimation.Skeleton.SetAttachment(leg3Slot_f, "1/leg_" + cgb.type + cgb.base1vary+"b");
        //skeletonAnimation.Skeleton.SetAttachment(leg4Slot, "1/leg_" + cgb.type + cgb.base1vary);
        skeletonAnimation.Skeleton.SetAttachment(mouthSlot, "face/mouth_" + cgb.mouth);
        skeletonAnimation.Skeleton.SetAttachment(browRSlot, "face/brow_" + cgb.brow);
        skeletonAnimation.Skeleton.SetAttachment(browLSlot, "face/brow_" + cgb.brow);

        foreach (CGBBaseColor cgbBaseColor in CGBBaseColors)
        {
            if (skin == cgbBaseColor.skin)
            {
                skeletonAnimation.Skeleton.FindSlot(browRSlot).SetColor(cgbBaseColor.brow);
                skeletonAnimation.Skeleton.FindSlot(browLSlot).SetColor(cgbBaseColor.brow);
                skeletonAnimation.Skeleton.FindSlot(cheekRSlot).SetColor(cgbBaseColor.cheek);
                skeletonAnimation.Skeleton.FindSlot(cheekLSlot).SetColor(cgbBaseColor.cheek);
                break;
            }
        }
        skeletonAnimation.Skeleton.FindSlot("dirt").SetColor(new Color(1, 1, 1, 1 - (cgb.cleanRate / 100f)));
    }
    public void SetAppearance(CGBData cgb, SkeletonGraphic skeletonGraphic) //차깨비스파인UI 외형 설정하기
    {
        skin = cgb.age + "_" + cgb.type + "_" + cgb.flavor;
        skeletonGraphic.Skeleton.SetSkin(skin);
        //skeletonGraphic.Skeleton.SetAttachment(bodySlot, "1/body_" + cgb.type + cgb.base1vary);
        //skeletonGraphic.Skeleton.SetAttachment(leg1Slot, "1/leg_" + cgb.type + cgb.base1vary);
        //skeletonGraphic.Skeleton.SetAttachment(leg2Slot, "1/leg_" + cgb.type + cgb.base1vary);
        //skeletonGraphic.Skeleton.SetAttachment(leg3Slot, "1/leg_" + cgb.type + cgb.base1vary);
        //skeletonGraphic.Skeleton.SetAttachment(leg4Slot, "1/leg_" + cgb.type + cgb.base1vary);
        //skeletonGraphic.Skeleton.SetAttachment(leg3Slot_f, "1/leg_" + cgb.type + cgb.base1vary + "b");
        skeletonGraphic.Skeleton.SetAttachment(mouthSlot, "face/mouth_" + cgb.mouth);
        skeletonGraphic.Skeleton.SetAttachment(browRSlot, "face/brow_" + cgb.brow);
        skeletonGraphic.Skeleton.SetAttachment(browLSlot, "face/brow_" + cgb.brow);
        foreach (CGBBaseColor cgbBaseColor in CGBBaseColors)
        {
            if (skin == cgbBaseColor.skin)
            {
                skeletonGraphic.Skeleton.FindSlot(browRSlot).SetColor(cgbBaseColor.brow);
                skeletonGraphic.Skeleton.FindSlot(browLSlot).SetColor(cgbBaseColor.brow);
                skeletonGraphic.Skeleton.FindSlot(cheekRSlot).SetColor(cgbBaseColor.cheek);
                skeletonGraphic.Skeleton.FindSlot(cheekLSlot).SetColor(cgbBaseColor.cheek);
            }
        }
    }
}