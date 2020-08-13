using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemy : EnemyBase
{
    protected override void Start()
    {
        base.Start();
        speed = 2.0f;
    }

    protected override void EnemyMove()
    {
        if (direction)
        {
            myRigid.AddForce(new Vector2(power, 0));
            if(myRigid.velocity.x > speed)
            {
                myRigid.velocity = new Vector2(speed, 0);
            }
        }
        else
        {
            myRigid.AddForce(new Vector2(-power, 0));
            if (myRigid.velocity.x < -speed)
            {
                myRigid.velocity = new Vector2(-speed, 0);
            }
        }
        if(transform.position.x > startX + limitRight)
        {
            myRigid.velocity = new Vector2(0,0);
            direction = false;
        } else if(transform.position.x < startX - limitLeft)
        {
            myRigid.velocity = new Vector2(0, 0);
            direction = true;
        }
    }

}
