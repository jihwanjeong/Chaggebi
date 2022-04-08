using UnityEngine;
using UnityEngine.UI;

public class TeabagHandler : MonoBehaviour
{
    public Teabag teabag;
    public Image image;

    public void SetTeabagInfo(Teabag _teabag)
    {
        teabag = _teabag;
        image.sprite = teabag.sprite;
    }
}
