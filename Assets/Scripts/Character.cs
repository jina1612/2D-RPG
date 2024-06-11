using UnityEngine;

public class Character : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rigidbody2d;
    private AudioSource audioSource;

    public AudioClip JumpClip;

    public float Speed = 4f;
    public float JumpPower = 6f;
    public AudioClip AttackClip;

    private bool justAttack, justJump;
    private bool faceRight = true;

    private bool isFloor;
    private bool isLadder;
    private bool isClimbing;
    private float inputVertical;

    public GameObject AttackObj;
    public float AttackSpeed = 3f;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        AttackCheck();
        JumpCheck();
        Move();
        ClimbingCheak();
    }

    private void AttackCheck()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            justAttack = true;
        }
    }

    private void FixedUpdate()
    {
        Jump();
        Attack();
        Climbing();
    }

    private void ClimbingCheak()
    {
        inputVertical = Input.GetAxis("Vertical");
        if (isLadder && Mathf.Abs(inputVertical) > 0)
        {
            isClimbing = true;
        }
    }

    private void Climbing()
    {
        if (isClimbing)
        {
            rigidbody2d.gravityScale = 0f;
            rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, inputVertical * Speed);
        }
        else
        {
            rigidbody2d.gravityScale = 1f;
        }

    }
    private void Move()
    {
        //�̵�
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * Speed * Time.deltaTime);
            animator.SetBool("Move", true);
            if (!faceRight) Flip();
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * Speed * Time.deltaTime);
            animator.SetBool("Move", true);
            if (faceRight) Flip();
        }
        else
        {
            animator.SetBool("Move", false);
        }

    }
    private void Flip()
    {
        faceRight = !faceRight;

        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isFloor = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isFloor = false;
        }
    }

    private void JumpCheck()
    {
        if (isFloor)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                justJump = true;
            }
        }
    }
    private void Jump()
    {
        if (justJump)
        {
            justJump = false;

            rigidbody2d.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
            animator.SetTrigger("Jump");
            audioSource.PlayOneShot(JumpClip);
        }
    }

    private void Attack()
    {
        if (justAttack)
        {
            justAttack = false;

            animator.SetTrigger("Attack");
            audioSource.PlayOneShot(AttackClip);

            if (gameObject.name == "Warrior(Clone)")
            {
                AttackObj.GetComponent<Collider2D>().enabled = true;
                Invoke("SetAttackObjInactive", 0.5f);
            }
            else
            {
                if (!faceRight)
                {
                    GameObject obj = Instantiate(AttackObj, transform.position, Quaternion.Euler(0f, 180f, 0f));
                    obj.GetComponent<Rigidbody2D>().AddForce(Vector2.left * AttackSpeed, ForceMode2D.Impulse);
                    Destroy(obj, 3f);
                }
                else
                {
                    GameObject obj = Instantiate(AttackObj, transform.position, Quaternion.Euler(0, 0, 0));
                    obj.GetComponent<Rigidbody2D>().AddForce(Vector2.right * AttackSpeed, ForceMode2D.Impulse);
                    Destroy(obj, 3f);
                }
            }
        }
    }
    private void SetAttackObjInactive()
    {
        AttackObj.GetComponent<Collider2D>().enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ladder")
        {
            isLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ladder")
        {
            isLadder = false;
            isClimbing = false;
        }
    }
}


