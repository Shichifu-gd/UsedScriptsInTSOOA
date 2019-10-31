using UnityEngine.UI;
using UnityEngine;
using System.IO;

public class Score : MonoBehaviour
{
    public Text TextForScore;

    public int CurrentScoreTransitions = -1;

    private void Start()
    {
        if (File.Exists(Application.dataPath + "/Score.sav")) LoadTransitions();
        else TextForScore.text = "" + CurrentScoreTransitions;
    }

    public void CountsTransitions()
    {
        CurrentScoreTransitions++;
        TextForScore.text = "" + CurrentScoreTransitions;
    }

    public void SaveTransitions()
    {
        SaveAndLoadTBM.SaveScore(this);
    }

    public void LoadTransitions()
    {
        int[] DataScore = SaveAndLoadTBM.LoadScore();
        CurrentScoreTransitions = DataScore[0];
        TextForScore.text = "" + CurrentScoreTransitions;
    }
}