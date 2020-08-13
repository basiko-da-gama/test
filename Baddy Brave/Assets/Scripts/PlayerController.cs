using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private readonly float walkPower = 5;  //移動のための力
    private readonly float walkSpeed = 5;  //最大速度
    private new Rigidbody2D rigidbody2D;
    private bool jumpPossible;  //ジャンプが可能かどうか
    private bool canMove;   //移動などが可能かどうか
    [SerializeField] GameObject magicAttackObj;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            MoveAction();
            Action();
        }
    }

    //移動処理
    private void Movement(float power,float speed)
    {
        rigidbody2D.AddForce(new Vector2(power, 0));
        if (Mathf.Abs(rigidbody2D.velocity.x) > Mathf.Abs(speed))
        {
            rigidbody2D.velocity = new Vector2(speed, rigidbody2D.velocity.y);
        }
    }

    public bool JumpPossible
    {
        set { jumpPossible = value; }
    }

    private void MoveAction()
    {
        float wkp = 0;
        float wks = 0;
        if (Input.GetKeyDown(KeyCode.Space))　//ジャンプ
        {
            if (jumpPossible)
            {
                JumpAction();
            }
        }
        if (Input.GetKey(KeyCode.RightArrow))   //右移動
        {
            wkp = walkPower;
            wks = walkSpeed;
        }
        if (Input.GetKey(KeyCode.LeftArrow))   //左移動
        {
            wkp = -walkPower;
            wks = -walkSpeed;
        }
        if (Input.GetKey(KeyCode.LeftShift))    //走る場合
        {
            wkp *= 2;
            wks *= 2;
        }
        Movement(wkp, wks); //移動処理
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))  //停止
        {
            rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
        }
    }

    public void JumpAction()
    {
        rigidbody2D.AddForce(new Vector2(0, 300));
    }

    private void Action()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Vector2 newVector2 = transform.position;
            newVector2.x -= 1.0f;
            var magic = MagicMake(newVector2);
            magic.GetComponent<MagicAttack>().MagicStart(new Vector2(-0.1f, 0),KeyCode.A);
        } else if (Input.GetKeyDown(KeyCode.W)){
            Vector2 newVector2 = transform.position;
            newVector2.y += 1.0f;
            var magic = MagicMake(newVector2);
            magic.GetComponent<MagicAttack>().MagicStart(new Vector2(0, 0.1f),KeyCode.W);
        } else if (Input.GetKeyDown(KeyCode.D)){
            Vector2 newVector2 = transform.position;
            newVector2.x += 1.0f;
            var magic = MagicMake(newVector2);
            magic.GetComponent<MagicAttack>().MagicStart(new Vector2(0.1f, 0),KeyCode.D);
        }
    }

    private GameObject MagicMake(Vector2 posi)
    {
        canMove = false;
        rigidbody2D.velocity = new Vector2(0, 0);
        var magic = Instantiate(magicAttackObj);
        magic.transform.position = posi;
        return magic;
    }

    public void CanMoveTrue()
    {
        canMove = true;
    }

    private void Damage()
    {
        Debug.Log("damage");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Damage();
        }
    }
}
