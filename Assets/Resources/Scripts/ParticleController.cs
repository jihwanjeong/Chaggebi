using System.Collections;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public ParticleSystem[] effs;
    public void Play(int _index,float _delaysec, Vector3 _position)
    {
        effs[_index].transform.position = _position;
        StartCoroutine(BlingParticle(_index, _delaysec));
    }

    IEnumerator BlingParticle(int _index, float _delaysec)
    {
        yield return new WaitForSecondsRealtime(_delaysec);
        effs[_index].gameObject.SetActive(true);
    }
}
