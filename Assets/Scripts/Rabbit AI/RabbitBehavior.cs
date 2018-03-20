using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitBehavior : MonoBehaviour {
    public float speed = 1f;
    private Vector3 player;
    private Vector2 playerDirection;
    public float xx;
    public float foundDis = 5f;
    public float attackDis = 0.5f;
    public float yy;
    public Rigidbody2D rb2d;

    protected Animator anim;

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        player = GameObject.Find("Player").transform.position;
        xx = player.x - transform.position.x;
        yy = player.y - transform.position.y;

        if (xx > 0) anim.SetFloat("Direction", 1f);
        else anim.SetFloat("Direction", 0);

        float dis = Mathf.Sqrt(xx * xx + yy * yy);
        if (dis < foundDis) {
            anim.SetBool("FoundPlayer", true);
            if (dis < attackDis)
            {
                anim.SetBool("Attack", true);
            }
            else {
                anim.SetBool("Attack", false);
            }
        }
        else
        {
            anim.SetBool("FoundPlayer", false);
            anim.SetBool("Attack", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Player p = collision.gameObject.GetComponent<Player>();
            p.UpdateHealth(p.health - 10);
            transform.position += xx > 0 ? Vector3.left * 0.1f : Vector3.right * 0.1f;
        }
    }

}
