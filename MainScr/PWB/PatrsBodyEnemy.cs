using UnityEngine;

public class PatrsBodyEnemy : MonoBehaviour
{
    public GameObject EnemyHead;
    public GameObject EnemyBody;
    public GameObject EnemyLeftHand;
    public GameObject EnemyRightHand;
    public GameObject EnemyLeftLeg;
    public GameObject EnemyRightLeg;

    string Gray = "B7B7B7"; // E0E0E0
    string Red = "BC5252";
    string Yellow = "BC9F2C";

    void Start()
    {
        SpriteRenderer spriteRendererHead = EnemyHead.GetComponent<SpriteRenderer>();
        spriteRendererHead.color = GetColorFromString(Gray);
        SpriteRenderer spriteRendererBody = EnemyBody.GetComponent<SpriteRenderer>();
        spriteRendererBody.color = GetColorFromString(Gray);
        SpriteRenderer spriteRendererLeftHand = EnemyLeftHand.GetComponent<SpriteRenderer>();
        spriteRendererLeftHand.color = GetColorFromString(Gray);
        SpriteRenderer spriteRendererRightHand = EnemyRightHand.GetComponent<SpriteRenderer>();
        spriteRendererRightHand.color = GetColorFromString(Gray);
        SpriteRenderer spriteRendererLeftLeg = EnemyLeftLeg.GetComponent<SpriteRenderer>();
        spriteRendererLeftLeg.color = GetColorFromString(Gray);
        SpriteRenderer spriteRendererRightLeg = EnemyRightLeg.GetComponent<SpriteRenderer>();
        spriteRendererRightLeg.color = GetColorFromString(Gray);
    }

    public void SwitchToPartsBody(string State, string PartBody)
    {      
        if (PartBody == "голова") Head(State);
        if (PartBody == "тело") Body(State);
        if (PartBody == "левая рука") LeftHand(State);
        if (PartBody == "правая рука") RightHand(State);
        if (PartBody == "левая нога") LeftLeg(State);
        if (PartBody == "правая нога") RightLeg(State);
    }

    void Head(string State)
    {
        if (State == "Не поврежденный")
        {
            SpriteRenderer spriteRenderer = EnemyHead.GetComponent<SpriteRenderer>();
            spriteRenderer.color = GetColorFromString(Gray);
        }
        if (State == "Больше половины")
        {
            SpriteRenderer spriteRenderer = EnemyHead.GetComponent<SpriteRenderer>();
            spriteRenderer.color = GetColorFromString(Yellow);
        }
        if (State == "Равна нулю")
        {
            SpriteRenderer spriteRenderer = EnemyHead.GetComponent<SpriteRenderer>();
            spriteRenderer.color = GetColorFromString(Red);
        }
    }

    void Body(string State)
    {
        if (State == "Не поврежденный")
        {
            SpriteRenderer spriteRenderer = EnemyBody.GetComponent<SpriteRenderer>();
            spriteRenderer.color = GetColorFromString(Gray);
        }
        if (State == "Больше половины")
        {
            SpriteRenderer spriteRenderer = EnemyBody.GetComponent<SpriteRenderer>();
            spriteRenderer.color = GetColorFromString(Yellow);
        }
        if (State == "Равна нулю")
        {
            SpriteRenderer spriteRenderer = EnemyBody.GetComponent<SpriteRenderer>();
            spriteRenderer.color = GetColorFromString(Red);
        }
    }

    void LeftHand(string State)
    {
        if (State == "Не поврежденный")
        {
            SpriteRenderer spriteRenderer = EnemyLeftHand.GetComponent<SpriteRenderer>();
            spriteRenderer.color = GetColorFromString(Gray);
        }
        if (State == "Больше половины")
        {
            SpriteRenderer spriteRenderer = EnemyLeftHand.GetComponent<SpriteRenderer>();
            spriteRenderer.color = GetColorFromString(Yellow);
        }
        if (State == "Равна нулю")
        {
            SpriteRenderer spriteRenderer = EnemyLeftHand.GetComponent<SpriteRenderer>();
            spriteRenderer.color = GetColorFromString(Red);
        }

    }

    void RightHand(string State)
    {
        if (State == "Не поврежденный")
        {
            SpriteRenderer spriteRenderer = EnemyRightHand.GetComponent<SpriteRenderer>();
            spriteRenderer.color = GetColorFromString(Gray);
        }
        if (State == "Больше половины")
        {
            SpriteRenderer spriteRenderer = EnemyRightHand.GetComponent<SpriteRenderer>();
            spriteRenderer.color = GetColorFromString(Yellow);
        }
        if (State == "Равна нулю")
        {
            SpriteRenderer spriteRenderer = EnemyRightHand.GetComponent<SpriteRenderer>();
            spriteRenderer.color = GetColorFromString(Red);
        }
    }

    void LeftLeg(string State)
    {
        if (State == "Не поврежденный")
        {
            SpriteRenderer spriteRenderer = EnemyLeftLeg.GetComponent<SpriteRenderer>();
            spriteRenderer.color = GetColorFromString(Gray);
        }
        if (State == "Больше половины")
        {
            SpriteRenderer spriteRenderer = EnemyLeftLeg.GetComponent<SpriteRenderer>();
            spriteRenderer.color = GetColorFromString(Yellow);
        }
        if (State == "Равна нулю")
        {
            SpriteRenderer spriteRenderer = EnemyLeftLeg.GetComponent<SpriteRenderer>();
            spriteRenderer.color = GetColorFromString(Red);
        }
    }

    void RightLeg(string State)
    {
        if (State == "Не поврежденный")
        {
            SpriteRenderer spriteRenderer = EnemyRightLeg.GetComponent<SpriteRenderer>();
            spriteRenderer.color = GetColorFromString(Gray);
        }
        if (State == "Больше половины")
        {
            SpriteRenderer spriteRenderer = EnemyRightLeg.GetComponent<SpriteRenderer>();
            spriteRenderer.color = GetColorFromString(Yellow);
        }
        if (State == "Равна нулю")
        {
            SpriteRenderer spriteRenderer = EnemyRightLeg.GetComponent<SpriteRenderer>();
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