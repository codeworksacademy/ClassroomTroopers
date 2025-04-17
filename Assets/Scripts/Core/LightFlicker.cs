using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightFlicker : MonoBehaviour
{
    public float FlickerStrength = .1f;

    private float StartingStrength = 0;

    private Light2D light;


    void Start()
    {
        light = GetComponent<Light2D>();
        StartingStrength = light.intensity;
    }





    // Update is called once per frame
    void Update()
    {

        light.intensity = Random.Range(StartingStrength - FlickerStrength, StartingStrength);

    }
}
