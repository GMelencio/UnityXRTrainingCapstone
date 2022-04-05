using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManagerExample : MonoBehaviour
{
    public AudioSource ambientAudio;
    public AudioSource directionalAudio;

    public Slider ambientVolumeSlider;
    public Slider directionalVolumeSlider;
    public Slider ambientReverbSlider;
    public Slider ambientLowPassSlider;
    public Slider ambientHighPassSlider;
    public Slider ambientDistortionSlider;

    AudioReverbFilter ambientReverb;
    AudioLowPassFilter ambientLowPass;
    AudioHighPassFilter ambientHighPass;
    AudioDistortionFilter ambientDistortion;


    void Start()
    {

        // get references to the filters on the ambient audiosource
        ambientReverb = ambientAudio.GetComponent<AudioReverbFilter>();
        ambientLowPass = ambientAudio.GetComponent<AudioLowPassFilter>();
        ambientHighPass = ambientAudio.GetComponent<AudioHighPassFilter>();
        ambientDistortion = ambientAudio.GetComponent<AudioDistortionFilter>();

        // set up the sliders
        ambientVolumeSlider.onValueChanged.AddListener(delegate { AdjustAmbientVolume(); });
        directionalVolumeSlider.onValueChanged.AddListener(delegate { AdjustDirectionalVolume(); });
        ambientReverbSlider.onValueChanged.AddListener(delegate { AdjustReverb(); });
        ambientLowPassSlider.onValueChanged.AddListener(delegate { AdjustLowPass(); });
        ambientHighPassSlider.onValueChanged.AddListener(delegate { AdjustHighPass(); });
        ambientDistortionSlider.onValueChanged.AddListener(delegate { AdjustDistortion(); });



    }

    void AdjustAmbientVolume()
    {
        ambientAudio.volume = ambientVolumeSlider.value;
    }

    void AdjustDirectionalVolume()
    {
        directionalAudio.volume = directionalVolumeSlider.value;
    }

    void AdjustReverb()
    {
        ambientReverb.reverbLevel = ambientReverbSlider.value;
    }

    void AdjustLowPass()
    {
        ambientLowPass.cutoffFrequency = ambientLowPassSlider.value;
    }

    void AdjustHighPass()
    {
        ambientHighPass.cutoffFrequency = ambientHighPassSlider.value;
    }

    void AdjustDistortion()
    {
        ambientDistortion.distortionLevel = ambientDistortionSlider.value;
    }

}
