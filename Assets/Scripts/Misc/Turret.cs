using UnityEngine;

public class Turret : MonoBehaviour
{
    public ManualGun Gun;

    void OnTriggerEnter2D(Collider2D collision)
    {

        var player = collision.GetComponent<Player>();
        if (player == null)
        {
            return;
        }

        Gun.TriggerAttack();
    }


}
