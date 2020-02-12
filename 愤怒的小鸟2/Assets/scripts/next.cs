using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class next : MonoBehaviour
{
   public void nextlevel()
    {   
        string str = PlayerPrefs.GetString("nowlevel");
        int i = 0;
        if (str.Length==6)
        {
             i = str[5] - 48 + 1;
        }
        else
        {
            i = (str[5] - 48) * 10 + (str[6] - 48) + 1;
        }
        gamemanager.instance.savaData();
        PlayerPrefs.SetString("nowlevel", "level"+i.ToString() );//创建字符串
        SceneManager.LoadScene(2);
        
    }
}
