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
        if (GetBoneBool())
        {
            GetBoneCount();
            text.text = "Bones: " + bones;
        }
    }

    void GetBoneCount()
    {
        runner.VariableStorage.TryGetValue<float>("$Bones", out bones);
    }

    bool GetBoneBool()
    {
        bool areWeCountingYet = false;
        runner.VariableStorage.TryGetValue<bool>("$StartTheCount", out areWeCountingYet);
        return areWeCountingYet;
    }
}
