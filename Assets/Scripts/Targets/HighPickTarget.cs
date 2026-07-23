using UnityEngine;

public class HighPickTarget : Target
{
    private void Awake()
    {
        scoreValue = 100;
        lifetime = 15f;
    }
    public override void DestroyTarget()
    {
        AddScore(scoreValue);
        Destroy(gameObject);
    }
}
