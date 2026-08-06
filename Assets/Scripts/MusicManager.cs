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
        musicEvent.Post(gameObject,
            (uint)(AkCallbackType.AK_MusicSyncBeat | AkCallbackType.AK_MusicSyncBar),
                OnMusicCallback
            );
    }

    private void Update()
    {
        playerSpeed.SetValue(gameObject, charCon.velocity.magnitude);
    }

    void OnMusicCallback(object in_cookie, AkCallbackType in_Type, AkCallbackInfo in_info)
    {
        if (in_Type == AkCallbackType.AK_MusicSyncBeat)
        {
        }

        if (in_Type == AkCallbackType.AK_MusicSyncBar)
        {
        }
    }
}
