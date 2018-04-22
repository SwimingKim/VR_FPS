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
    string[] message = { "캐릭터의 이름을 입력해주세요", "입력이 끝나면 확인을 눌러주세요.", "이름이 없으면 랜덤으로 이름이 정해집니다.", "잠시후 게임을 시작합니다." };

    void Awake()
    {
        _nameInputField.gameObject.SetActive(false);
        if (!PhotonNetwork.connected)
        {
            PhotonNetwork.ConnectUsingSettings("v1.0");
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
		string text = _nameInputField.text.Replace(" ", "");
		string name = text.Length == 0 ? "user"+Random.Range(1000, 9999) : _nameInputField.text;
        StopCoroutine("ShowMessage");

        SetActiveInputField(false);

        Debug.Log("접속자 수 =" + PhotonNetwork.room.PlayerCount.ToString());
        PhotonNetwork.playerName = name;

        _text.text = PhotonNetwork.playerName + "님 환영합니다:)";

        StartCoroutine("ChangeScene");
    }

 	public void ValueChangeTextField()
    {
		Debug.Log(_nameInputField.text);
    }

    IEnumerator ShowMessage()
    {
        _text.text = message[index];
        index = index == message.Length - 1 ? 0 : index + 1;

        yield return new WaitForSeconds(1);
        StartCoroutine("ShowMessage");
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(2);

        GetComponent<CGameManager>().StartGame();
    }

}
