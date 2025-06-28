using TMPro;
using UnityEngine;
using Yarn.Unity;

public class BonesCount : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] DialogueRunner runner;
    private float bones;

    // Update is called once per frame
    void Update()
    {
        GetBoneCount();
        text.text = "Bones: " + bones; 
    }

    void GetBoneCount()
    {
        runner.VariableStorage.TryGetValue<float>("$Bones", out bones);
    }
}
