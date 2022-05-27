using System.Collections;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public ParticleSystem[] effs1;
    public ParticleSystem[] effs2;

    public void Play(int _index,float _delaysec, Vector3 _position)
    {
        effs1[_index].transform.position = _position;
        effs2[_index].transform.position = _position;
        StartCoroutine(BlingParticle(_index, _delaysec));
    }

    IEnumerator BlingParticle(int _index, float _delaysec)
    {
        yield return new WaitForSecondsRealtime(_delaysec);
        if(!effs1[_index].gameObject.activeSelf) effs1[_index].gameObject.SetActive(true);
        else effs2[_index].gameObject.SetActive(true);
    }
}
