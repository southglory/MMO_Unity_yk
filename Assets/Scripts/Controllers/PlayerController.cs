﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
	PlayerStat _stat;
	Vector3 _destPos;

    void Start()
	{
      
        _stat = gameObject.GetComponent<PlayerStat>();
		//Managers.Input.KeyAction -= OnKeyboard;
		//Managers.Input.KeyAction += OnKeyboard;
		Managers.Input.MouseAction -= OnMouseEvent;
		Managers.Input.MouseAction += OnMouseEvent;
    }



	public enum PlayerState
	{
		Die,
		Moving,
		Idle,
		Skill,
	}

	[SerializeField]
	PlayerState _state = PlayerState.Idle;

	public PlayerState State
	{
		get { return _state; }
		set
		{
			_state = value;
			Animator anim = GetComponent<Animator>();
			switch (_state)
			{
				case PlayerState.Die:
                    anim.SetBool("attack", false);
                    break;
				case PlayerState.Idle:
                    anim.SetFloat("speed", 0);
                    anim.SetBool("attack", false);
                    break;
                case PlayerState.Moving:
                    anim.SetFloat("speed", _stat.MoveSpeed);
                    anim.SetBool("attack", false);
                    break;
                case PlayerState.Skill:
                    anim.SetBool("attack", true);
                    break;
			}
		}
	}
	void UpdateDie()
	{
		// 아무것도 못함.
    }

	void UpdateMoving()
	{
		// 몬스터가 내 사정거리보다 가까우면 공격
		if (_lockTarget != null)
		{
			_destPos = _lockTarget.transform.position;
			float distance = (_destPos - transform.position).magnitude;
			if (distance <= 1)
			{
                State = PlayerState.Skill;
				return;
			}

        }

		// 이동
        Vector3 dir = _destPos - transform.position;
        if (dir.magnitude < 0.1f)
        {
            State = PlayerState.Idle;
        }
        else
        {
			// TODO
			NavMeshAgent nma = gameObject.GetOrAddComponent<NavMeshAgent>();

            float moveDist = Mathf.Clamp(_stat.MoveSpeed * Time.deltaTime, 0, dir.magnitude);
			//nma.CalculatePath
			nma.Move(dir.normalized * moveDist);

			Debug.DrawRay(transform.position + Vector3.up * 0.5f, dir.normalized, Color.green);
			if (Physics.Raycast(transform.position + Vector3.up * 0.5f, dir, 1.0f, LayerMask.GetMask("Block")))
			{
				if (Input.GetMouseButton(0) == false)
                    State = PlayerState.Idle;
				return;
			}

            //transform.position += dir.normalized * moveDist;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 20 * Time.deltaTime);
        }



    }


	void UpdateIdle()
	{

    }

	void UpdateSkill()
	{
	}

	void OnHitEvent()
	{
		Debug.Log("OnHitEvent");
        State = PlayerState.Moving;
	}

    void Update()
    {

        switch (State)
        {
            case PlayerState.Die:
                UpdateDie();
                break;
            case PlayerState.Moving:
                UpdateMoving();
                break;
            case PlayerState.Idle:
                UpdateIdle();
                break;
			case PlayerState.Skill:
				UpdateSkill();
				break;

        }

    }

	//   void OnKeyboard()
	//   {
	//	if (Input.GetKey(KeyCode.W))
	//	{
	//		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 0.2f);
	//		transform.position += Vector3.forward * Time.deltaTime * _speed;
	//	}

	//	if (Input.GetKey(KeyCode.S))
	//	{
	//		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 0.2f);
	//		transform.position += Vector3.back * Time.deltaTime * _speed;
	//	}

	//	if (Input.GetKey(KeyCode.A))
	//	{
	//		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 0.2f);
	//		transform.position += Vector3.left * Time.deltaTime * _speed;
	//	}

	//	if (Input.GetKey(KeyCode.D))
	//	{
	//		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), 0.2f);
	//		transform.position += Vector3.right * Time.deltaTime * _speed;
	//	}

	//	_moveToDest = false;
	//}


	int _mask = (1 << (int)Define.Layer.Ground) | (1 << (int)Define.Layer.Monster);

	GameObject _lockTarget;
	void OnMouseEvent(Define.MouseEvent evt)
	{
		if (State == PlayerState.Die)
			return;

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		bool raycastHit = Physics.Raycast(ray, out hit, 100.0f, _mask);
        //Debug.DrawRay(Camera.main.transform.position, ray.direction * 100.0f, Color.red, 1.0f);

		switch (evt)
		{
			case Define.MouseEvent.PointerDown:
				{
					if (raycastHit)
					{
                        _destPos = hit.point;
                        State = PlayerState.Moving;

						if (hit.collider.gameObject.layer == (int)Define.Layer.Monster)
							_lockTarget = hit.collider.gameObject;
						else
							_lockTarget = null;
                    }
                }
				break;
            case Define.MouseEvent.Press:
				{
					if (_lockTarget != null)
						_destPos = _lockTarget.transform.position;
					else if (raycastHit)
						_destPos = hit.point;
				}
                break;
        }
	}
}
