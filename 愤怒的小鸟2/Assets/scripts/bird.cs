using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class bird : MonoBehaviour
{
    private bool isClick = false;
    public Transform rightPos;//右树枝
    public float maxDis = 1.2f;
    [HideInInspector]//隐藏spring
    public SpringJoint2D sp;//弹簧
    protected Rigidbody2D rg;//刚体
    public Transform leftPos;//左树枝
    public LineRenderer right;//右边划线
    public LineRenderer left;//左边划线
    public GameObject boom;//爆炸特效
    protected  Test mytrail;//拖尾特效
    [HideInInspector]
    public bool canMove = false;
    public float smooth=3;
    public AudioClip select;//音效
    public AudioClip flying;
    public bool isfly = false;
    [HideInInspector]
    public bool isReleased = false;
    public Sprite hurt;//受伤的图片
    protected  SpriteRenderer render; 
    private void Awake()
    {
        sp = GetComponent<SpringJoint2D>();
        rg = GetComponent<Rigidbody2D>();//获取该游戏物体身上的组件
        mytrail = GetComponent<Test>();
        render = GetComponent<SpriteRenderer>();
    }
    private void OnMouseDown() //鼠标按下
    {  if (canMove) //如果可以移动
        {
            isClick = true; //鼠标点击才有效
            rg.isKinematic = true; //进行物理计算
            AudioPlay(select);
        }
    }
    private void OnMouseUp()//鼠标抬起
    {
        if (canMove) //如果可以移动
        {
            isClick = false; //鼠标点击才失效
            rg.isKinematic = false;//小鸟飞出时取消物理计算
            Invoke("fly", 0.1f); //唤醒飞行函数
            //让划线组件消失
            right.enabled = false;
            left.enabled = false;
            canMove = false;//不能移动
            AudioPlay(flying);
        }
    }
    protected virtual void Update()
    {   if (EventSystem.current.IsPointerOverGameObject()) //判断是否点击了UI界面
            return;
        if(isClick) 
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);//让小鸟跟着鼠标移动
            transform.position += new Vector3(0, 0, 10);//z轴加10
            if(Vector3.Distance(transform .position ,rightPos .position )>maxDis )
            {
                Vector3 pos = (transform.position - rightPos.position).normalized;
                pos *= maxDis;
                transform.position = pos + rightPos.position;
            }
            Line();//划线
        }
        //相机跟随
        float posX = transform.position.x;
        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, 
            new Vector3(Mathf.Clamp(transform.position.x, 4.31f, 20),//将物体限制在4.31到20之间
            Camera .main .transform.position .y,Camera.main.transform.position.z),//相机与物体的相对位置
            smooth * Time.deltaTime);
        if(isfly) //在空中飞行
        {
            if(Input.GetMouseButtonDown (0))
            {
                showskill();
            }
        }
    }
    private void fly()
    {
        isReleased = true;
        isfly = true;
        sp.enabled = false; //使弹簧失活
        Invoke("next", 5); //6秒后启用下一只小鸟
        mytrail.StartTrails(); //产生拖尾效果
    }
    private void Line()
    {
        right.enabled = true;
        left.enabled = true;
        right.SetPosition(0, rightPos.position);
        right.SetPosition(1, transform.position);
        left.SetPosition(0, leftPos.position);
        left.SetPosition(1, transform.position);
    }
    protected virtual void next()
    {
        gamemanager.instance.birds.Remove(this); //从数组中清除
        Destroy(gameObject);
        Instantiate(boom, transform.position, Quaternion.identity);//产生爆炸特效
        gamemanager.instance.nextbird(); //下一只小鸟上来
    }
    private void OnCollisionEnter2D(Collision2D collision) //碰到物体
    {
        isfly = false; //不在飞行
        mytrail.ClearTrails(); //取消拖尾效果
        
    }
    private void AudioPlay(AudioClip clip) //播放音乐 
    {
        AudioSource.PlayClipAtPoint(clip, transform.position);
    }
    public virtual void showskill() //炫技
    {
        isfly = false;
    }
    public void Hurt()
    {
        render.sprite = hurt;
    }
}
