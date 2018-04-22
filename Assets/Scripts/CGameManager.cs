﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CGameManager : MonoBehaviour
{
	public GameObject _gamePanel;
	public Animation[] _anims;
	
	public GameObject _introControl;
	public GameObject _gameControl;
	CUIManager uiManager;
	CCharacterManager characterManager;

	void Awake()
	{
		_introControl.SetActive(true);
		_gameControl.SetActive(false);
	}

	public void StartGame()
	{
		_introControl.SetActive(false);

        GameObject localPlyer = PhotonNetwork.Instantiate("PlayerControl", Vector3.zero, Quaternion.identity, 0);
		uiManager = localPlyer.GetComponent<CUIManager>();
		characterManager = localPlyer.GetComponent<CCharacterManager>();

		_gamePanel.SetActive(false);
		StartCoroutine("ShowTimer");
	}

	void OnCountOut()
	{
		_gamePanel.SetActive(true);
		uiManager._timerText.text = characterManager.playerName+", 행운을 빌어요.";
		uiManager._messageText.text = "";
		for (var i=0; i < _anims.Length; i++)
		{
			_anims[i].Play("open");
		}
	}

	IEnumerator ShowTimer()
	{
		yield return new WaitForSeconds(1);
		int sec = int.Parse(uiManager._timerText.text.Replace("초", ""));
		if (sec > 0)
		{
			uiManager._timerText.text = (sec-1).ToString()+"초";
			StartCoroutine("ShowTimer");
		}
		else
		{
			OnCountOut();
			StopCoroutine("ShowTimer");
		}
	}
}
