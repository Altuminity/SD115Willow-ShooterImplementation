using System.Diagnostics.Contracts;
using UnityEngine;

public class BasicTarget : Target
{
    private void Awake()
    {
        scoreValue = 25;
    }
    public override void DestroyTarget()
    {
        AddScore(scoreValue);
        Destroy(gameObject);
    }
}
