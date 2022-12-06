using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioMusic : MonoBehaviour
{
    [SerializeField] private AudioMixer Mixer;
    //[SerializeField] private AudioMixerGroup AudioMixerGroup;
    //private TextMeshProUGUI ValueText;


    private void Start()
    {
        Mixer.SetFloat("Music", Mathf.Log10(PlayerPrefs.GetFloat("Music", 1) * 20));

        //if(AudioMixerGroup != null)
        //{
        //    AudioMixerGroup.SetFloat("Volume", Mathf.Log10(PlayerPrefs.GetFloat("Volume", 1) * 20));
        //}
    }

    public void OnChangeSlider(float Value)
    {
        //ValueText.SetText($"{Value.ToString("N4")}");
        Mixer.SetFloat("Music", Mathf.Log10(Value) * 20);

        PlayerPrefs.SetFloat("Music", Value);
        PlayerPrefs.Save();
    }
}
