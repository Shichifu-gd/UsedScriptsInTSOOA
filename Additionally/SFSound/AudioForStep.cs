using UnityEngine;

public class AudioForStep : MonoBehaviour
{
    public AudioClip[] AudioForLayerWithAStep;
    public AudioSource AudioSourceForLayerWithAStep;
    int index;

    public void SelectAudiForStep()
    {
        if (index != AudioForLayerWithAStep.Length - 1) index++;
        else index = 0;
        AudioSourceForLayerWithAStep.volume = Random.Range(0.5f, 1f);
        AudioSourceForLayerWithAStep.pitch = Random.Range(0.9f, 1.3f);
        AudioSourceForLayerWithAStep.PlayOneShot(AudioForLayerWithAStep[index]);
    }
}