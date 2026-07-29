using UnityEngine;

public class TargetingSystem : MonoBehaviour
{
    private GameObject target;
    public GameObject headRot;
    public WeaponSystem weapon;

    private bool _isTargetLocked;

    public float rotationSpeed = 5f;

    public Vector3 rotationOffsetEuler = new Vector3(0f, 0f, -90f);

    [Header("Aim Detection")]
    public float aimThresholdAngle = 5f;
    private bool isAimedAtTarget = false;

    private float nextFireTime;

    private void Start()
    {
        if(weapon == null)
        weapon = GetComponent<WeaponSystem>();
    }


    private void Update()
    {
        if (_isTargetLocked)
        {
            Vector3 direction = target.transform.position - headRot.transform.position;
            if (direction.sqrMagnitude < 0.0001f) return;

            Quaternion lookRotation = Quaternion.LookRotation(direction);
            Quaternion offset = Quaternion.Euler(rotationOffsetEuler);

            Quaternion correctedRotation = lookRotation * offset;    //correcting for strange maya import (all my directions are correct in maya and set for unity so unsure what the issue is)

            headRot.transform.rotation = Quaternion.Lerp(headRot.transform.rotation, correctedRotation, rotationSpeed * Time.deltaTime);

            float angle = Vector3.Angle(headRot.transform.forward, direction);
            bool nowAimed = angle <= aimThresholdAngle;


            if (nowAimed)
            {
                isAimedAtTarget = true;
                if (Time.time >= nextFireTime)
                {
                    nextFireTime = Time.time + weapon.currentFireRate;
                    weapon.Fire();
                }
            }
            else if (!nowAimed && isAimedAtTarget)
                isAimedAtTarget = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            target = other.gameObject;
            _isTargetLocked = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            target = null;
            _isTargetLocked = false;
        }
    }
}
