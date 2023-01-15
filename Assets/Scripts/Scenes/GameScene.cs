using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    class Test
    {
        public int Id = 0;
    }
    class CoroutineTest: IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < 1000000; i++)
            {
                if (i%100000 == 0)
                    yield return null;
            }
            //yield return new Test() { Id = 1 };
            //yield return new Test() { Id = 2 };
            //yield return new Test() { Id = 3 };
            //yield return new Test() { Id = 4 };
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
