using UnityEngine;

public class BigBadBrain : Character
{
    private Rigidbody2D rb;
    public ManualGun TailGun;
    public ManualGun StompGun;

    public BrainBossState CurrentState = BrainBossState.ReadyForChange;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();

        // OnHealthChange += CheckDeath;

    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentState == BrainBossState.ReadyForChange)
        {
            ChangeState();
        }

    }

    public void ChangeState()
    {
        CurrentState = (BrainBossState)Random.Range(1, 6);

        if (CurrentState == BrainBossState.Idle)
        {
            animator.SetTrigger("StartIdle");
        }

        if (CurrentState == BrainBossState.ShootTail)
        {
            StartTailFire();
        }
        if (CurrentState == BrainBossState.Stomp)
        {
            animator.SetTrigger("StartStomp");
        }

    }


    void StartTailFire()
    {
        animator.SetTrigger("FireTail");
    }

    public void TriggerTailAttack()
    {
        TailGun.TriggerAttack();
        CurrentState = BrainBossState.ReadyForChange;
    }
    public void EndStompAttack()
    {
        StompGun.TriggerAttack();
        CurrentState = BrainBossState.ReadyForChange;
    }

    // public void CheckDeath()
    // {

    //     if (Health < 50)
    //     {
    //         TailGun.BurstCount *= 2;
    //         StompGun.BurstCount *= 4;
    //         MoveSpeed = 8;

    //         StartCoroutine(Flash(float.MaxValue));
    //     }

    //     if (Health <= 0)
    //     {
    //         animator.SetTrigger("isDead");
    //         rb.bodyType = RigidbodyType2D.Static;
    //     }
    // }

}
