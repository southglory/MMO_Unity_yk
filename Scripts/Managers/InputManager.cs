using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    //�������� ������ ����
    public Action KeyAction = null;//delegator(�븮��)

    public void onUpdate()//�������� ���� �ҷ���� �ϴϱ� on- 
        //���⼭�� ������Ʈ�ϴϱ�, �÷��̾���Ʈ�ѷ��� ��̵� ���ÿ� �ѹ����� ������Ʈüũ �� �� �ֵ��� ��.
    {
        if (Input.anyKey == false)
            return;

        if (KeyAction != null)
            KeyAction.Invoke();
    }
}
