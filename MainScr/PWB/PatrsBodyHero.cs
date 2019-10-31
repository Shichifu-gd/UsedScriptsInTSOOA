using UnityEngine;

public class PatrsBodyHero : MonoBehaviour
{
    public GameObject HeroHead;
    public GameObject HeroBody;
    public GameObject HeroLeftHand;
    public GameObject HeroRightHand;
    public GameObject HeroLeftLeg;
    public GameObject HeroRightLeg;

    string Gray = "B7B7B7";
    string Red = "BC5252"; // BC5252 F67777
    string Yellow = "BC9F2C"; // BC9F2C ffcc00ff

    public void SwitchToPartsBody(string State, string PartBody)
    {
        if (PartBody == "голова") Head(State);
        if (PartBody == "тело") Body(State);
        if (PartBody == "левая рука") LeftHand(State);
        if (PartBody == "правая рука") RightHand(State);
        if (PartBody == "левая нога") LeftLeg(State);
        if (PartBody == "правая нога") RightLeg(State);
    }

    public void RecoveryColor()
    {
        SpriteRenderer spriteRendererHead = HeroHead.GetComponent<SpriteRenderer>();
        spriteRendererHead.color = GetColorFromString(Gray);
        SpriteRenderer spriteRendererBody = HeroBody.GetComponent<SpriteRenderer>();
        spriteRendererBody.color = GetColorFromString(Gray);
        SpriteRenderer spriteRendererLeftHand = HeroLeftHand.GetComponent<SpriteRenderer>();
        spriteRendererLeftHand.color = GetColorFromString(Gray);
        SpriteRenderer spriteRendererRightHand = HeroRightHand.GetComponent<SpriteRenderer>();
        spriteRendererRightHand.color = GetColorFromString(Gray);
        SpriteRenderer spriteRendererLeftLeg = HeroLeftLeg.GetComponent<SpriteRenderer>();
        spriteRendererLeftLeg.color = GetColorFromString(Gray);
        SpriteRenderer spriteRendererRightLeg = HeroRightLeg.GetComponent<SpriteRenderer>();
        spriteRendererRightLeg.color = GetColorFromString(Gray);
    }

    void Head(string State)
    {
        if (State == "Не поврежденный")
        {
            SpriteRenderer spriteRenderer = HeroHead.GetComponent<SpriteRenderer>();
            spriteRenderer.color = GetColorFromString(Gray);
        }
        if (State == "Больше половины")
        {
            SpriteRenderer spriteRenderer = HeroHead.GetComponent<SpriteRenderer>();
            spriteRenderer.color = GetColorFromString(Yellow);
        }
        if (State == "Равна нулю")
        {
            SpriteRenderer spriteRenderer = HeroHead.GetComponent<SpriteRenderer>();
            spriteRenderer.color = GetColorFromString(Red);
        }
    }

    void Body(string State)
    {
        if (State == "Не поврежденный")
        {
            SpriteRenderer spriteRenderer = HeroBody.GetComponent<SpriteRenderer>();
            spriteRenderer.color = GetColorFromString(Gray);
        }
        if (State == "Больше половины")
        {
            SpriteRenderer spriteRenderer = HeroBody.GetComponent<SpriteRenderer>();
            spriteRenderer.color = GetColorFromString(Yellow);
        }
        if (State == "Равна нулю")
        {
            SpriteRenderer spriteRenderer = HeroBody.GetComponent<SpriteRenderer>();
            spriteRenderer.color = GetColorFromString(Red);
        }
    }

    void LeftHand(string State)
    {
        if (State == "Не поврежденный")
        {
            SpriteRenderer spriteRenderer = HeroLeftHand.GetComponent<SpriteRenderer>();
            spriteRenderer.color = GetColorFromString(Gray);
        }
        if (State == "Больше половины")
        {
            SpriteRenderer spriteRenderer = HeroLeftHand.GetComponent<SpriteRenderer>();
            spriteRenderer.color = GetColorFromString(Yellow);
        }
        if (State == "Равна нулю")
        {
            SpriteRenderer spriteRenderer = HeroLeftHand.GetComponent<SpriteRenderer>();
            spriteRenderer.color = GetColorFromString(Red);
        }

    }

    void RightHand(string State)
    {
        if (State == "Не поврежденный")
        {
            SpriteRenderer spriteRenderer = HeroRightHand.GetComponent<SpriteRenderer>();
            spriteRenderer.color = GetColorFromString(Gray);
        }
        if (State == "Больше половины")
        {
            SpriteRenderer spriteRenderer = HeroRightHand.GetComponent<SpriteRenderer>();
            spriteRenderer.color = GetColorFromString(Yellow);
        }
        if (State == "Равна нулю")
        {
            SpriteRenderer spriteRenderer = HeroRightHand.GetComponent<SpriteRenderer>();
            spriteRenderer.color = GetColorFromString(Red);
        }
    }

    void LeftLeg(string State)
    {
        if (State == "Не поврежденный")
        {
            SpriteRenderer spriteRenderer = HeroLeftLeg.GetComponent<SpriteRenderer>();
            spriteRenderer.color = GetColorFromString(Gray);
        }
        if (State == "Больше половины")
        {
            SpriteRenderer spriteRenderer = HeroLeftLeg.GetComponent<SpriteRenderer>();
            spriteRenderer.color = GetColorFromString(Yellow);
        }
        if (State == "Равна нулю")
        {
            SpriteRenderer spriteRenderer = HeroLeftLeg.GetComponent<SpriteRenderer>();
            spriteRenderer.color = GetColorFromString(Red);
        }
    }

    void RightLeg(string State)
    {
        if (State == "Не поврежденный")
        {
            SpriteRenderer spriteRenderer = HeroRightLeg.GetComponent<SpriteRenderer>();
            spriteRenderer.color = GetColorFromString(Gray);
        }
        if (State == "Больше половины")
        {
            SpriteRenderer spriteRenderer = HeroRightLeg.GetComponent<SpriteRenderer>();
            spriteRenderer.color = GetColorFromString(Yellow);
        }
        if (State == "Равна нулю")
        {
            SpriteRenderer spriteRenderer = HeroRightLeg.GetComponent<SpriteRenderer>();
            spriteRenderer.color = GetColorFromString(Red);
        }
    }

    private int HexToDec(string hex)
    {
        int dec = System.Convert.ToInt32(hex, 16);
        return dec;
    }

    private string DecToHex(int value)
    {
        return value.ToString("X2");
    }

    private string FloatNormalizedToHex(float value)
    {
        return DecToHex(Mathf.RoundToInt(value * 255f));
    }

    private float HexToFloatNormalized(string hex)
    {
        return HexToDec(hex) / 255f;
    }

    private Color GetColorFromString(string hexString)
    {
        float red = HexToFloatNormalized(hexString.Substring(0, 2));
        float green = HexToFloatNormalized(hexString.Substring(2, 2));
        float blue = HexToFloatNormalized(hexString.Substring(4, 2));
        float alpha = 1f;
        if (hexString.Length >= 8)
        {
            alpha = HexToFloatNormalized(hexString.Substring(6, 2));
        }
        return new Color(red, green, blue, alpha);
    }

    private string GetStringFromColor(Color color, bool useAlpha = false)
    {
        string red = FloatNormalizedToHex(color.r);
        string green = FloatNormalizedToHex(color.g);
        string blue = FloatNormalizedToHex(color.b);
        if (!useAlpha)
        {
            return red + green + blue;
        }
        else
        {
            string alpha = FloatNormalizedToHex(color.a);
            return red + green + blue + alpha;
        }
    }
}