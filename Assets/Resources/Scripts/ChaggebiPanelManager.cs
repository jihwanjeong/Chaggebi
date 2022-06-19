using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Chaggebi
{
    public class ChaggebiPanelManager : MonoBehaviour
    {
        public Button TestBtn;
        public Button EnableInventory;
        public Button ExitInventory;
        public GameObject Inventory;
        public GameObject CGBManagePanel;
        public float cameraSpeed = 5.0f;
        public GameObject Camera;
        public GameObject UI;
        public Button exitCgbManage;
        CGBMotionController controller;
        Coroutine testCor;

        public void InventoryPanelControl()
        {
            if (Inventory.activeSelf == true)
                Inventory.SetActive(false);
            else
                Inventory.SetActive(true);

        }
       
        void Start()
        {
            EnableInventory.onClick.AddListener(InventoryPanelControl);
            ExitInventory.onClick.AddListener(InventoryPanelControl);
            exitCgbManage.onClick.AddListener(CloseCGBManagePanel);
            Inventory.SetActive(false);
        }
        public void ClickTest()
        {
            if (testCor == null)
                testCor = StartCoroutine(Test());
            else StopCoroutine(testCor);
        }
        IEnumerator Test()
        {           
            int i = 0;
            Debug.Log(i);
            while (true)
            {
                yield return new WaitForSeconds(3);
                i++;
                Debug.Log(i);
            }
        }
        public void ClickCGB(CGBMotionController _controller)
        {
            if(_controller.isPlaced)
            {
                if (PlayerData.instance.interactingCGB == null || PlayerData.instance.interactingCGB == _controller.cgb)
                {
                    controller = _controller;
                    UI.SetActive(false);
                    StartCoroutine(MoveCamToCgb(controller.transform.position));
                }
            }
        }

        IEnumerator MoveCamToCgb(Vector3 _position)
        {
            Vector3 startPos = Camera.transform.position;
            Vector3 endPos= new Vector3(_position.x, _position.y, 0);
            float time = 0;
            while (time < 1)
            {
                time += 1.5f * Time.deltaTime;
                Camera.transform.position = Vector3.Lerp(startPos, endPos, time);
                yield return new WaitForEndOfFrame();
            }
            CGBManagePanel.transform.position = new Vector3(_position.x, _position.y, 100);
            CGBManagePanel.SetActive(true);
            //Vector3 dir = _position - Camera.transform.position;
            //Vector3 moveVector = new Vector3(dir.x * cameraSpeed * Time.deltaTime, dir.y * cameraSpeed * Time.deltaTime, 0.0f);
            //Camera.transform.Translate(moveVector);
            //yield return new WaitForEndOfFrame();
        }

        void CloseCGBManagePanel()
        {
            CGBManagePanel.SetActive(false);
            Camera.transform.position = new Vector3(0f, 0f, 0f);
            UI.SetActive(true);
            PlayerData.instance.interactingCGB = null;
            controller.moveCor = StartCoroutine(controller.RandomMove());
        }
    }
}
