using UnityEngine;

public class AudioCry : MonoBehaviour
{
    public AudioClip[] AudioForLayerWithACry;
    public AudioSource AudioSourceForLayerWithACry;

    int index;

    public void SelectAudiForCry()
    {
        if (AudioSourceForLayerWithACry.isPlaying == false)
        {
            index = Random.Range(0, AudioForLayerWithACry.Length);
            AudioSourceForLayerWithACry.volume = Random.Range(0.5f, 1f);
            AudioSourceForLayerWithACry.pitch = Random.Range(0.9f, 1.1f);
            AudioSourceForLayerWithACry.PlayOneShot(AudioForLayerWithACry[index]);
        }
    }
}