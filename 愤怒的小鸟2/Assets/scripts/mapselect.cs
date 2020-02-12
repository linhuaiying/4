using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mapselect : MonoBehaviour
{
    public int starsNum = 0;//开启新地图的星星数量
    private bool isSelect = false;
    public GameObject locks;//锁的标志
    public GameObject stars;//星星图案
    public GameObject panel;//关卡面板
    public GameObject map;//地图封面
    public Text starstext;
    public int startnum;//该地图第一关
    public int endnum;//该地图最后一关
    private void Start()
    {
        //PlayerPrefs.DeleteAll(); //可删除该游戏所有数据
        if(PlayerPrefs.GetInt ("totalNum",0)>=starsNum)
        {
            isSelect = true;
        }
        if(isSelect==true)
        {
            locks.SetActive(false);
            stars.SetActive(true);
            int counts = 0;
            for(int i=startnum;i<=endnum;i++) //记录当前地图的所有的星星总数
            {
                counts += PlayerPrefs.GetInt("level" + i.ToString(), 0);
               
            }
            int allnum = (endnum - startnum + 1) * 3;
            starstext.text = counts.ToString()+"/"+allnum.ToString();
            
        }
    }
    public void Selected()
    {
        if(isSelect)
        {
            panel.SetActive(true);
            map.SetActive(false);
        }
    }
    
}
