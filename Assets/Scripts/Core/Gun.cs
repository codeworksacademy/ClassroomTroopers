using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public float AttackSpeed = 2;
    public Projectile Projectile;
    public Player Player;
    private float lastAttack = 0;

    public float BurstCount = 1;
    public float CycleTime = .2f;
    public float Spread = 0;

    public void ApplyBaseStats(BaseCharacter data)
    {
        AttackSpeed = data.AttackSpeed;
        BurstCount = data.BurstCount;
        CycleTime = data.CycleTime;
        Spread = data.Spread;
        Projectile = data.projectilePrefab;
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

        for (int i = 0; i < BurstCount; i++)
        {
            var rotation = new Vector3(0, 0, Random.Range(-Spread, Spread));
            var projectile = Instantiate(Projectile, transform.position, Quaternion.Euler(rotation));
            projectile.SetTargetDirection(Player.transform.localScale.x);
            yield return new WaitForSeconds(CycleTime);
        }

        yield return null;

    }

}
