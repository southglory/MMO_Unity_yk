using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// Serializable이란, 메모리에서 들고 있던 것을 파일로 변환할 수 있다는 의미. Deserialize는 파일에서 메모리로.

public interface ILoader<Key, Value>
{
    Dictionary<Key, Value> MakeDict();
}

public class DataManager
{
    public Dictionary<int, Stat> StatDict { get; private set; } = new Dictionary<int, Stat>();
    public void Init()
    {
        StatDict = LoadJson<StatData, int, Stat>("StatData").MakeDict();
    }

    Loader LoadJson<Loader, Key, Value>(string path) where Loader : ILoader<Key, Value>
    {
        TextAsset textAsset = Managers.Resource.Load<TextAsset>($"Data/{path}");
        return JsonUtility.FromJson<Loader>(textAsset.text);
    }
}
