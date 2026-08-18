using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DrunkEffect : MonoBehaviour
{
    public Material _drunkEffectMaterial;
    public FullScreenPassRendererFeature drunkRenderer;

    private bool _drunkActive = false;
    private float _frequency = 5f;
    private float _shift = 0f;
    private float _amplitude = 0f;
    private float _maxAmplitude = 0.07f;
    private float _amplitudeSpeed = 0.025f;
    private float _shiftSpeed = 7.5f;

    [Header("Drunk Collectible Stuff")]
    private float perkTimer;
    public float perkDuration;

    [Header("Drunk Wwise Stuff")]
    public AK.Wwise.Event setDrunkState;

    private void Start()
    {
        SetFrequency(0f);
    }

    private void Update()
    {
        if(perkTimer > 0f)
        {
            StartDrunk();
            perkTimer -= Time.deltaTime;
            if(perkTimer <= 0f)
            {
                StopDrunk();
                perkTimer = 0f;
            }
        }
    }

    public void StartDrunkTimer()
    {
        perkTimer = perkDuration;
    }

    private void SetFrequency(float frequency)
    {
        _drunkEffectMaterial.SetFloat("_frequency", frequency);
    }

    private void SetShift(float shift)
    {
        _drunkEffectMaterial.SetFloat("_shift", shift);
    }

    private void SetAmplitude(float amplitude)
    {
        _drunkEffectMaterial.SetFloat("_amplitude", amplitude);
    }

    public void StartDrunk()
    {
        if(!_drunkActive)
        {
            _drunkActive = true;
            StartCoroutine(DrunkCoroutine());
        }
    }

    public void StopDrunk()
    {
        SetFrequency(0f);
        _drunkActive = false;
    }

    private IEnumerator DrunkCoroutine()
    {
        SetFrequency(_frequency);
        SetShift(_shift);

        while(_amplitude < _maxAmplitude)
        {
            if (_drunkActive)
            {
                SetAmplitude(_amplitude);

                _amplitude += _amplitudeSpeed * Time.deltaTime;
                _shift += _shiftSpeed * Time.deltaTime;
                _shift %= Mathf.PI * 2f;

                yield return null;
            }
        }

        if (_drunkActive)
        {
            _amplitude = _maxAmplitude;
            SetAmplitude(_amplitude);
        }

        while(_drunkActive)
        {
            SetShift(_shift);
            _shift += _shiftSpeed * Time.deltaTime;
            _shift %= Mathf.PI * 2f;

            yield return null;
        }

        while (_amplitude > 0f)
        {
            if (!_drunkActive)
            {
                SetAmplitude(_amplitude);
                SetShift(_shift);

                _amplitude -= _amplitudeSpeed * Time.deltaTime;
                _shift += _shiftSpeed * Time.deltaTime;
                _shift %= Mathf.PI * 2f;

                yield return null;
            }
        }

        if (!_drunkActive)
        {
            _amplitude = 0f;
            _shift = 0f;
            SetAmplitude(_amplitude);
            SetShift(_shift);
        }
    }
}
