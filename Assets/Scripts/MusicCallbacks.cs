using UnityEngine;

public class MusicCallbacks : MonoBehaviour
{
    public AK.Wwise.Event musicEvent;

    public Light beatLight;

    public float pulseIntensity = 5f;
    public float fadeSpeed = 8f;

    private float beatLightTarget = 0f;
    private Color colorTarget = Color.white;


    private void Start()
    {
        musicEvent.Post(gameObject, 
                (uint)(AkCallbackType.AK_MusicSyncBeat | AkCallbackType.AK_MusicSyncUserCue),
                OnMusicCallback
            );
    }

    void OnMusicCallback(object in_cookie, AkCallbackType in_Type, AkCallbackInfo in_info)
    {
        if (in_Type == AkCallbackType.AK_MusicSyncBeat)
        {
            beatLightTarget = pulseIntensity;
        }

        if (in_Type == AkCallbackType.AK_MusicSyncUserCue)
        {
            AkMusicSyncCallbackInfo info = (AkMusicSyncCallbackInfo) in_info;

            colorTarget = Random.ColorHSV();
        }
    }

    private void Update()
    {
        beatLight.intensity = Mathf.Lerp(beatLight.intensity, beatLightTarget, fadeSpeed * Time.deltaTime);
        beatLightTarget = Mathf.Lerp(beatLightTarget, 0f, fadeSpeed * Time.deltaTime);
        beatLight.color = colorTarget;
    }
}
