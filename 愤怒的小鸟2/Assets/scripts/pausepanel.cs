using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pausepanel : MonoBehaviour
{
    private Animator anim; //动画状态机
    public GameObject button;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    public void retry() //重新玩
    {
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
        
    }
    //点击pause按钮后触发pause事件
    public void pause()
    {  //1、播放pause动画
        anim.SetBool("ispause", true);
        button.SetActive(false); //暂停按钮消失
        if(gamemanager.instance.birds.Count>0)
        {
            if(gamemanager.instance.birds[0].isReleased==false) //如果没有飞出
            {
                gamemanager.instance.birds[0].canMove = false; //不能再点击
            }
        }
    }
    public void home() //回到主菜单
    {
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
    public void resume() //继续
    {
        //播放resume动画
        Time.timeScale = 1;
        anim.SetBool("ispause", false);
        if (gamemanager.instance.birds.Count > 0)
        {
            if (gamemanager.instance.birds[0].isReleased == false) //没有飞出
            {
                gamemanager.instance.birds[0].canMove = true; //可以点击
            }
        }
    }
    public void pauseAnimend()
    {
        //播放完动画暂停
        Time.timeScale = 0;
    }
    public void resumeAnimend()
    {
        //播放完动画继续
        Time.timeScale = 1;
        button.SetActive(true); //按钮重新出现
    }
}
