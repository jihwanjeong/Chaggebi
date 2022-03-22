using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Chaggebi
{
    public class GardenPanelManager : MonoBehaviour
    {
        public GameObject ChaggebiSelectPanel;
        public GameObject ShopPanel;
        public GameObject TeacupPanel;
        public Button ChaggebiPanelEnable;
        public Button ShopPanelEnable;
        public Button ChaggebiPanelExit;
        public Button ShopPanelExit;
        public Button TeacupPanelEnable;
        public Button TeacupPanelExit;
        public Button MoveToCafeScene;
        public Text TotalGold;
        GoldManager Gmanager;
        public GameObject ButtonUIPanel;
        public GameObject GardenPanel;
        public Transform slotsParent;
        CGBSlot[] slots;

        public void ChaggebiPanelControl()
        {
            if (ChaggebiSelectPanel.activeSelf == true)
            {
                ChaggebiSelectPanel.SetActive(false);
                ButtonUIPanel.SetActive(true);
                GardenPanel.SetActive(true);
            }
            else
            {
                UpdateInven();
                ChaggebiSelectPanel.SetActive(true);
                ButtonUIPanel.SetActive(false);
                GardenPanel.SetActive(false);
            }

        }
        public void ShopPanelControl()
        {
            if (ShopPanel.activeSelf == true)
                ShopPanel.SetActive(false);
            else
                ShopPanel.SetActive(true);

        }
        public void TeacupPanelControl()
        {
            if (TeacupPanel.activeSelf == true)
            {
                TeacupPanel.SetActive(false);
                ButtonUIPanel.SetActive(true);
                GardenPanel.SetActive(true);
            }
            else
            {
                TeacupPanel.SetActive(true);
                ButtonUIPanel.SetActive(false);
                GardenPanel.SetActive(false);
            }

        }
        void UpdateInven()
        {
            int cgbCount = PlayerData.instance.playerCGBs.Count;
            for (int i = 0; i < slots.Length; i++)
            {
                if (i < cgbCount)
                {
                    slots[i].AddCGB(PlayerData.instance.playerCGBs[i]);
                    slots[i].slotNum = i;
                }
                else
                {
                    slots[i].RemoveCGB();
                }
            }
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
            TeacupPanelEnable.onClick.AddListener(TeacupPanelControl);
            TeacupPanelExit.onClick.AddListener(TeacupPanelControl);
            MoveToCafeScene.onClick.AddListener(MoveToCafe);
            Gmanager = GameObject.Find("Gold Manager").GetComponent<GoldManager>();
            slots = slotsParent.GetComponentsInChildren<CGBSlot>();
        }


        void Update()
        {
            TotalGold.GetComponent<Text>().text = Gmanager.gold.ToString();

        }
    }
}
