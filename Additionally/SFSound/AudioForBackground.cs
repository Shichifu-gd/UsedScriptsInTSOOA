using UnityEngine;

public class AudioForBackground : MonoBehaviour
{
    public AudioClip[] AudioBackgroundAudioMenu;
    public AudioSource audioSourceAudioMenu;
    public AudioClip[] AudioBackgroundAudioTravel;
    public AudioSource audioSourceAudioTravel;
    public AudioClip[] AudioBackgroundAudioBattle;
    public AudioSource audioSourceAudioBattle;

    private static System.Random RandomAudioForBackground = new System.Random();
       
    bool SwitchesToASmallerNumberForMinusAudioTravel;
    bool SwitchesToASmallerNumberForPlusAudioTravel;
    bool SwitchForIncreasesAudioMenuVolume;
    bool SwitchForDecreaseAudioTravelVolume = true;
    bool PauseCheckAudioMenu = true;
    bool SwitchesToASmallerNumberForMinusAudioMenu;
    bool SwitchesToASmallerNumberForPlusAudioMenu;
    bool SwitchForIncreasesAudioTravelVolume;
    bool SwitchForDecreaseAudioMenuVolume = true;
    bool PauseCheckAudioTravel = true;
    bool SwitchesToASmallerNumberForMinusAudioBattle;
    bool SwitchesToASmallerNumberForPlusAudioBattle;
    bool SwitchForIncreasesAudioBattleVolume;
    bool SwitchForDecreaseAudioBattleVolume = true;

    int index = 0;

    float NumberForAudioMenu = 0.6f;
    float NumberForAudioTravel = 0.6f;
    float NumberForAudioBattle = 0.6f;

    private void Start()
    {
        ConnectAudioForMenu();
        ConnectAudioForTrevel();
        ConnectAudioForBattle();
        UsedOnlyAtStart();
    }

    private void FixedUpdate()
    {
        if (audioSourceAudioMenu.isPlaying == false && PauseCheckAudioMenu == false) ConnectAudioForMenu();
        if (audioSourceAudioTravel.isPlaying == false && PauseCheckAudioTravel == false) ConnectAudioForTrevel();
        if (SwitchForDecreaseAudioTravelVolume == false) DecreaseAudioTravelVolume();
        if (SwitchForIncreasesAudioTravelVolume == true) IncreasesAudioTravelVolume();
        if (SwitchForDecreaseAudioMenuVolume == false) DecreaseAudioMenuVolume();
        if (SwitchForIncreasesAudioMenuVolume == true) IncreasesAudioMenuVolume();
        if (SwitchForDecreaseAudioBattleVolume == false) DecreaseAudioBattleVolume();
        if (SwitchForIncreasesAudioBattleVolume == true) IncreasesAudioBattleVolume();
    }

    void ConnectAudioForMenu()
    {
        index = RandomAudioForBackground.Next(0, AudioBackgroundAudioMenu.Length);
        audioSourceAudioMenu.clip = AudioBackgroundAudioMenu[index];
    }

    void ConnectAudioForTrevel()
    {
        index = RandomAudioForBackground.Next(0, AudioBackgroundAudioTravel.Length);
        audioSourceAudioTravel.clip = AudioBackgroundAudioTravel[index];
    }

    void ConnectAudioForBattle()
    {
        index = RandomAudioForBackground.Next(0, AudioBackgroundAudioBattle.Length);
        audioSourceAudioBattle.clip = AudioBackgroundAudioBattle[index];
    }

    void UsedOnlyAtStart()
    {       
        audioSourceAudioMenu.Play();
        audioSourceAudioMenu.Pause();
        audioSourceAudioTravel.Play();
        audioSourceAudioTravel.Pause();
        audioSourceAudioBattle.Play();
        audioSourceAudioBattle.Pause();
    }

    public void SwitchFromAudioTravelToAudioMenu()
    {
        NumberForAudioMenu = 0.6f;
        audioSourceAudioTravel.volume = 1f;
        SwitchesToASmallerNumberForPlusAudioTravel = false;
        SwitchesToASmallerNumberForMinusAudioTravel = false;
        if (audioSourceAudioMenu.volume > 0.3f) audioSourceAudioMenu.volume = 0;
        SwitchForDecreaseAudioTravelVolume = false;
    }

    void DecreaseAudioTravelVolume()
    {
        audioSourceAudioTravel.volume -= NumberForAudioTravel * Time.deltaTime;
        audioSourceAudioBattle.volume -= NumberForAudioTravel * Time.deltaTime;
        if (audioSourceAudioTravel.volume <= 0.3f && SwitchesToASmallerNumberForMinusAudioTravel == false)
        {
            SwitchesToASmallerNumberForMinusAudioTravel = true;
            NumberForAudioTravel = 0.3f;
            AudioMenuPlay();
            SwitchForIncreasesAudioMenuVolume = true;
        }
        if (audioSourceAudioTravel.volume <= 0f)
        {
            AudioTravelPause();
            AudioBattlePause();
            SwitchForDecreaseAudioTravelVolume = true;
        }
        // Debug.Log("Menu 2 " + "- " + NumberForAudioTravel);
    }

