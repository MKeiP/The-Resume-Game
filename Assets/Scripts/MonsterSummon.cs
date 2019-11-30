using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSummon : Enemy
{
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    private Vector2 targetPosition;
    private Animator anim;

    public float timeBetweenSummons;
    private float summonTime;

    public Enemy enemyToSummon;

    public float attackSpeed;
    public float stopDistance;
    private float attackTime;
    private Vector2 charPoss;

    public GameObject[] enmies;

    public override void Start()
    {
        base.Start();
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        targetPosition = new Vector2(randomX, randomY);
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(player != null)
        {
            if(Vector2.Distance(transform.position, targetPosition) > .5f)
            {
                
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                anim.SetBool("isRunning", true);
            }
            else
            {
                anim.SetBool("isRunning", false);

                if(Time.time >= summonTime-1.5)
                {
                    summonTime = Time.time + timeBetweenSummons;
                    anim.SetTrigger("summon");
                }
            }

            if (Vector2.Distance(transform.position, player.position) < stopDistance)
            {
                if (Time.time >= attackTime)
                {
                    StartCoroutine(Attack());
                    attackTime = Time.time + timeBetweenAttack;
                }
            }
        }
    }

    public void Summon()
    {
        enmies = GameObject.FindGameObjectsWithTag("Enemy");
        charPoss = transform.position;
        charPoss.x += 1;
        charPoss.y -= 1;
        if (player != null && enmies.Length <= 10)
        {
            Instantiate(enemyToSummon, charPoss, transform.rotation);
        }
    }

    IEnumerator Attack()
    {
        player.GetComponent<Player>().TakeDamage(damage);

        Vector2 originalPositon = transform.position;
        Vector2 targetPosition = player.position;        

        float percent = 0;
        while (percent <= 1)
        {
            percent += Time.deltaTime * attackSpeed;
            float formula = (-Mathf.Pow(percent, 2) + percent) * 4;
            transform.position = Vector2.Lerp(originalPositon, targetPosition, formula);
            yield return null;
        }
    }
}
