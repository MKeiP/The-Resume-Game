using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;
    private Animator anim;

    public float health;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public Animator hurtAnim;

    //public Joystick joystick;
    private Vector2 moveAmount;

    public GameObject showResume;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        //Vector2 moveInput2 = new Vector2(joystick.Horizontal, joystick.Vertical);

        /* if(moveInput != Vector2.zero)
             moveAmount = moveInput.normalized * speed;
         else
             moveAmount = moveInput2.normalized * speed;*/
        moveAmount = moveInput.normalized * speed;
        if (moveInput != Vector2.zero/* || moveInput2 != Vector2.zero*/)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveAmount * Time.fixedDeltaTime);
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        UpdateHealthUI(health);
        hurtAnim.SetTrigger("hurt");
        if(health <= 0)
        {
            health += 1;
            Debug.Log("Please Try Again");
        }
        /*if (health <= 0)
        {
            Destroy(this.gameObject);
        }*/
    }

    void UpdateHealthUI(float currentHealth)
    {
        for(int i=0; i< hearts.Length; i++)
        {
            if(i < currentHealth)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
        }
    }
    public void Heal(int healAmount)
    {
        if(health + healAmount > 5)
        {
            health = 5;
        }
        else
        {
            health += healAmount;
        }
        UpdateHealthUI(health);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Resume")
        {
            showResume.gameObject.SetActive(true);
            //playerScript.Heal(healAmount);             
        }
    }

}
