using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public float AttackSpeed = 2;
    public Projectile Projectile;
    public Transform Player;

    public float Spread = 0f;
    public int BurstCout = 1;
    public float CycleRate = 0;
    private float lastAttack = 0;


    void Update()
    {

        if (lastAttack <= 0)
        {
            StartCoroutine(Fire());
        }

        lastAttack -= Time.deltaTime;

    }


    IEnumerator Fire()
    {
        lastAttack = AttackSpeed;
        for (int i = 0; i < BurstCout; i++)
        {
            var projectile = Instantiate(Projectile, transform.position, Quaternion.Euler(new Vector3(0, 0, Random.Range(-Spread, Spread))));
            projectile.SetTargetDirection(Player.localScale.x);
            yield return new WaitForSeconds(CycleRate);
        }
    }


}
