using System.Collections.Generic;
using System;
using UnityEngine;
using Yarn.Unity;

public class PortraitsBackgrounds : MonoBehaviour
{
    [SerializeField] DialogueRunner runner;
    [SerializeField] SpriteRenderer leftPortrait;
    [SerializeField] SpriteRenderer rightPortrait;
    [SerializeField] SpriteRenderer middlePortrait;
    [SerializeField] SpriteRenderer bg;
    [SerializeField] CustomSpriteDictionary sprites;
    private Dictionary<string, Sprite> spritesDict;

    private void Awake()
    {
        spritesDict = sprites.ToDictionary();
        runner.AddCommandHandler<string>("SetLeft", SetLeftPortrait);
        runner.AddCommandHandler<string>("SetRight", SetRightPortrait);
        runner.AddCommandHandler<string>("SetMiddle", SetMiddlePortrait);
        runner.AddCommandHandler<string>("SetBg", SetBackground);
    }

    private void SetLeftPortrait(string s)
    {
        if (s == "Empty")
        {
            leftPortrait.sprite = null;
            return;
        }

        leftPortrait.sprite = spritesDict[s];
    }

    private void SetRightPortrait(string s)
    {
        if (s == "Empty")
        {
            rightPortrait.sprite = null;
            return;
        }

        rightPortrait.sprite = spritesDict[s];
    }

    private void SetMiddlePortrait(string s)
    {
        if (s == "Empty")
        {
            middlePortrait.sprite = null;
            return;
        }

        middlePortrait.sprite = spritesDict[s];
    }

    private void SetBackground(string s)
    {
        bg.sprite = spritesDict[s];
    }
}

[Serializable]
public class CustomSpriteDictionary
{
    [SerializeField] List<CustomDictionarySprite> items;

    public Dictionary<string, Sprite> ToDictionary()
    {
        Dictionary<string, Sprite> newDict = new Dictionary<string, Sprite>();

        foreach (CustomDictionarySprite item in items)
        {
            newDict.Add(item.name, item.sprite);
        }
        return newDict;
    }
}

[Serializable]
public class CustomDictionarySprite
{
    [SerializeField] public string name;
    [SerializeField] public Sprite sprite;
}

