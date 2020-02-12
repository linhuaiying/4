using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class gamemanager : MonoBehaviour
{
    public List<bird> birds; //小鸟数组
    public List<pig> pigs;//猪数组
    public static gamemanager instance; //本类对象
    private Vector3 origion; 
    public GameObject win; //赢的面板
    public GameObject lose;//输的面板
    public GameObject[] stars; //3颗
    private int starsNum = 0; //当前关卡的星星数量
    private int totalNum = 30; //全部的关卡数量

    private void Awake()
    {
        instance = this;
        if (birds.Count > 0)
            origion = birds[0].transform.position; //第一只小鸟的位置
    }
    private void Start()
    {
        initialized();
    }
    private void initialized()//初始化小鸟
    {
        for (int i = 0; i < birds.Count; i++)
        {
            if (i == 0)
            {
                birds[i].transform.position = origion; //将后面的小鸟的位置设置成与第一只小鸟相同
                birds[i].enabled = true; 
                birds[i].sp.enabled = true;
                birds[i].canMove = true;

            }
            else
            {
                birds[i].enabled = false; //使其他小鸟失活
                birds[i].sp.enabled = false;
                birds[i].canMove = false;
            }
        }
    }
    private void setlose()
    {
        lose.SetActive(true);
    }
    private void setwin()
    {
        win.SetActive(true);
    }
    private void Update()
    {
        if (pigs.Count > 0&&birds.Count==0)
        {


            //输了
            Invoke("setlose", 5);
            return;
            
        }
        else if(pigs.Count==0)
        {
            //赢了
            Invoke("setwin", 5);
            return;
        }

    }
    //判断游戏逻辑
    public void nextbird()
    {
        if (birds.Count > 0)
        {
            //下一只
            initialized();
        }
    }
    public void showstars()
    {
        StartCoroutine("show"); //开启协程
    }
    IEnumerator show()  //协程
    {

        for (; starsNum < birds.Count + 1; starsNum++)
        {  
            if(starsNum>=stars .Length)
            {
                break;
            }
            yield return new WaitForSeconds(0.2f);//隔0.2秒出现一颗星星
            stars[starsNum].SetActive(true);//显示星星
        }
    }
    public void replay()
    {
        savaData(); //保存当前星星数     
        SceneManager.LoadScene(2);
    }
    public void home()
    {   
        savaData();
        SceneManager.LoadScene(1);
       
    }
    public void savaData()
    {   if (starsNum > PlayerPrefs.GetInt(PlayerPrefs.GetString("nowlevel")))
        {
            PlayerPrefs.SetInt(PlayerPrefs.GetString("nowlevel"), starsNum); //把当前星星数量存到对应关卡
        }
    //存储所有的星星个数
        int sum=0;
    for(int i=1;i<=totalNum;i++) //遍历所有关卡
        {
            sum += PlayerPrefs.GetInt("level" + i.ToString());
        }
        PlayerPrefs.SetInt("totalNum", sum); //totalNum保存所有关卡的星星数量
    }
    
}
