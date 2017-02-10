using UnityEngine;
using System.Collections;

public class title_controller : MonoBehaviour {
	//startボタン用の関数
	public void StartButtonOn(){
		Application.LoadLevel("stage1");
	}
}
