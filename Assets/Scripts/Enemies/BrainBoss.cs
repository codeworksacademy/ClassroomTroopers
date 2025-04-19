using System.Collections;
using UnityEngine;

public enum BrainBossState
{
    ReadyForChange = 0,
    Idle = 1,
    WanderAround = 2,
    Stomp = 3,
    ChargeForward = 4,
    ShootTail = 5,
    Hurt,
    Dead
}


public class BrainBoss : Character
{
    public ManualGun TailGun;
    public ManualGun StompGun;
    public float ChargeSpeed = 10f;

    private bool stage2 = false;


    private Rigidbody2D rb;

    public BrainBossState CurrentState = BrainBossState.Idle;
    private Player player;

    public override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
        player = FindFirstObjectByType<Player>();
        OnHealthChange += CheckDeath;
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentState == BrainBossState.ReadyForChange)
        {
            SetRandomState();
        }
    }


    void SetRandomState()
    {
        CurrentState = (BrainBossState)Random.Range(stage2 ? 2 : 1, 6);
        switch (CurrentState)
        {
            case BrainBossState.Idle:
                StartCoroutine(idle());
                break;
            case BrainBossState.WanderAround:
                StartCoroutine(WanderAround());
                break;
            case BrainBossState.Stomp:
                StartStompAttack();
                break;
            case BrainBossState.ChargeForward:
                StartChargeForward();
                break;
            case BrainBossState.ShootTail:
                FireTail();
                break;
            default:
                Debug.LogError("Invalid state: " + CurrentState);
                break;
        }
    }


    #region Enemy States

    IEnumerator idle()
    {
        animator.SetTrigger("StartIdle");
        rb.linearVelocity = Vector3.zero;
        yield return new WaitForSeconds(.85f);
        EndState();
    }

    void StartStompAttack()
    {
        animator.SetTrigger("StartStomp");
        rb.linearVelocity = Vector3.zero;
    }

    void StartChargeForward()
    {
        animator.SetTrigger("StartCharge");
        rb.linearVelocity = Vector3.zero;
    }

    IEnumerator WanderAround()
    {
        float wanderTime = 1.5f;
        animator.SetTrigger("StartWandering");
        float wanderX = Random.Range(-1, 1);
        float wanderY = Random.Range(-1, 1);
        float d = Mathf.Sign(wanderX);
        transform.localScale = new Vector2(d, 1);
        while (wanderTime > 0)
        {
            wanderTime -= Time.deltaTime;
            rb.linearVelocity = new Vector2(wanderX * MoveSpeed, wanderY * MoveSpeed);
            yield return null; // wait for the next frame
        }

        EndState();
    }

    void FireTail()
    {
        FacePlayer();
        animator.SetTrigger("FireTail");
        rb.linearVelocity = Vector3.zero;
    }



    #endregion

    // ANIMATION EVENTS

    public void StartCharging()
    {
        // block projectiles
        // start applying velopcity to the boss
        FacePlayer();
        StartCoroutine(ChargeTowardsPlayer());
    }


    IEnumerator ChargeTowardsPlayer()
    {
        float chargeTime = 2.5f;
        // get the direction to the player
        Vector2 direction = (player.transform.position - transform.position).normalized;
        FacePlayer();

        while (chargeTime > 0)
        {
            chargeTime -= Time.deltaTime;
            rb.linearVelocity = direction * ChargeSpeed;
            yield return null; // wait for the next frame
        }

        rb.linearVelocity = Vector2.zero; // stop moving after 1 second
        EndState();
    }



    public void EndStompAttack()
    {
        StompGun.TriggerAttack();
        EndState();
    }

    public void TriggerTailAttack()
    {
        Debug.Log("Tail attack triggered");
        TailGun.TriggerAttack();
        EndState();
    }



    void EndState()
    {
        CurrentState = BrainBossState.ReadyForChange;
        rb.linearVelocity = Vector3.zero;
    }

    void FacePlayer()
    {
        float d = Mathf.Sign(player.transform.position.x - transform.position.x);
        transform.localScale = new Vector2(d, 1);
    }


    public void CheckDeath()
    {

        if (Health < 50 && stage2 != true)
        {
            TailGun.BurstCount *= 2;
            StompGun.BurstCount *= 4;
            MoveSpeed = 8;
            ChargeSpeed *= 1.5f;
            stage2 = true;

            StartCoroutine(Flash(float.MaxValue));
        }

        if (Health <= 0)
        {
            animator.SetTrigger("isDead");
            rb.bodyType = RigidbodyType2D.Static;
        }
    }


}
