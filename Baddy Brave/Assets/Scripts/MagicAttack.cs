using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicAttack : MonoBehaviour
{
    Vector2 moveAngle;
    KeyCode nowKeyCode;
    CircleCollider2D myCollider2D;
    private bool moving;
    // Start is called before the first frame update
    private void Awake()
    {
        myCollider2D = GetComponent<CircleCollider2D>();
        moving = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (moving && Input.GetKey(nowKeyCode))
        {
            transform.Translate(moveAngle);
        }
    }

    private void Update()
    {
        if (moving && Input.GetKeyUp(nowKeyCode))
        {
            Burst();
        }
    }

    public void MagicStart(Vector2 vector2,KeyCode keyCode)
    {
        moveAngle = vector2;
        nowKeyCode = keyCode;
    }

    private void Burst()
    {
        moving = false;
        myCollider2D.isTrigger = false;
        Invoke("DestroyThis", 1.0f);
    }

    private void DestroyThis()
    {
        Destroy(this.gameObject);
        GameObject.FindWithTag("Player").GetComponent<PlayerController>().CanMoveTrue();    //プレイヤーが動けるように
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<IHitObject>().HitObj();
    }
}
