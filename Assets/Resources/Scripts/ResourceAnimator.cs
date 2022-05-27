using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceAnimator : MonoBehaviour
{
    public float speed = 1;
    public Transform testTeabagPanel;
    public Transform cgbInvenBtn;
    public Transform goldBtn;
    public Image[] images;
    public ParticleController particleController;
  
    void Start()
    {
        foreach (Image image in images) image.enabled = false;
    }

    public void Test(GameObject _teabag)
    {
        GameObject teabag = Instantiate(_teabag, testTeabagPanel);
        teabag.GetComponent<TeabagHandler>().SetTeabagInfo("Green Tea", 1);
        teabag.transform.localPosition = new Vector3(Random.Range(-3, 5), 0, 0);
    }
    public void GetItem(Sprite _sprite, Transform _startPos)
    {
        for (int i = 0; i < images.Length; i++)
        {
            if(!images[i].enabled)
            {
                images[i].transform.localScale = new Vector3(1, 1, 1);
                images[i].sprite = _sprite;
                images[i].enabled = true;
                StartCoroutine(MoveItem(images[i].transform, _startPos.position, cgbInvenBtn.position));
                break;
            }
        }
    }

    IEnumerator MoveItem(Transform _item, Vector3 startPos, Vector3 endPos)
    {
        float time = 0;
        while (time < 1) 
        {
            time += speed * Time.deltaTime;
            _item.position = Vector3.Lerp(startPos, endPos, time);
            _item.position = new Vector3(_item.position.x, _item.position.y, 100 );
            yield return new WaitForEndOfFrame();
        }
        _item.gameObject.GetComponent<Animation>().Play("itemGet");
        particleController.Play(2, 0, cgbInvenBtn.position);
        yield return new WaitForSecondsRealtime(0.8f);
        _item.gameObject.GetComponent<Image>().enabled = false;
        yield return null;
    }
}
