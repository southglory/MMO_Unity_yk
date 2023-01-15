using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    class Test
    {
        public int Id = 0;
    }

    // 1. �Լ��� ���¸� ����/���� ����!
        // -> ��û ���� �ɸ��� �۾��� ��� ���ų�
        // -> ���ϴ� Ÿ�ֿ̹� �Լ��� ��� Stop/�����ϴ� ���
    // 2. return -> �츮�� ���ϴ� Ÿ������ ���� (class�� ����)
    class CoroutineTest: IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < 1000000; i++)
            {
                if (i%100000 == 0)
                    yield return null;
            }
        }
        float deltaTime = 0;
        void ExplodeAfter4Seconds()
        {
            deltaTime+= Time.deltaTime;
            if (deltaTime >= 4)
            {
                // ����
            }
        }
        void GenerateItem()
        {
            // ����
            // �������� ������ش�
            // DB����


            // ������
            // ���� ����
            // ����
        }
    }

    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Game;

        Managers.UI.ShowSceneUI<UI_Inven>();

        CoroutineTest test = new CoroutineTest();
        foreach (System.Object t in test)
        {
            Test value = (Test)t;
            Debug.Log(value.Id);
        }

    }

    public override void Clear()
    {
        
    }
}
