using System.Collections;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] DialogueRunner runner;
    [SerializeField] Image img;

    private void Awake()
    {
        runner.AddCommandHandler<string>("Transition", Transition);
    }

    // Transition to node
    private void Transition(string node)
    {
        StartCoroutine(TransitionRoutine(node));
    }

    private IEnumerator TransitionRoutine(string node)
    {
        CrossFadeAlphaFixed(1f, 2f, false);
        yield return new WaitForSeconds(2f);
        runner.StartDialogue(node);
        img.CrossFadeAlpha(0, 2f, false);
    }

    private void CrossFadeAlphaFixed(float alpha, float duration, bool ignoreTimeScale)
    {
        //Make the alpha 1
        Color fixedColor = img.color;
        fixedColor.a = 1;
        img.color = fixedColor;

        //Set the 0 to zero then duration to 0
        img.CrossFadeAlpha(0f, 0f, true);

        //Finally perform CrossFadeAlpha
        img.CrossFadeAlpha(alpha, duration, ignoreTimeScale);
    }
}
