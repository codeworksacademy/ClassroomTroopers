using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public float AttackSpeed = 2;
    public Projectile Projectile;
    public Player Player;

    [Header("Gun Stats")]
    public float Spread = 0f;
    public float BurstCout = 1;
    public float CycleRate = 0;

    [Header("Projectile Mods")]
    public float PierceMod = 0;
    public float DamageMod = 0;
    public float ProjectileSpeedMod = 0;
    public float ScaleMod = 1;

    private float lastAttack = 0;


    void Start()
    {
        Debug.Log("Gun Start");
        Player = GetComponentInParent<Player>();
        Spread = Player.BaseCharacter.Spread;
        BurstCout = Player.BaseCharacter.BurstCout;
        CycleRate = Player.BaseCharacter.CycleRate;
        PierceMod = Player.BaseCharacter.PierceMod;
        DamageMod = Player.BaseCharacter.DamageMod;
        ProjectileSpeedMod = Player.BaseCharacter.ProjectileSpeedMod;
        ScaleMod = Player.BaseCharacter.ScaleMod;
        AttackSpeed = Player.BaseCharacter.AttackSpeed;
        Projectile = Player.BaseCharacter.ProjectilePrefab;
    }



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
            var projectile = Instantiate(Projectile, transform.position, Quaternion.Euler(new Vector3(0, 0, UnityEngine.Random.Range(-Spread, Spread))));
            projectile.SetTargetDirection(Player.transform.localScale.x);


            projectile.Damage += DamageMod;
            projectile.Speed += ProjectileSpeedMod;
            projectile.Pierce += PierceMod;
            projectile.transform.localScale *= ScaleMod;

            yield return new WaitForSeconds(CycleRate);
        }
    }

    public void ApplyUpgrade(WeaponMod item)
    {


        foreach (var key in item.Modifiers)
        {
            float percentage = item.value / 100f;
            switch (key)
            {
                case WeaponModifiers.AttackSpeed:
                    AttackSpeed *= 1 - percentage;
                    break;
                case WeaponModifiers.BurstCout:
                    BurstCout *= 1 + percentage;
                    break;
                case WeaponModifiers.CycleRate:
                    CycleRate *= 1 - percentage;
                    CycleRate = Mathf.Clamp(CycleRate, 0, 1);
                    break;
                case WeaponModifiers.Pierce:
                    PierceMod *= 1 + percentage;
                    break;
                case WeaponModifiers.ProjecileSpeed:
                    ProjectileSpeedMod *= 1 + percentage;
                    break;
                case WeaponModifiers.Damage:
                    DamageMod *= 1 + percentage;
                    break;
                case WeaponModifiers.Scale:
                    ScaleMod *= 1 + percentage;
                    Mathf.Clamp(ScaleMod, 0.1f, 3f);
                    break;
            }
        }
    }
}
