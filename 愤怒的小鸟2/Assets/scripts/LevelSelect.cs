using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelect: MonoBehaviour
{
    private bool isSelect = false;
    public Sprite levelbg;//关卡背景图案
    private Image imag;
    public GameObject[] stars;

    private void Awake()
    {
        imag = GetComponent<Image>();
    }
    private void Start()
    {
        if(transform.parent .GetChild(0).name==gameObject.name)//如果当前关卡是第一关
        {
            isSelect = true;
        }
        else
        { //判断当前关卡是否可选择
            int beforeNum = int.Parse(gameObject.name) - 1; //判断前一关卡的星星数量
            if(PlayerPrefs.GetInt("level"+beforeNum.ToString())>0)
            {
                isSelect = true;
            }
        }
        if(isSelect)
        {
            imag.overrideSprite = levelbg;//解锁图片
            transform.Find("num").gameObject.SetActive(true);
            int count = PlayerPrefs.GetInt("level" + gameObject.name);//获取现在关卡的名字，然后获得对应的星星个数
            if(count>0)
            {
                for(int i=0;i<count;i++)
                {
                    stars[i].SetActive(true); //显示当前关卡的星星
                }
            }
        }
    }
    public void Selected()
    {
      
        if (isSelect)
        {   
            PlayerPrefs.SetString("nowlevel", "level" + gameObject.name);//创建字符串
            SceneManager.LoadScene(2);
            
        }
    }
}
