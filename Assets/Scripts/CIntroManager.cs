using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CIntroManager : MonoBehaviour {

	public Text _text;
	int index = 0;
	string[] message = { "Welcome to VR World:)", "캐릭터의 이름을 입력해주세요", "입력이 끝나면 Enter키를 눌러주세요." };

	// void Start()
	// {
	// 	StartCoroutine("ShowMessage");
	// }

	// IEnumerator ShowMessage()
	// {
	// 	_text.text = message[index];
	// 	index = index == message.Length-1 ? 0 : index+1;
	// 	yield return new WaitForSeconds(1);
	// 	StartCoroutine("ShowMessage");
	// }
	
}
