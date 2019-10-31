using UnityEngine;

public class AudioForRandomEvent : MonoBehaviour
{
    public AudioClip[] AudioForTheFirstLayer;
    public AudioSource AudioSourceForFirstLayer;
    public AudioClip[] AudioForTheSecondLayer;
    public AudioSource AudioSourceForSecondLLayer;

    private static System.Random RandomAudioForRandomEvent = new System.Random();
    private static System.Random RandomChooseTheNumberOfLayers = new System.Random();

    public void ChooseTheNumberOfLayers()
    {
        int layer = RandomChooseTheNumberOfLayers.Next(0, 25);
        if (layer == 0 || layer == 15) ForTheFirstLayer();
        if (layer == 4) ForTheSecondLayer();
        if (layer == 7)
        {
            ForTheFirstLayer();
            ForTheSecondLayer();
        }
    }

    void ForTheFirstLayer()
    {
        if (AudioSourceForFirstLayer.isPlaying == false)
        {
            int index = RandomAudioForRandomEvent.Next(0, AudioForTheFirstLayer.Length);
            AudioSourceForFirstLayer.volume = Random.Range(0.4f, 1f);
            AudioSourceForFirstLayer.pitch = Random.Range(0.9f, 1.1f);
            AudioSourceForFirstLayer.PlayOneShot(AudioForTheFirstLayer[index]);
        }
    }

    void ForTheSecondLayer()
    {
        if (AudioSourceForSecondLLayer.isPlaying == false)
        {
            int index = RandomAudioForRandomEvent.Next(0, AudioForTheSecondLayer.Length);
            AudioSourceForSecondLLayer.volume = Random.Range(0.4f, 1f);
            AudioSourceForSecondLLayer.pitch = Random.Range(0.9f, 1f);
            AudioSourceForSecondLLayer.PlayOneShot(AudioForTheSecondLayer[index]);
        }
    }
}