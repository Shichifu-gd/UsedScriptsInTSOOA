using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.IO;
using System;

public class SaveAndLoadBooleanVariablesForBody : MonoBehaviour
{
    public static void SaveBooleanVariables(SupplementForHeroBody supplementForHeroBody)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.dataPath + "/data/SBV.sav", FileMode.Create);
        SavingBooleanVariables data = new SavingBooleanVariables(supplementForHeroBody);
        bf.Serialize(stream, data);
        stream.Close();
    }

    public static bool[] LoadBooleanVariables()
    {
        if (File.Exists(Application.dataPath + "/data/SBV.sav"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.dataPath + "/data/SBV.sav", FileMode.Open);
            SavingBooleanVariables data = bf.Deserialize(stream) as SavingBooleanVariables;
            stream.Close();
            return data.BooleanVariables;
        }
        else return new bool[0];
    }
}

[Serializable]
public class SavingBooleanVariables
{
    public bool[] BooleanVariables;
    public SavingBooleanVariables(SupplementForHeroBody supplementForHeroBody)
    {
        BooleanVariables = new bool[18];
        BooleanVariables[0] = supplementForHeroBody.SwichBlowToTheHeadZero;
        BooleanVariables[1] = supplementForHeroBody.SwichBlowToTheHeadOne;
        BooleanVariables[2] = supplementForHeroBody.SwichBlowToTheHeadTwo;
        BooleanVariables[3] = supplementForHeroBody.SwichBlowToTheBodyZero;
        BooleanVariables[4] = supplementForHeroBody.SwichBlowToTheBodyOne;
        BooleanVariables[5] = supplementForHeroBody.SwichBlowToTheBodyTwo;
        BooleanVariables[6] = supplementForHeroBody.SwichBlowToTheLHandZero;
        BooleanVariables[7] = supplementForHeroBody.SwichBlowToTheLHandOne;
        BooleanVariables[8] = supplementForHeroBody.SwichBlowToTheLHandTwo;
        BooleanVariables[9] = supplementForHeroBody.SwichBlowToTheRHandZero;
        BooleanVariables[10] = supplementForHeroBody.SwichBlowToTheRHandOne;
        BooleanVariables[11] = supplementForHeroBody.SwichBlowToTheRHandTwo;
        BooleanVariables[12] = supplementForHeroBody.SwichBlowToTheLLegZero;
        BooleanVariables[13] = supplementForHeroBody.SwichBlowToTheLLegOne;
        BooleanVariables[14] = supplementForHeroBody.SwichBlowToTheLLegTwo;
        BooleanVariables[15] = supplementForHeroBody.SwichBlowToTheRLegZero;
        BooleanVariables[16] = supplementForHeroBody.SwichBlowToTheRLegOne;
        BooleanVariables[17] = supplementForHeroBody.SwichBlowToTheRLegTwo;
    }
}