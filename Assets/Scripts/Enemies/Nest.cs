using UnityEngine;

public class Nest : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();

        if (enemy == null) { return; }

        enemy.GoToSleep();

    }

}
