using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class CameraFolow : MonoBehaviour
{
    //A��� GameObject���� ����
    public GameObject A;
    Transform AT;

    void Start()
    {

    }
    void Update()
    {
        AT = A.transform; // Memory Error Point?
        transform.position = new Vector3(AT.position.x, AT.position.y, transform.position.z);
    }
}