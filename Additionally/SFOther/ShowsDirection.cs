using UnityEngine;

public class ShowsDirection : MonoBehaviour
{
    public GameObject TrackDirectionFull0;
    public GameObject TrackDirectionFull1;
    public GameObject TrackDirectionS;
    public GameObject TrackDirectionN;
    public GameObject TrackDirectionE;
    public GameObject TrackDirectionW;
    public GameObject TrackDirectionES;
    public GameObject TrackDirectionNE;
    public GameObject TrackDirectionWN;
    public GameObject TrackDirectionEW;
    public GameObject TrackDirectionSW;
    public GameObject TrackDirectionSN;
    public GameObject TrackDirectionNES;
    public GameObject TrackDirectionENW;
    public GameObject TrackDirectionNWS;
    public GameObject TrackDirectionWNE;
    public GameObject TrackDirection;

    public void DirectionSelection(bool S, bool N, bool E, bool W)
    {
        TrackDirection.SetActive(false);
        if (S == true) TrackDirection = TrackDirectionS;
        if (N == true) TrackDirection = TrackDirectionN;
        if (E == true) TrackDirection = TrackDirectionE;
        if (W == true) TrackDirection = TrackDirectionW;
        if (E == true && S == true) TrackDirection = TrackDirectionES;
        if (N == true && E == true) TrackDirection = TrackDirectionNE;
        if (W == true && N == true) TrackDirection = TrackDirectionWN;
        if (E == true && W == true) TrackDirection = TrackDirectionEW;
        if (S == true && W == true) TrackDirection = TrackDirectionSW;
        if (S == true && N == true) TrackDirection = TrackDirectionSN;
        if (N == true && E == true && S == true) TrackDirection = TrackDirectionNES;
        if (E == true && N == true && W == true) TrackDirection = TrackDirectionENW;
        if (N == true && W == true && S == true) TrackDirection = TrackDirectionNWS;
        if (W == true && N == true && E == true) TrackDirection = TrackDirectionWNE;
        if (W == true && N == true && E == true && S == true) TrackDirection = TrackDirectionFull1;
        if (W == false && N == false && E == false && S == false) TrackDirection = TrackDirectionFull0;
        TrackDirection.SetActive(true);
    }
}