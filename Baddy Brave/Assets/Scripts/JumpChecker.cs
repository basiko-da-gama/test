using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpChecker : MonoBehaviour
{
    PlayerController playerController;

    private void Awake()
    {
        playerController = gameObject.transform.parent.GetComponent<PlayerController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //地面に到着したらジャンプ可能に
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            playerController.JumpPossible = true;
        }
    }

    //地面から離れたらジャンプ不可
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            playerController.JumpPossible = false;
        }
    }
}
