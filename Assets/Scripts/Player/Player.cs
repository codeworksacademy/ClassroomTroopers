using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Health = 100;
    public float Mana = 100;

    private SpriteRenderer sprite;
    private bool isFlashing = false;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }


    //                               vvv the item I picked up
    public void CollectPickup(Pickup item)
    {

        if (item.type == PickupType.Mana)
        {
            Mana += item.value;
        }

        if (item.type == PickupType.Health)
        {
            Health += item.value;
        }

        if (item.type == PickupType.Ouchie)
        {
            Health -= item.value;
        }


        CheckDeath();

    }


    public IEnumerator Flash(float duration)
    {
        isFlashing = true;
        Color startingColor = sprite.color;

        while (duration > 0)
        {
            sprite.color = new Color(1, 0, 0, .5f);
            yield return new WaitForSeconds(.1f);
            sprite.color = startingColor;
            yield return new WaitForSeconds(.1f);
            duration -= .2f;
        }


        sprite.color = startingColor;
        isFlashing = false;
    }



    public void ApplyDamage(float amount)
    {
        Health -= amount;
        if (!isFlashing)
        {
            StartCoroutine(Flash(1));
        }
        CheckDeath();
    }



    private void CheckDeath()
    {
        if (Health <= 0)
        {

            Destroy(gameObject);
        }
    }



}