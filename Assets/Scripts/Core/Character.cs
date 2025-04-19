using System;
using System.Collections;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float Health = 100;
    public float Shield = 0;
    public float MoveSpeed = 2;
    public Action OnHealthChange;

    private SpriteRenderer sprite;
    protected Animator animator;
    private bool isFlashing = false;

    public virtual void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
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
        OnHealthChange?.Invoke();

        if (!isFlashing && Health > 0)
        {
            StartCoroutine(Flash(1));
        }
    }

}