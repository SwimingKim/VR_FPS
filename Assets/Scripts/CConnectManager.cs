using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CConnectManager : MonoBehaviour
{

    public InputField _nameInputField;
    public static bool IsJoinRoom = false;

    void Awake()
    {
        if (!PhotonNetwork.connected)
        {
            PhotonNetwork.ConnectUsingSettings("v1.0");
        }
    }

    // void Update()
    // {

    // }

    public void OnJoinedLobby()
    {
        Debug.Log("Photon Cloud Lobby Connectes..");

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
		IsJoinRoom = true;
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

	public void OnCreatePhotonObject()
	{
		Debug.Log("Photon init");

		Debug.Log(PhotonNetwork.room.PlayerCount.ToString());
		PhotonNetwork.playerName = "skim";

		
	}

	// public void OnCreatePhotonObjectBtnClick(string prefabName)
	// {

	// }
	



}
