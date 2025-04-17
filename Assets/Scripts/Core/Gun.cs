using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public float AttackSpeed = 2;
    public Projectile Projectile;
    public Player Player;
    private float lastAttack = 0;


    void Update()
    {
        if (lastAttack <= 0)
        {
            Fire();
        }

        lastAttack -= Time.deltaTime;
    }


    void Fire()
    {
        lastAttack = AttackSpeed;

        var projectile = Instantiate(Projectile, transform.position, Quaternion.identity);
        projectile.SetTargetDirection(Player.transform.localScale.x);
    }

}
