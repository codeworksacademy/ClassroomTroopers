using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightFlicker : MonoBehaviour
{
    public float FlickerStrength = .1f;

    private float StartingStrength = 0;

    private Light2D _light;


    void Start()
    {
        _light = GetComponent<Light2D>();
        StartingStrength = _light.intensity;
    }





    // Update is called once per frame
    void Update()
    {

        _light.intensity = Random.Range(StartingStrength - FlickerStrength, StartingStrength);

    }
}
