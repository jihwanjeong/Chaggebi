using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Chaggebi
{
    public class GardenSceneManager : MonoBehaviour
    {
        public GameObject ChaggebiSelectPanel;
        public GameObject ShopPanel;
        public Button ChaggebiPanelEnable;
        public Button ShopPanelEnable;
        public Button ChaggebiPanelExit;
        public Button ShopPanelExit;
        public Button MoveToCafeScene;

        public void ChaggebiPanelControl()
        {
            if (ChaggebiSelectPanel.activeSelf == true)
                ChaggebiSelectPanel.SetActive(false);
            else
                ChaggebiSelectPanel.SetActive(true);

        }
        public void ShopPanelControl()
        {
            if (ShopPanel.activeSelf == true)
                ShopPanel.SetActive(false);
            else
                ShopPanel.SetActive(true);

        }

        public void MoveToCafe()
        {
            SceneManager.LoadScene("Cafe");
        }
        public void MoveToGarden()
        {
            SceneManager.LoadScene("Main Garden");
        }
        void Start()
        {
            ChaggebiPanelEnable.onClick.AddListener(ChaggebiPanelControl);
            ChaggebiPanelExit.onClick.AddListener(ChaggebiPanelControl);
            ShopPanelEnable.onClick.AddListener(ShopPanelControl);
            ShopPanelExit.onClick.AddListener(ShopPanelControl);
            MoveToCafeScene.onClick.AddListener(MoveToCafe);
        }


        void Update()
        {

        }
    }
}
