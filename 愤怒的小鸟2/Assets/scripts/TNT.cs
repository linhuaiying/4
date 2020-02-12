using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TNT : MonoBehaviour
{
    public GameObject boom;
    public List<pig> blocks = new List<pig>();
    private float maxSpeed=3;
    public AudioClip collison;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude > maxSpeed) //产生爆炸
        {
            
            Instantiate(boom, transform.position, Quaternion.identity);
            AudioPlay(collison);
            Destroy(gameObject);

            if (blocks.Count > 0 && blocks != null)
                {
                for (int i = 0; i < blocks.Count; i++)
                {   if (blocks[i] == null)
                        continue;
                    blocks[i].Dead();
                }
            }
          
        }
        
    }
    //进入触发区域
    private void OnTriggerEnter2D(Collider2D collision)
    {
        blocks.Add(collision.gameObject.GetComponent<pig>());
    }
    //不在触发区域
    private void OnTriggerExit2D(Collider2D collision)
    {
        
            blocks.Remove(collision.gameObject.GetComponent<pig>());
        
    }
    private void AudioPlay(AudioClip clip)
    {
        AudioSource.PlayClipAtPoint(clip, transform.position);
    }
}
