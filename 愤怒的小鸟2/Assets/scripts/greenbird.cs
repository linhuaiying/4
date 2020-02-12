using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class greenbird : bird
{ public override void showskill()
    {
        base.showskill();
        Vector3 speed = rg.velocity;
        speed.x *= -1; //将速度反向
        rg.velocity = speed;
    }
  
}
