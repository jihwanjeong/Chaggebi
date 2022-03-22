using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Chaggebi
{
    public class ChaggebiPanelManager : MonoBehaviour
    {
        public Button EnableInventory;
        public Button ExitInventory;
        public GameObject Inventory;

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
        }

    }
}
