using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    /*public GameObject player;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }*/
    public float cameraSpeed = 5.0f;

    public GameObject player;
    public GameObject ui;
    public GameObject ui2;

    private void Update()
    {
        Vector3 dir = player.transform.position - this.transform.position;
        Vector3 moveVector = new Vector3(dir.x * cameraSpeed * Time.deltaTime, dir.y * cameraSpeed * Time.deltaTime, 0.0f);
        this.transform.Translate(moveVector);
        ui.transform.Translate(moveVector);
        ui2.transform.Translate(moveVector);

    }
}