using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemScore : MonoBehaviour{
	public static int score = 0;		//scire初期化

	void Start(){
		//初期値
		GetComponent<Text>().text = score.ToString("000000");
	}

	void Update(){
		//UI表示更新
		GetComponent<Text>().text = score.ToString("000000");
	}
}