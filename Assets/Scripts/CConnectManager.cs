using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CConnectManager : MonoBehaviour
{
	public Text _text;
    public InputField _nameInputField;
	int index = 0;
	string[] message = { "캐릭터의 이름을 입력해주세요", "입력이 끝나면 Tab키를 눌러주세요.", "잠시후 게임을 시작합니다." };

    void Awake()
    {
		_nameInputField.gameObject.SetActive(false);
        if (!PhotonNetwork.connected)
        {
            PhotonNetwork.ConnectUsingSettings("v1.0");
        }
    }

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Tab) && _nameInputField.isActiveAndEnabled)
		{
			OnStartPhotonGame();
		}
	}

	public void setFocusInputField(bool b)
	{
		EventSystem.current.SetSelectedGameObject(b ? _nameInputField.gameObject : null, null);
		// _nameInputField.OnPointerClick(null);
	}

	public void SetActiveInputField(bool b)
	{
		_nameInputField.gameObject.SetActive(b);
	}

    public void OnJoinedLobby()
    {
        _text.text = "서버와의 통신을 시작합니다.";

        PhotonNetwork.JoinOrCreateRoom(
			"Room",
			new RoomOptions()
			{
				MaxPlayers = 4,
				IsOpen = true,
				IsVisible = true
			},
			TypedLobby.Default
		);

    }

	public void OnJoinedRoom()
	{
		Debug.Log("Photon Room Joined");
		SetActiveInputField(true);

		StartCoroutine("ShowMessage");
		setFocusInputField(true);
	}

	public void OnFailedToConnectToPhoton(DisconnectCause cause)
	{
		Debug.Log("[오류] 포톤 클라우드 접속을 실패함 : " + cause.ToString());
	}

	public void OnPhotonCreateRoomFailed(object[] errorMsg)
	{
		Debug.Log("[오류] 방 생성을 실패함 : " + errorMsg[1].ToString());
	}

	public void OnPhotonJoinRoomFailed(object[] errorMsg)
	{
		Debug.Log("[오류] 방 접속을 실패함 : " + errorMsg[1].ToString());
	}

	public void OnStartPhotonGame()
	{
		if (_nameInputField.text.Length == 0) {
			return;
		}

		Debug.Log("시작");
		StopCoroutine("ShowMessage");

		SetActiveInputField(false);

		Debug.Log(PhotonNetwork.room.PlayerCount.ToString());
		PhotonNetwork.playerName = _nameInputField.text;

		_text.text = PhotonNetwork.playerName+"님 환영합니다:)";

		StartCoroutine("ChangeScene");
	}

	IEnumerator ShowMessage()
	{
		_text.text = message[index];
		index = index == message.Length-1 ? 0 : index+1;
			
		yield return new WaitForSeconds(1);
		StartCoroutine("ShowMessage");
	}

	IEnumerator ChangeScene()
	{
		yield return new WaitForSeconds(2);

		GetComponent<CGameManager>().StartGame();
	}

}
