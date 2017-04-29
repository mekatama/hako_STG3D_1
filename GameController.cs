using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public Text scoreLabel;
	public Text bomLabel;
	public GameObject player;
	public int total_Score = 0;	//表示される合計スコア
	public int bom_Count = 3;	//表示されるボムの数

	void Start () {
	}
	
	void Update () {
		scoreLabel.text = total_Score.ToString("000000");
		bomLabel.text = bom_Count.ToString("00");
	}
}
