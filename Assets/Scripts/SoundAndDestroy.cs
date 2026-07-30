using UnityEngine;

public class SoundAndDestroy : MonoBehaviour
{
    [SerializeField] private AK.Wwise.Event genericSoundEvent;
    private float timer = 5f;

    private void Start()
    {
        genericSoundEvent.Post(gameObject);
        Destroy(gameObject, timer);
    }
}
