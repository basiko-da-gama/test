using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour,IHitObject
{
    protected Rigidbody2D myRigid;
    protected bool direction;   //trueで右向き、falseで左向き 
    [SerializeField] protected float limitRight, limitLeft; //左右の移動距離
    protected readonly float power = 5.0f;  //移動のための力
    protected float speed;  //移動スピード。エネミー毎にstartで設定
    protected float startX; //最初のX座標
    // Start is called before the first frame update
    protected virtual void Start()
    {
        myRigid = GetComponent<Rigidbody2D>();
        startX = transform.position.x;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        EnemyMove();
    }

    protected abstract void EnemyMove();    //エネミーの移動

    public void HitObj()
    {
        Damage();
    }

    protected virtual void Damage()
    {
        Destroy(this.gameObject);
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            /*
            hitObject.GetComponent<Player>().death();
            GameObject.Find("GameDirecter").GetComponent<GameDirecter>().GameOver();
            */          
        }
    }
}
