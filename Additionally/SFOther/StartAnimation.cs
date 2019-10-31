using UnityEngine;

public class StartAnimation : MonoBehaviour
{
    public GameObject ObjectWithAnimation;

    public string[] AnimationName;

    private static System.Random RandomNumberForNameSelection = new System.Random();

    public void StartingTheAnimation()
    {
        if (AnimationName[0] != "")
        {
            int index = 0;
            if (AnimationName.Length > 0)
            {
                index = RandomNumberForNameSelection.Next(0, AnimationName.Length);
                ObjectWithAnimation.GetComponent<Animator>().SetTrigger(AnimationName[index]);
            }
        }
    }
}