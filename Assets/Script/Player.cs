using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 20f;
    public float jumpForce = 30f;
    public GameManager manager;

    private Rigidbody2D rb;
    BoxCollider2D col;

    Animator anim;

    public float maxJumpVelocity = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        col = GetComponent<BoxCollider2D>();

        transform.position = new Vector2(0f, 0.1f);
    }

    void FixedUpdate()
    {
        float moveDirection = 0;
        int moveHorizontal = 0;


        if (Input.GetButton("Horizontal"))
        {
            moveDirection = Input.GetAxis("Horizontal");
            manager.isStart = true;
        }
        else moveDirection = 0;



        rb.linearVelocity = new Vector2(moveDirection * moveSpeed, rb.linearVelocity.y);

        if (moveDirection > 0)
        {
            moveHorizontal = 1;
            anim.SetInteger("Horizontal", moveHorizontal);
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (moveDirection < 0)
        {
            moveHorizontal = -1;
            anim.SetInteger("Horizontal", moveHorizontal);
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else anim.SetInteger("Horizontal", 0);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (IsGrounded()) {
                anim.SetBool("isGround", false);
                Jump();
            }

        }

        if (IsMonster())
        {
            Jump();
        }

        Debug.DrawRay(rb.position, Vector2.down, new Color(1, 0, 0));
        

        var vel_norm = rb.linearVelocity.normalized;

        

        if (vel_norm.y != 0) anim.SetFloat("JumpBlend", rb.linearVelocity.normalized.y);
        else
        {
            anim.SetBool("isGround", true);
            anim.SetFloat("JumpBlend", 0);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Monster") || collision.gameObject.layer == LayerMask.NameToLayer("Death"))
        {
            manager.isDeath = true;
            Debug.Log("�÷��̾ �׾����ϴ�");
            // ���⼭ UI ��� ȣ�� ����
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("item"))
        {
            manager.isClear = true;
            Debug.Log("������ Ŭ�����߽��ϴ�.");
            // ���⼭ UI ��� ȣ�� ����
        }
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        // ���� �� Y�ӵ� ����
        if (rb.linearVelocity.y > maxJumpVelocity)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, maxJumpVelocity);
        }

    }

    bool IsGrounded()
    {
        // Collider �� ����ũ�⸦ �̿��� ĳ������ ���ʿ� Box ������� �浹 üũ�� �մϴ�.
        var ray = Physics2D.BoxCast(col.bounds.center, new Vector2(col.bounds.size.x, 1.2f),
           0f,
           Vector2.down,
           0.5f,
           1 << LayerMask.NameToLayer("Ground"));
        Debug.Log(ray.collider != null);
        return ray.collider != null;
    }

    bool IsMonster()
    {
        var ray = Physics2D.BoxCast(col.bounds.center, new Vector2(col.bounds.size.x, 1.2f),
           0f,
           Vector2.down,
           0.5f,
           1 << LayerMask.NameToLayer("Monster"));


        return ray.collider != null;
    }
}
