using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CGameManager : MonoBehaviour
{
    public Text _timerText;
    public Text _messageText;
	public GameObject _gamePanel;
	public Animation[] _anims;

    [SerializeField] CCameraManager cameraManager;
    [SerializeField] CCharacterManager characterManager;

	void Start()
	{
		try
		{
			_gamePanel.SetActive(false);
			Debug.Log(PhotonNetwork.room.PlayerCount.ToString());
		}
		catch (System.Exception)
		{
			UnityEngine.SceneManagement.SceneManager.LoadScene("Intro");
			throw;
		}
		
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
		int sec = int.Parse(_timerText.text.Replace("초", ""));
		if (sec > 0)
		{
			_timerText.text = (sec-1).ToString()+"초";
			StartCoroutine("ShowTimer");
		}
		else
		{
			_gamePanel.SetActive(true);
			_timerText.text = PhotonNetwork.playerName+", 행운을 빌어요.";
			_messageText.text = "";
			for (var i=0; i < _anims.Length; i++)
			{
				_anims[i].Play("open");
			}
			StopCoroutine("ShowTimer");
		}
		
	}
}
