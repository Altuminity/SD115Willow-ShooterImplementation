using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [Header("Wwise Objects")]
    public AK.Wwise.Event musicEvent;
    public AK.Wwise.RTPC playerSpeed;
    public AK.Wwise.Event setMenuState;
    public AK.Wwise.Event setGameState;

    [Header("Other Variables")]
    public GameObject menuUI;
    public CharacterController charCon;

    private void Start()
    {
        setGameState.Post(gameObject);
        musicEvent.Post(gameObject);
    }

    private void Update()
    {
        playerSpeed.SetValue(gameObject, charCon.velocity.magnitude);
    }
}
