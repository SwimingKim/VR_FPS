using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CInputMovement : MonoBehaviour
{

    CharacterController _cc;
	CCharacterAnimation _anim;

    Vector3 _moveDir = Vector3.zero;

    public float _speed;
    public float _gravity;

    void Awake()
    {
        _cc = GetComponent<CharacterController>();
		_anim = GetComponent<CCharacterAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");

		_moveDir = new Vector3(h, 0f, v);
		if (_moveDir == Vector3.zero)
		{
			_anim.setSpeedValue(0f);
			// _anim.PlayAnimation(CCharacterAnimation.ANIM_TYPE.IDLE);
		}
		else
		{
			transform.forward = _moveDir.normalized;

			float speed = _speed;
			if (h != 0 && v != 0)
			{
				float degree = Mathf.Cos(45f * Mathf.Deg2Rad);
				speed *= degree;
			}
			
			_moveDir *= speed;
			_moveDir.y -= _gravity;

			_anim.setSpeedValue(0.4f);
			// _anim.PlayAnimation(CCharacterAnimation.ANIM_TYPE.WALK);
			_cc.Move(_moveDir * Time.deltaTime);

			return;
		}
    }

}
