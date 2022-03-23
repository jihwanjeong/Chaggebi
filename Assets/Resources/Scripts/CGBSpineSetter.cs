using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class CGBSpineSetter : MonoBehaviour
{
    public SkeletonAnimation skeletonAnimation;
    public SkeletonGraphic skeletonGraphic;

    #region »ö,½½·ÔÀÌ¸§ ¼³Á¤
    //Â÷±úºñ ¸ö»ö º° ´«½ç,º¼ÅÍÄ¡»ö
    Color greenBrow = new Color32(148, 193, 109, 255);
    Color greenCheek = new Color32(255, 255, 255, 255);
    Color yellowBrow = new Color32(255, 178, 20, 255);
    Color yellowCheek = new Color32(255, 252, 203, 232);
    Color redBrow = new Color32(253, 136, 136, 255);
    Color redCheek = new Color32(243, 180, 253, 231);
    Color brownBrow = new Color32(241, 164, 86, 255);
    Color brownCheek = new Color32(228, 225, 212, 231);
    Color blueBrow = new Color32(175, 141, 215, 255);
    Color blueCheek = new Color32(228, 134, 255, 231);

    //½ºÆÄÀÎ ½½·ÔÀÌ¸§
    string bodySlot = "body";
    string mouthSlot = "mouth";
    string browRSlot = "brow_R"; string browLSlot = "brow_L";
    string cheekRSlot = "cheek_R"; string cheekLSlot = "cheek_L";
    string leg1Slot = "leg_F1"; string leg2Slot = "leg_F2"; string leg3Slot = "leg_B1"; string leg4Slot = "leg_B2";
    #endregion

    public void SetAppearance(CGBData cgb) //Â÷±úºñ½ºÆÄÀÎ¿¡ ¿ÜÇü ¼³Á¤ÇÏ±â
    {
        if (skeletonAnimation != null)
        {
            skeletonAnimation.Skeleton.SetSkin(cgb.age + "_" + cgb.skin.ToString());
            skeletonAnimation.Skeleton.SetAttachment(bodySlot, "1/body_" + cgb.bodyColor.ToString());
            skeletonAnimation.Skeleton.SetAttachment(leg1Slot, "1/leg_" + cgb.bodyColor.ToString());
            skeletonAnimation.Skeleton.SetAttachment(leg2Slot, "1/leg_" + cgb.bodyColor.ToString());
            skeletonAnimation.Skeleton.SetAttachment(leg3Slot, "1/leg_" + cgb.bodyColor.ToString());
            skeletonAnimation.Skeleton.SetAttachment(leg4Slot, "1/leg_" + cgb.bodyColor.ToString());
            skeletonAnimation.Skeleton.SetAttachment(mouthSlot, "face/mouth_" + cgb.mouth);
            skeletonAnimation.Skeleton.SetAttachment(browRSlot, "face/brow_" + cgb.brow);
            skeletonAnimation.Skeleton.SetAttachment(browLSlot, "face/brow_" + cgb.brow);
            //´«½ç, º¼ »ö º¯°æ
            switch (cgb.bodyColor)
            {
                case CGBData.colors.green:
                    skeletonAnimation.Skeleton.FindSlot(browRSlot).SetColor(greenBrow); skeletonAnimation.Skeleton.FindSlot(browLSlot).SetColor(greenBrow);
                    skeletonAnimation.Skeleton.FindSlot(cheekRSlot).SetColor(greenCheek); skeletonAnimation.Skeleton.FindSlot(cheekLSlot).SetColor(greenCheek);
                    break;

                case CGBData.colors.yellow:
                    skeletonAnimation.Skeleton.FindSlot(browRSlot).SetColor(yellowBrow); skeletonAnimation.Skeleton.FindSlot(browLSlot).SetColor(yellowBrow);
                    skeletonAnimation.Skeleton.FindSlot(cheekRSlot).SetColor(yellowCheek); skeletonAnimation.Skeleton.FindSlot(cheekLSlot).SetColor(yellowCheek);
                    break;

                case CGBData.colors.red:
                    skeletonAnimation.Skeleton.FindSlot(browRSlot).SetColor(redBrow); skeletonAnimation.Skeleton.FindSlot(browLSlot).SetColor(redBrow);
                    skeletonAnimation.Skeleton.FindSlot(cheekRSlot).SetColor(redCheek); skeletonAnimation.Skeleton.FindSlot(cheekLSlot).SetColor(redCheek);
                    break;

                case CGBData.colors.brown:
                    skeletonAnimation.Skeleton.FindSlot(browRSlot).SetColor(brownBrow); skeletonAnimation.Skeleton.FindSlot(browLSlot).SetColor(brownBrow);
                    skeletonAnimation.Skeleton.FindSlot(cheekRSlot).SetColor(brownCheek); skeletonAnimation.Skeleton.FindSlot(cheekLSlot).SetColor(brownCheek);
                    break;
                case CGBData.colors.blue:
                    skeletonAnimation.Skeleton.FindSlot(browRSlot).SetColor(blueBrow); skeletonAnimation.Skeleton.FindSlot(browLSlot).SetColor(blueBrow);
                    skeletonAnimation.Skeleton.FindSlot(cheekRSlot).SetColor(blueCheek); skeletonAnimation.Skeleton.FindSlot(cheekLSlot).SetColor(blueCheek);
                    break;
            }
        }
        else if (skeletonGraphic != null)
        {
            skeletonGraphic.Skeleton.SetSkin(cgb.age + "_" + cgb.skin.ToString());
            skeletonGraphic.Skeleton.SetAttachment(bodySlot, "1/body_" + cgb.bodyColor.ToString());
            skeletonGraphic.Skeleton.SetAttachment(leg1Slot, "1/leg_" + cgb.bodyColor.ToString());
            skeletonGraphic.Skeleton.SetAttachment(leg2Slot, "1/leg_" + cgb.bodyColor.ToString());
            skeletonGraphic.Skeleton.SetAttachment(leg3Slot, "1/leg_" + cgb.bodyColor.ToString());
            skeletonGraphic.Skeleton.SetAttachment(leg4Slot, "1/leg_" + cgb.bodyColor.ToString());
            skeletonGraphic.Skeleton.SetAttachment(mouthSlot, "face/mouth_" + cgb.mouth);
            skeletonGraphic.Skeleton.SetAttachment(browRSlot, "face/brow_" + cgb.brow);
            skeletonGraphic.Skeleton.SetAttachment(browLSlot, "face/brow_" + cgb.brow);
            //´«½ç, º¼ »ö º¯°æ
            switch (cgb.bodyColor)
            {
                case CGBData.colors.green:
                    skeletonGraphic.Skeleton.FindSlot(browRSlot).SetColor(greenBrow); skeletonGraphic.Skeleton.FindSlot(browLSlot).SetColor(greenBrow);
                    skeletonGraphic.Skeleton.FindSlot(cheekRSlot).SetColor(greenCheek); skeletonGraphic.Skeleton.FindSlot(cheekLSlot).SetColor(greenCheek);
                    break;

                case CGBData.colors.yellow:
                    skeletonGraphic.Skeleton.FindSlot(browRSlot).SetColor(yellowBrow); skeletonGraphic.Skeleton.FindSlot(browLSlot).SetColor(yellowBrow);
                    skeletonGraphic.Skeleton.FindSlot(cheekRSlot).SetColor(yellowCheek); skeletonGraphic.Skeleton.FindSlot(cheekLSlot).SetColor(yellowCheek);
                    break;

                case CGBData.colors.red:
                    skeletonGraphic.Skeleton.FindSlot(browRSlot).SetColor(redBrow); skeletonGraphic.Skeleton.FindSlot(browLSlot).SetColor(redBrow);
                    skeletonGraphic.Skeleton.FindSlot(cheekRSlot).SetColor(redCheek); skeletonGraphic.Skeleton.FindSlot(cheekLSlot).SetColor(redCheek);
                    break;

                case CGBData.colors.brown:
                    skeletonGraphic.Skeleton.FindSlot(browRSlot).SetColor(brownBrow); skeletonGraphic.Skeleton.FindSlot(browLSlot).SetColor(brownBrow);
                    skeletonGraphic.Skeleton.FindSlot(cheekRSlot).SetColor(brownCheek); skeletonGraphic.Skeleton.FindSlot(cheekLSlot).SetColor(brownCheek);
                    break;
                case CGBData.colors.blue:
                    skeletonGraphic.Skeleton.FindSlot(browRSlot).SetColor(blueBrow); skeletonGraphic.Skeleton.FindSlot(browLSlot).SetColor(blueBrow);
                    skeletonGraphic.Skeleton.FindSlot(cheekRSlot).SetColor(blueCheek); skeletonGraphic.Skeleton.FindSlot(cheekLSlot).SetColor(blueCheek);
                    break;
            }
        }       
        
    }

}