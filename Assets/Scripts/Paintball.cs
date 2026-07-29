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

    private void FixedUpdate() //ontrigger enter wasnt working for detecting the player so ive opted to use a raycast that detects when the paintball has crossed paths with the player
    {
        Vector3 currentPosition = transform.position;
        Vector3 direction = currentPosition - previousPosition;
        float distance = direction.magnitude;

        if (distance > 0f)
        {
            RaycastHit hit;
            if(Physics.Raycast(previousPosition, direction.normalized, out hit, distance))
            {
                if(hit.collider.CompareTag("Player"))
                {
                    Debug.Log("hit the player!");
                    Health health = hit.collider.GetComponent<Health>();
                    if(health != null)
                        health.TakeDamage(damage);
                    
                    Destroy(gameObject);
                }
            }
        }
    }
}
