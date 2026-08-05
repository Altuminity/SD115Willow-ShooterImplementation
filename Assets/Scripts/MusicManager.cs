using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [Header("Wwise Events")]
    public AK.Wwise.Event musicEvent;

    public CharacterController charCon;
    public AK.Wwise.RTPC playerSpeed;


    private void Start()
    {
        musicEvent.Post(gameObject);
    }

    private void Update()
    {
        playerSpeed.SetValue(gameObject, charCon.velocity.magnitude);
    }
}
