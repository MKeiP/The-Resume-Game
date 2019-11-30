using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public int health;
    public Enemy[] enemies;
    public float spawnOffset;

    private int halfHealth;
    private Animator anim;

    public int damage;

    public GameObject blood;
    public GameObject effect;
    private Slider healthBar;

    private GameObject[] enes;
    public GameObject resume;

    private void Start()
    {
        halfHealth = health / 2;
        anim = GetComponent<Animator>();
        healthBar = FindObjectOfType<Slider>();
        healthBar.maxValue = health;
        healthBar.value = health;
    }
    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        healthBar.value = health;
        if (health <= 0)
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            //Instantiate(blood, transform.position, Quaternion.identity);
            Instantiate(resume, transform.position, transform.rotation);
            Destroy(this.gameObject);

            enes = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enes)
                GameObject.Destroy(enemy);

            healthBar.gameObject.SetActive(false);
        }
        if(health <= halfHealth)
        {
            anim.SetTrigger("stage2");
        }

        Enemy randomEnemy = enemies[Random.Range(0, enemies.Length)];
        Instantiate(randomEnemy, transform.position + new Vector3(spawnOffset,spawnOffset,0), transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<Player>().TakeDamage(damage);
        }
    }
}
