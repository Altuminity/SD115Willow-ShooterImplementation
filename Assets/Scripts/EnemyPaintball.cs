using UnityEngine;

public class EnemyPaintball : Paintball
{
    private Vector3 previousPositionn;

    void Start()
    {
        previousPositionn = transform.position;
        Destroy(gameObject, lifetime);
    }

    private void FixedUpdate() //ontrigger enter wasnt working for detecting the player so ive opted to use a raycast that detects when the paintball has crossed paths with the player
    {
        Vector3 currentPosition = transform.position;
        Vector3 direction = currentPosition - previousPositionn;
        float distance = direction.magnitude;

        if (distance > 0f)
        {
            RaycastHit hit;
            if (Physics.Raycast(previousPositionn, direction.normalized, out hit, distance))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    Debug.Log("hit the player!");
                    Health health = hit.collider.GetComponent<Health>();
                    if (health != null)
                        health.TakeDamage(damage);


                    Destroy(gameObject);
                }
            }
        }
    }
}
