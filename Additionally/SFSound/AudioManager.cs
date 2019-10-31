using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine;
using System.IO;

public class AudioManager : MonoBehaviour
{
    public AudioForBackground audioForBackground;
    public AudioMixerGroup MasterMixer;

    [HideInInspector] public float ValueMixer;

    string DeterminesWhichAudioSourceToPlay = "battle";

    private static AudioManager SingletonAM = null;

    public static AudioManager Instance
    {
        get { return SingletonAM; }
    }

    private void Awake()
    {
        if (SingletonAM == null)
        {
            SingletonAM = this;
            DontDestroyOnLoad(this.gameObject);
            if (File.Exists(Application.dataPath + "/data/AVM.sav"))
            {
                float[] loadValue = SaveMixerValue.LoadValue();
                ValueMixer = loadValue[0];
            }
            else ValueMixer = -50;
        }
        else Destroy(this.gameObject);
    }   

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Menu" && DeterminesWhichAudioSourceToPlay == "battle") MasterMixer.audioMixer.SetFloat("Master", (ValueMixer));
        if (SceneManager.GetActiveScene().name == "Menu" && DeterminesWhichAudioSourceToPlay == "battle" ||
             SceneManager.GetActiveScene().name == "Menu" && DeterminesWhichAudioSourceToPlay == "travel") PauseAudioTravelAndPlayAudioMenu();
        if (SceneManager.GetActiveScene().name == "Level" && DeterminesWhichAudioSourceToPlay == "battle" ||
             SceneManager.GetActiveScene().name == "Level" && DeterminesWhichAudioSourceToPlay == "menu") PauseAudioMenuAndPlayAudioTravel();
        if (SceneManager.GetActiveScene().name == "Ambush" && DeterminesWhichAudioSourceToPlay == "travel" ||
             SceneManager.GetActiveScene().name == "Ambush" && DeterminesWhichAudioSourceToPlay == "menu") PauseAudioTravelAndPlayAudioBAttle();
    }

    void PauseAudioTravelAndPlayAudioMenu()
    {
        audioForBackground.SwitchFromAudioTravelToAudioMenu();
        DeterminesWhichAudioSourceToPlay = "menu";
    }

    void PauseAudioMenuAndPlayAudioTravel()
    {
        DeterminesWhichAudioSourceToPlay = "travel";
        audioForBackground.SwitchFromAudioMenuToAudioTravel();
    }

    void PauseAudioTravelAndPlayAudioBAttle()
    {
        DeterminesWhichAudioSourceToPlay = "battle";
        audioForBackground.SwitchFromAudioOtherToAudioBattle();
    }

    public void SaveValueMixer()
    {
        SaveMixerValue.SaveValue(this);
    }

    public void ChangesTheSoundVolume(float Value)
    {
        MasterMixer.audioMixer.SetFloat("Master", (Value));
        ValueMixer = Value;
    }
}