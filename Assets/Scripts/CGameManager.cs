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

	public Vector3 _pos;
    CCharacterAnimation _anim;

    [SerializeField] CCameraManager cameraManager;

	void Start()
	{
		if (!PhotonNetwork.connected)
		{
			UnityEngine.SceneManagement.SceneManager.LoadScene("Intro");
			return;
		}

		initPlayerPrefab();

		_gamePanel.SetActive(false);
		StartCoroutine("ShowTimer");
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            cameraManager.IsRun = !cameraManager.IsRun;
            _anim.PlayAnimation(cameraManager.IsRun ? CCharacterAnimation.ANIM_TYPE.WALK : CCharacterAnimation.ANIM_TYPE.IDLE);
        }
    }

	void initPlayerPrefab()
	{
		GameObject localPlyer = PhotonNetwork.Instantiate("Sci-fi Soldier", Vector3.zero, Quaternion.identity, 0);
		localPlyer.transform.SetParent(Camera.main.transform);
		localPlyer.transform.localPosition = _pos;

		_anim = localPlyer.GetComponent<CCharacterAnimation>();
	}

	void StartGame()
	{
		_gamePanel.SetActive(true);
		_timerText.text = PhotonNetwork.playerName+", 행운을 빌어요.";
		_messageText.text = "";
		for (var i=0; i < _anims.Length; i++)
		{
			_anims[i].Play("open");
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
			StartGame();
			StopCoroutine("ShowTimer");
		}
		
	}
}
