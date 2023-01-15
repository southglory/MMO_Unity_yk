using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Serializable이란, 메모리에서 들고 있던 것을 파일로 변환할 수 있다는 의미. Deserialize는 파일에서 메모리로.

[Serializable]
public class Stat
{
    // public 붙여야지 serializable 적용이 되는데, 굳이 public붙이기 싫고 private하게 쓰고 싶다면 SerializeField선언을 해주어야 함.
    [SerializeField]
    int level;

    public int hp;
    public int attack;
}

[Serializable]
public class StatData
{
    public List<Stat> stats = new List<Stat>();
}

public class DataManager
{
    public void Init()
    {
        TextAsset textAsset = Managers.Resource.Load<TextAsset>($"Data/StatData");
        StatData data = JsonUtility.FromJson<StatData>(textAsset.text);
    }
}
