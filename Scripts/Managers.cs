using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers s_Instance; // 유일성이 보장된다.
    public static Managers Instance { get { Init();  return s_Instance; } } //유일한 매니저를 갖고 온다.


    // Start is called before the first frame update
    void Start()
    {
        //초기화
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    static void Init()
    {
        if (s_Instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            if (go == null)
            {
                go = new GameObject { name = "@Managers" };
                go.AddComponent<Managers>();
            }

            DontDestroyOnLoad(go);
            s_Instance = go.GetComponent<Managers>();
        }
        
    }

}
