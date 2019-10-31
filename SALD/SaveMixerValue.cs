using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.IO;
using System;

public class SaveMixerValue : MonoBehaviour
{
    public static void SaveValue(AudioManager audioManager)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.dataPath + "/data/AVM.sav", FileMode.Create);
        SavingValueMixer data = new SavingValueMixer(audioManager);
        bf.Serialize(stream, data);
        stream.Close();
    }

    public static float[] LoadValue()
    {
        if (File.Exists(Application.dataPath + "/data/AVM.sav"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.dataPath + "/data/AVM.sav", FileMode.Open);
            SavingValueMixer data = bf.Deserialize(stream) as SavingValueMixer;
            stream.Close();
            return data.ValueMixer;
        }
        else return new float[0];
    }
}

[Serializable]
public class SavingValueMixer
{
    public float[] ValueMixer;
    public SavingValueMixer(AudioManager audioManager)
    {
        ValueMixer = new float[1];
        ValueMixer[0] = audioManager.ValueMixer;
    }
}