    void IncreasesAudioMenuVolume()
    {
        audioSourceAudioMenu.volume += NumberForAudioMenu * Time.deltaTime;
        if (audioSourceAudioMenu.volume >= 0.3f && SwitchesToASmallerNumberForPlusAudioMenu == false)
        {
            SwitchesToASmallerNumberForPlusAudioMenu = true;
            NumberForAudioMenu = 0.3f;
        }
        if (audioSourceAudioMenu.volume >= 1)
        {
            NumberForAudioMenu = 0.6f;
            SwitchForIncreasesAudioMenuVolume = false;
        }
    }

    public void SwitchFromAudioOtherToAudioBattle()
    {
        NumberForAudioBattle = 0.6f;
        audioSourceAudioBattle.volume = 1f;
        SwitchesToASmallerNumberForPlusAudioBattle = false;
        SwitchesToASmallerNumberForMinusAudioBattle = false;
        if (audioSourceAudioBattle.volume > 0.3f) audioSourceAudioBattle.volume = 0f;
        SwitchForDecreaseAudioBattleVolume = false;
    }

    void DecreaseAudioBattleVolume()
    {
        audioSourceAudioTravel.volume -= NumberForAudioTravel * Time.deltaTime;
        if (audioSourceAudioTravel.volume <= 0.3f && SwitchesToASmallerNumberForMinusAudioBattle == false)
        {
            SwitchesToASmallerNumberForMinusAudioBattle = true;
            NumberForAudioTravel = 0.3f;
            AudioBattlePlay();
            SwitchForIncreasesAudioBattleVolume = true;
        }
        if (audioSourceAudioTravel.volume <= 0f)
        {
            AudioTravelPause();
            SwitchForDecreaseAudioBattleVolume = true;
        }
        // Debug.Log("battle 2 " + "- " + NumberForAudioTravel);
    }

    void IncreasesAudioBattleVolume()
    {
        audioSourceAudioBattle.volume += NumberForAudioBattle * Time.deltaTime;
        if (audioSourceAudioBattle.volume >= 0.3f && SwitchesToASmallerNumberForPlusAudioBattle == false)
        {
            SwitchesToASmallerNumberForPlusAudioBattle = true;
            NumberForAudioBattle = 0.3f;
        }
        if (audioSourceAudioBattle.volume >= 1)
        {
            NumberForAudioBattle = 0.6f;
            SwitchForIncreasesAudioBattleVolume = false;
        }
        // Debug.Log("battle 3 " + "+ "+ NumberForAudioBattle);
    }

    public void SwitchFromAudioMenuToAudioTravel()
    {
        NumberForAudioTravel = 0.6f;
        audioSourceAudioMenu.volume = 1f;
        SwitchesToASmallerNumberForPlusAudioMenu = false;
        SwitchesToASmallerNumberForMinusAudioMenu = false;
        if (audioSourceAudioTravel.volume > 0.3f) audioSourceAudioTravel.volume = 0f;
        SwitchForDecreaseAudioMenuVolume = false;
    }

    void DecreaseAudioMenuVolume()
    {
        audioSourceAudioMenu.volume -= NumberForAudioMenu * Time.deltaTime;
        if (audioSourceAudioMenu.volume <= 0.3f && SwitchesToASmallerNumberForMinusAudioMenu == false)
        {
            SwitchesToASmallerNumberForMinusAudioMenu = true;
            NumberForAudioMenu = 0.3f;
            AudioMenuPause();
            AudioBattlePause();
            SwitchForIncreasesAudioTravelVolume = true;
        }
        if (audioSourceAudioMenu.volume <= 0f)
        {
            AudioTravelPlay();
            SwitchForDecreaseAudioMenuVolume = true;
        }
        // Debug.Log("travel 2 " + "- " + NumberForAudioMenu);
    }

    void IncreasesAudioTravelVolume()
    {
        audioSourceAudioTravel.volume += NumberForAudioTravel * Time.deltaTime;
        if (audioSourceAudioTravel.volume >= 0.3f && SwitchesToASmallerNumberForPlusAudioTravel == false)
        {
            NumberForAudioTravel = 0.3f;
            SwitchesToASmallerNumberForPlusAudioTravel = true;
        }
        if (audioSourceAudioTravel.volume >= 1)
        {
            SwitchForIncreasesAudioTravelVolume = false;
            NumberForAudioTravel = 0.6f;
        }
        // Debug.Log("travel 3" + "+ " + NumberForAudioTravel);
    }

    void AudioMenuPause()
    {
        audioSourceAudioMenu.Pause();
        PauseCheckAudioTravel = true;
    }

    void AudioMenuPlay()
    {
        audioSourceAudioMenu.UnPause();
        PauseCheckAudioMenu = false;
    }

    void AudioTravelPause()
    {
        audioSourceAudioTravel.Pause();
        PauseCheckAudioMenu = true;
    }

    void AudioTravelPlay()
    {
        audioSourceAudioTravel.UnPause();
        PauseCheckAudioTravel = false;
    }

    void AudioBattlePause()
    {
        audioSourceAudioBattle.Pause();
    }

    void AudioBattlePlay()
    {
        audioSourceAudioBattle.UnPause();
    }
}