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
}
