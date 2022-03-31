using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CGBUpgrade : MonoBehaviour
{
    
        
        public Slider StatsBAr;
        public float maxStats;
        public float currentStats;

        void Update()
        {
           
            StatsBAr.value = currentStats / maxStats;
        }
    
}
