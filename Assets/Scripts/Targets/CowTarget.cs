using UnityEngine;

public class CowTarget : Target
{
    private void Awake()
    {
        scoreValue = -50;
        lifetime = 12f;
    }

    public override void Start()
    {
        base.Start();
    }
    public override void DestroyTarget()
    {
        AddScore(scoreValue);
        Instantiate(targetDestroySound, transform.parent.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
