using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers s_Instance; // ���ϼ��� ����ȴ�.
    public static Managers Instance { get { Init();  return s_Instance; } } //������ �Ŵ����� ���� �´�.


    // Start is called before the first frame update
    void Start()
    {
        //�ʱ�ȭ
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
