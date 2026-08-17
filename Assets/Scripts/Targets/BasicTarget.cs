using System.Diagnostics.Contracts;
using UnityEngine;

public class BasicTarget : Target
{
    private void Awake()
    {
        scoreValue = 25;
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
