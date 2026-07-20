using System.Xml.Serialization;
using UnityEngine;

public class PowerUpCollectible : MonoBehaviour, ICollectible
{
    public enum PowerUpType
    {
        HealthUp,
        FireRateUp,
        SpeedUp
    }

    public PowerUpType powerType;
    public float perkDuration => 10f;

    public float rotateSpeed => 90f;

    public float bobSpeed => 2f;

    public float bobHeight => 0.25f;

    Vector3 startPos;

    public int healingAmount = 100;
    public float fireRateUpAmount = 0.01f;

    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
        Vector3 pos = startPos;
        pos.y += Mathf.Sin(Time.time * bobSpeed) * bobHeight;
        transform.position = pos;
    }

    public void OnTriggerEnter(Collider other)
    {
        switch (powerType)
        {
            case PowerUpType.HealthUp:
                {
                    Health health = other.GetComponent<Health>();

                    if (health != null)
                    {
                        health.Heal(healingAmount);
                        break;
                    }
                    break;
                }
            case PowerUpType.FireRateUp:
                {
                    WeaponSystem fireRate = other.GetComponent<WeaponSystem>();
                    if (fireRate == null) fireRate = other.GetComponentInParent<WeaponSystem>();

                    if (fireRate != null)
                    {
                        fireRate.SetFireRate(fireRateUpAmount, perkDuration);
                        break;
                    }
                    break;
                }
            case PowerUpType.SpeedUp:
                {
                    break;
                }
        }

        Destroy(gameObject);
    }

    public void SpeedUp(float speedMult, float duration)
    {
        //do stuff here
    }


}
