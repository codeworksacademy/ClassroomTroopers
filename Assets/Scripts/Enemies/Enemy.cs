using UnityEngine;

public class Enemy : MonoBehaviour
{

    // private SpriteRenderer sprite;
    private Animator animator;
    public GameObject target;

    private bool isAttacking = false;
    private bool isSleeping = false;

    public float MoveSpeed = 2;
    public float AttackDamage = 5;


    void Start()
    {
        animator = GetComponent<Animator>();
        // sprite = GetComponent<SpriteRenderer>();
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


}
