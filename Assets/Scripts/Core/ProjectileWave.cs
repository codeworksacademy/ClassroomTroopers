using System;
using UnityEngine;

public class ProjectileWave : Projectile
{
    [Range(0, .2f)]
    public float WaveStrength = 0;
    [Range(.1f, 2)]
    public float WaveSpeed = .1f;
    public bool UseReverse = false;
    private float current = 0;
    private bool useWave = true;
    private bool reversed = false;


    public override void Start()
    {
        base.Start();
    }


    public override void Update()
    {
        base.Update();

        if (useWave)
        {
            current = Mathf.PingPong(Time.time * WaveSpeed, WaveStrength * 2) - WaveStrength;
            Debug.Log("👋 " + current);
            transform.position += new Vector3(0, current, 0);
        }

        if (!UseReverse || reversed) { return; }
        if (maxLifetime / 2 > lifetime)
        {
            useWave = false;
            Speed *= 1.25f;
            reversed = true;
            Debug.Log("Flipping");
            SetTargetDirection(direction * -1);
        }
    }
}
