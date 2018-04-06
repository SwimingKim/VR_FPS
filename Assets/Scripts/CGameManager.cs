using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CGameManager : MonoBehaviour
{
    public Text _timerText;
    public Text _messageText;
	public Animation[] _anims;

    [SerializeField] CCameraManager cameraManager;
    [SerializeField] CCharacterManager characterManager;

	void Start()
	{
		Debug.Log(PhotonNetwork.room.PlayerCount.ToString());
		
		StartCoroutine("ShowTimer");
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            cameraManager.IsRun = !cameraManager.IsRun;
            characterManager._anim.PlayAnimation(cameraManager.IsRun ? CCharacterAnimation.ANIM_TYPE.WALK : CCharacterAnimation.ANIM_TYPE.IDLE);
        }
    }

	IEnumerator ShowTimer()
	{
		yield return new WaitForSeconds(1);
		int sec = int.Parse(_timerText.text);
		if (sec > 0)
		{
			_timerText.text = (sec-1).ToString();
			StartCoroutine("ShowTimer");
		}
		else
		{
			_timerText.text = "Good Luck, "+PhotonNetwork.playerName;
			_messageText.text = "Time to Attack";
			for (var i=0; i < _anims.Length; i++)
			{
				_anims[i].Play("open");
			}
			StopCoroutine("ShowTimer");
		}
		
	}
}
