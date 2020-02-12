using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pig : MonoBehaviour
{
    public float maxSpeed = 10; //死亡的最大速度
    public float minSpeed = 5;//最小速度
    private SpriteRenderer render;
    public Sprite hurt;
    public GameObject boom;
    public GameObject score; //加分特效
    public bool ispig = false;
    public AudioClip hurtclip;
    public AudioClip dead;
    public AudioClip birdcollision;
    private void Awake()
    {
        render = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D collision) //碰撞到物体
    {
        if (collision.gameObject.tag == "Player")
        {
            AudioPlay(birdcollision);
            collision.transform.GetComponent<bird>().Hurt(); //小鸟受伤
                }
        if(collision .relativeVelocity .magnitude >maxSpeed )//直接死亡
        {
            Dead();
        }
        else if(collision.relativeVelocity.magnitude < maxSpeed&& collision.relativeVelocity.magnitude > minSpeed)
        {//受伤
            render.sprite = hurt;
            AudioPlay(hurtclip);
            maxSpeed -=1;//将死亡的最大速度减小
        }
                }
    public void Dead()
    {
         if (ispig)
        {
            gamemanager.instance.pigs.Remove(this); //从游戏中清除
        }
        Destroy(gameObject);
        Instantiate(boom, transform.position, Quaternion.identity);//生产特效
        GameObject go = Instantiate(score, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);//在物体上方产生
        Destroy(go, 1.5f);//1.5秒后清除
        AudioPlay(dead);
    }
    private void AudioPlay(AudioClip clip)
    {
        AudioSource.PlayClipAtPoint(clip, transform.position);
    }
}
