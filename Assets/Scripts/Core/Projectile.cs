using System;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float Speed = 10;
    public float Pierce = 2;
    public float Damage = 1;
    public float lifetime = 2;
    private float direction = 1;

    public List<string> HurtsObjectsWithTag;
    private Dictionary<GameObject, bool> alreadyHit = new Dictionary<GameObject, bool>();


    // Update is called once per frame
    void Update()
    {

        transform.position += transform.right * direction * Time.deltaTime * Speed;


        lifetime -= Time.deltaTime;

        if (lifetime <= 0)
        {
            Destroy(gameObject);
        }
    }


    void OnTriggerEnter2D(Collider2D collision)
    {

        Character character = collision.GetComponent<Character>();
        if (character == null) { return; }

        if (alreadyHit.ContainsKey(character.gameObject)) { return; }

        var hits = HurtsObjectsWithTag.Find(tag => character.tag == tag);
        if (hits == null) { return; }
        Pierce--;
        character.ApplyDamage(Damage);

        alreadyHit.Add(character.gameObject, true);

        if (Pierce <= 0)
        {
            Destroy(gameObject);
        }
    }


    public void SetTargetDirection(float targetDirection)
    {
        transform.localScale = new Vector3(targetDirection, 1, 1);

        direction = targetDirection;
    }

}
