using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class win : MonoBehaviour
{
    public GameObject next;
    //动画播放星星
   public void show()
    {
        gamemanager.instance.showstars();
    }
    public void shownext() //没做第5/14/24关，所以第4/13/23关取消下一关按键
    {
        if(PlayerPrefs.GetString("nowlevel")=="level4"||
            PlayerPrefs.GetString("nowlevel") == "level13"|| 
            PlayerPrefs.GetString("nowlevel") == "level23")
        {
            next.SetActive(false);
        }
    }
}
