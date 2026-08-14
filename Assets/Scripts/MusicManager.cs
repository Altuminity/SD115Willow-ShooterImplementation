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

    [Header("Light Callback Vars")]
    public Light[] beatLights;
    public float pulseIntensity = 100f;
    public float fadeSpeed = 8f;
    private float beatLightTarget = 75f;
    private Color colorTarget = Color.white;

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

        foreach(Light beatLight in beatLights)
        {
            beatLight.intensity = Mathf.Lerp(beatLight.intensity, beatLightTarget, fadeSpeed * Time.deltaTime);
            beatLightTarget = Mathf.Lerp(beatLightTarget, 0f, fadeSpeed * Time.deltaTime);
            beatLight.color = colorTarget;
        }

        
    }

    void OnMusicCallback(object in_cookie, AkCallbackType in_Type, AkCallbackInfo in_info)
    {
        if (in_Type == AkCallbackType.AK_MusicSyncBeat)
        {
            foreach (Light beatLight in beatLights)
            {
                beatLight.intensity = pulseIntensity;
            }
        }

        if (in_Type == AkCallbackType.AK_MusicSyncBar)
        {
            colorTarget = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        }
    }
}
