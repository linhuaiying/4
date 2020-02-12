using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Return : MonoBehaviour //返回按键
{     public GameObject panel;
      public GameObject map;
      public void Returning()
    {
        panel.SetActive(false);
        map.SetActive(true);
    }
     

}
