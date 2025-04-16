using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform Player;



    void Update()
    {
        if (Player == null) { return; }
        transform.position = new Vector3(Player.position.x, Player.position.y, -10);
    }
}
