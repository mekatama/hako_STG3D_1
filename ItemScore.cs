using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemScore : MonoBehaviour{
	public static int score = 0;		//scire初期化
//	private Text text;					//コンポーネントを入れる用

	void Start(){
//		text = GetComponent<Text>();	//textのコンポーネント頂く
		GetComponent<Text>().text = score.ToString("000000");
	}

	void Update(){
		//ここで計算してはダメ
//		score = totalScore + time.timeBonus;

//		score = score + 1;
		GetComponent<Text>().text = score.ToString("000000");
//		text.text = score.ToString();			//text更新
	}
}