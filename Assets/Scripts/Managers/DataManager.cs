using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager
{
    public void Init()
    {
        TextAsset textAsset = Managers.Resource.Load<TextAsset>($"Data/StatData");
        Debug.Log(textAsset.text);
    }
}
