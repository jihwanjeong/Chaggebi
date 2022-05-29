using UnityEngine;
using UnityEngine.UI;

public class TeabagHandler : MonoBehaviour
{
    public Teabag teabag;
    public Image image;
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    int count = 1;
    ResourceAnimator resourceAnimator;

    public void SetTeabagInfo(string _id, int _starTier)
    {
        resourceAnimator = GameObject.Find("collectItem").GetComponent<ResourceAnimator>();
        teabag = DataBase.instance.FindTeabag(_id);
        if(star1!=null)
        {
            if (_starTier == 1)
            {
                teabag.count_star1 = count;
                star1.SetActive(true);
                star2.SetActive(false);
                star3.SetActive(false);
            }
            else if (_starTier == 2)
            {
                teabag.count_star2 = count;
                star2.SetActive(true);
                star1.SetActive(false);
                star3.SetActive(false);
            }
            else if (_starTier == 3)
            {
                teabag.count_star3 = count;
                star3.SetActive(true);
                star1.SetActive(false);
                star2.SetActive(false);
            }
        }
        image.sprite = teabag.sprite;
    }

    public void ClickTeabag()
    {
        PlayerData.instance.AddTeabag(teabag.id, teabag.count_star1, teabag.count_star2, teabag.count_star3);
        resourceAnimator.GetItem(teabag.sprite, transform);
        Destroy(gameObject);
    }
}
