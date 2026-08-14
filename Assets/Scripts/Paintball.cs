using UnityEngine;

public class Paintball : MonoBehaviour
{
    public float lifetime = 5f;
    public int damage = 10;

    private Vector3 previousPosition;


    void Start()
    {
        previousPosition = transform.position;
        Destroy(gameObject, lifetime);
    }

    void OnCollisionEnter(Collision collision)
    {
        Target target = collision.gameObject.GetComponent<Target>();
        if (target != null)
            target.DestroyTarget();
        Health health = collision.gameObject.GetComponent<Health>();
        if (health != null)
            health.TakeDamage(damage);

        Destroy(gameObject);
    }
}
