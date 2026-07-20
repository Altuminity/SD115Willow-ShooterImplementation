using UnityEngine;

public interface ICollectible
{
    float perkDuration { get; }
    float rotateSpeed { get; }
    float bobSpeed { get; }
    float bobHeight {  get; }

    void OnTriggerEnter(Collider other);
}
