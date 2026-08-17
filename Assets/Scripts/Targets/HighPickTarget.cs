using UnityEngine;

public class HighPickTarget : Target
{
    private void Awake()
    {
        scoreValue = 100;
        lifetime = 15f;
    }
    public override void Start()
    {
        base.Start();
    }
    public override void DestroyTarget()
    {
        base.DestroyTarget();
    }
}
