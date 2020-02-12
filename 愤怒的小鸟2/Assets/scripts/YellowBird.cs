using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowBird : bird
{//重写方法
    public override void showskill()
    {
        base.showskill();
        rg.velocity *= 2; //加快速度
    }
}
