using UnityEngine;

public class DoSound : MonoBehaviour
{
    public AK.Wwise.Event genericSoundEvent;

    [Tooltip("This variable is for positionable sounds where their attached objects are destroyed upon being shot, or dont have a positioned object in the first place")]
    public bool isDestroyObject = false;

    private void Start()
    {
        if (isDestroyObject)
            genericSoundEvent.Post(gameObject);
    }
    public void PlayOneShot()
    {
        genericSoundEvent.Post(gameObject);
    }
}
