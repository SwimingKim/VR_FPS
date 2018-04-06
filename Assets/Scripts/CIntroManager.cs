using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CIntroManager : MonoBehaviour {

	public Text _text;
	int index = 0;
	string[] message = { "Welcome to VR World:)", "Please Submit your charcter name." };

	void Start()
	{
		StartCoroutine("ShowMessage");
	}

	IEnumerator ShowMessage()
	{
		_text.text = message[index];
		index = index == message.Length-1 ? 0 : index+1;
		yield return new WaitForSeconds(1);
		StartCoroutine("ShowMessage");
	}
	
}
