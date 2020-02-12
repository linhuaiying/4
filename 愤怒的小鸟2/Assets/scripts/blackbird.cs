using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blackbird : bird
{
    public List<pig> blocks = new List<pig>();
    public AudioClip collsion;
   
    //进入触发区域
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision .gameObject .tag =="enemy")
        {
            blocks.Add(collision.gameObject.GetComponent<pig>());
        }
    }
    //不在触发区域
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            blocks.Remove (collision.gameObject.GetComponent<pig>());
        }
    }
    public override void showskill()
    {
        base.showskill();
        if(blocks.Count >0&&blocks !=null)
        {
            for(int i=0;i<blocks .Count;i++)
            {
                if (blocks[i] == null)
                    continue;
                blocks[i].Dead();
            }
        }
        onClear();
    }
    private void onClear()
    {
        rg.velocity = Vector3.zero;
        Instantiate(boom, transform.position, Quaternion.identity);
        render.enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
        mytrail.ClearTrails();
    }
    protected override void next() //不重复产生爆炸特效
    {
        gamemanager.instance.birds.Remove(this); //从数组中清除
        Destroy(gameObject);
        gamemanager.instance.nextbird(); //下一只小鸟上来
    }

    protected override void Update()
    {
        base.Update();
        if (isReleased == true && Input.GetMouseButtonDown(0))
        {
            showskill();
            AudioSource.PlayClipAtPoint(collsion, transform.position);
        }
    }

}
