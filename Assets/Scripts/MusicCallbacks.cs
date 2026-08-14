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
                (uint)(AkCallbackType.AK_MusicSyncBeat | AkCallbackType.AK_MusicSyncBar),
                OnMusicCallback


            );
    }

    

    private void Update()
    {
        beatLight.intensity = Mathf.Lerp(beatLight.intensity, beatLightTarget, fadeSpeed * Time.deltaTime);
        beatLightTarget = Mathf.Lerp(beatLightTarget, 0f, fadeSpeed * Time.deltaTime);
        beatLight.color = colorTarget;
    }

    void OnMusicCallback(object in_cookie, AkCallbackType in_type, AkCallbackInfo in_info)
    {
        if (in_type == AkCallbackType.AK_MusicSyncBeat)
        {
            beatLight.intensity = pulseIntensity;
        }

        if (in_type == AkCallbackType.AK_MusicSyncBar)
        {
            colorTarget = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        }
    }
}
