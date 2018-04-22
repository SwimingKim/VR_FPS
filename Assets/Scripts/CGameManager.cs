using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CGameManager : MonoBehaviour
{
	public GameObject player;
	public Vector3 gamePos;

    public Text _timerText;
    public Text _messageText;
	public GameObject _gamePanel;
	public Animation[] _anims;

    [SerializeField] CCameraManager cameraManager;
	[SerializeField] CPlayerManager playerManager;

	public GameObject _introCanvas;
	public GameObject _gameCanvas;

	void Awake()
	{
		playerManager = GetComponent<CPlayerManager>();
	}

	public void StartGame()
	{
		_introCanvas.SetActive(false);
		_gameCanvas.SetActive(true);

		player.transform.position = gamePos;
		playerManager.initPlayerPrefab();

		_gamePanel.SetActive(false);
		StartCoroutine("ShowTimer");
	}

	void OnCountOut()
	{
		_gamePanel.SetActive(true);
		_timerText.text = playerManager.playerName+", 행운을 빌어요.";
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
			OnCountOut();
			StopCoroutine("ShowTimer");
		}
	}
}
