using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rig;
    private Animator anim;
    private AudioSource audio;
    private AudioSource jumpAudio;
    private AudioSource clapAudio;

    public Joystick joystick;

    private float speed = 5f;
    private bool facingRight = true;

    private float jumpForce = 8f;
    private bool isGrounded = false;

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>(); // Звук бега
        jumpAudio = transform.Find("JumpSound").GetComponent<AudioSource>(); // Звук прыжка
        clapAudio = transform.Find("JumpClap").GetComponent<AudioSource>(); // Звук удара
    }

    private void Update()
    {
        Movement();
        Jump();
    }

    private void Movement()
    {
        //float horizontal = Input.GetAxis("Horizontal");
        float horizontal = joystick.Horizontal;
        rig.velocity = new Vector2(horizontal * speed, rig.velocity.y); 
        // Воспроизводить звук бега, только если движение происходит и игрок стоит на земле
        if (horizontal != 0 && isGrounded)
        {
            if (!audio.isPlaying)
            {
                audio.Play();
            }
        }
        else if (audio.isPlaying)
        {
            audio.Pause();
        }

        if ((horizontal > 0 && !facingRight) || (horizontal < 0 && facingRight))
        {
            Flip();
        }

        anim.SetFloat("HorizontalMove", Mathf.Abs(horizontal)); // Mathf делает положительные числа

        if (Input.GetKeyDown(KeyCode.X))
        {
            anim.SetBool("attack", true);
            if (!clapAudio.isPlaying)
            {
                clapAudio.Play();
            }
        }
        else
        {
            anim.SetBool("attack", false);
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = gameObject.transform.localScale;
        scale.x *= -1; //переварачиваем обьект
        transform.localScale = scale; // и получаем его тут
    }

    public void OnJumpButtonUp()
    {
        if (isGrounded == true)
        {
            rig.velocity = Vector2.up * jumpForce;
            if (!jumpAudio.isPlaying)
            {
                jumpAudio.Play();
            }
        }
        if (isGrounded == false)
        {
            anim.SetBool("Jumping", true);
        }
        else
        {
            anim.SetBool("Jumping", false);

        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rig.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            if (!jumpAudio.isPlaying)
            {
                jumpAudio.Play();
            }

        }

        if (isGrounded == false)
        {
            anim.SetBool("Jumping", true);
        }
        else
        {
            anim.SetBool("Jumping", false);

        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
