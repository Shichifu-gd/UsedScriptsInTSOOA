using UnityEngine.SceneManagement;
using UnityEngine;

public class Attenuation : MonoBehaviour
{
    public GameObject FadingObject;
    public AudioCry audioCry;

    string NameScene;

    [HideInInspector]
    public float ColorA;
    float time;
    float TimeEnd;

    [HideInInspector]
    public bool SwitcTheAppearanceForCharacteristicsHero;
    public bool TurnOnAtStart = true;
    public bool TurnOnCrying;
    public bool ShortenedTime;
    bool SwitcTheAppearance;
    bool SwitchAttenuat;

    private void Start()
    {
        if (ShortenedTime == true) TimeEnd = 1;
        else TimeEnd = 3;
        if (TurnOnAtStart == true) FadingObject.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 1f);
    }

    void FixedUpdate()
    {
        if (SwitcTheAppearance == true) ForTransitionFromLevelToLevel();
        if (SwitcTheAppearanceForCharacteristicsHero == true) ForLevelWithCharacteristics();
        if (SwitchAttenuat == true) ActivatedWhenTheLevelStarts();
    }

    void ForTransitionFromLevelToLevel()
    {
        if (ColorA < 1)
        {
            ColorA += 0.3f * Time.deltaTime;
            ColorA = (float)System.Math.Round(ColorA, 2);
            FadingObject.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, ColorA);
            if (ColorA >= 1)
            {
                SwitcTheAppearance = false;
                SceneManager.LoadSceneAsync(NameScene);
            }
        }
    }

    void ForLevelWithCharacteristics()
    {
        if (ColorA < 1)
        {
            ColorA += 0.3f * Time.deltaTime;
            ColorA = (float)System.Math.Round(ColorA, 2);
            FadingObject.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, ColorA);
            if (ColorA >= 1)
            {
                SwitchAttenuat = true;
                TurnOnCrying = true;
                SwitcTheAppearanceForCharacteristicsHero = false;
            }
        }
    }

    void ActivatedWhenTheLevelStarts()
    {
        if (time < 3) time += 03f * Time.deltaTime;
        if (ColorA > 0 && time >= TimeEnd)
        {
            if (TurnOnCrying == true && audioCry == true)
            {
                audioCry.SelectAudiForCry();
                TurnOnCrying = false;
            }
            ColorA -= 0.3f * Time.deltaTime;
            ColorA = (float)System.Math.Round(ColorA, 2);
            FadingObject.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, ColorA);
            if (ColorA <= 0) SwitchAttenuat = false;
        }
    }

    public void TheAppearanceOfObject(string name)
    {
        if (SwitcTheAppearance == false)
        {
            ColorA = 0f;
            SwitcTheAppearance = true;
            NameScene = name;
        }
    }

    public void AttenuationObjectForCharacteristicsHero()
    {
        if (SwitcTheAppearanceForCharacteristicsHero == false)
        {
            ColorA = 0f;
            SwitcTheAppearanceForCharacteristicsHero = true;
            NameScene = name;
        }
    }

    public void AttenuationObject()
    {
        if (SwitchAttenuat == false)
        {
            ColorA = 1f;
            SwitchAttenuat = true;
        }
    }
}