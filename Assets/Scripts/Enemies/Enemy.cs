using UnityEngine;

public class Enemy : Character
{


    public GameObject target;

    public bool isAttacking = false;
    public bool isSleeping = false;
    public float AttackDamage = 5;

    public override void Start()
    {
        base.Start();
        OnHealthChange += CheckDeath;
    }


    // Update is called once per frame
    void Update()
    {
        if (isAttacking || isSleeping) { return; }
        if (target == null) { return; }

        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, MoveSpeed * Time.deltaTime);


        if (transform.position.x < target.transform.position.x)
        {
            transform.localScale = new Vector2(-1, 1);
        }
        else
        {
            transform.localScale = new Vector2(1, 1);
        }


        animator.SetBool("isRunning", true);


    }



    void OnTriggerStay2D(Collider2D collision)
    {
        if (isAttacking) { return; }
        Player player = collision.GetComponent<Player>();

        if (player == null)
        {
            return; // the enemy touched something other than the player
        }

        animator.SetBool("isRunning", false);
        animator.SetTrigger("attack");
        isAttacking = true;

        player.ApplyDamage(AttackDamage);
    }

    public void EndAttack()
    {
        isAttacking = false;
    }

    public void GoToSleep()
    {
        if (target && target.CompareTag("Player")) { return; }

        animator.SetBool("isSleeping", true);
        isSleeping = true;
    }

    public virtual void CheckDeath()
    {
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }


}
