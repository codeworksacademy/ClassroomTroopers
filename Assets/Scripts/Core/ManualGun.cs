public class ManualGun : Gun
{

    public override void Update()
    {
        // Leave this empty to prevent auto-firing
    }

    public void TriggerAttack()
    {
        StartCoroutine(Fire());
    }

}
