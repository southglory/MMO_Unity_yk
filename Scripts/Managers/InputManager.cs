using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    //전형적인 리스터 패턴
    public Action KeyAction = null;//delegator(대리자)

    public void onUpdate()//누군가가 직접 불러줘야 하니까 on- 
        //여기서만 업데이트하니까, 플레이어컨트롤러가 몇개이든 동시에 한번씩만 업데이트체크 될 수 있도록 함.
    {
        if (Input.anyKey == false)
            return;

        if (KeyAction != null)
            KeyAction.Invoke();
    }
}
