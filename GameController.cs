using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public Text scoreLabel;
	public GameObject player;
	public int total_Score = 0;	//表示される合計スコア

	void Start () {
	}
	
	void Update () {
		scoreLabel.text = total_Score.ToString("000000");
	}
}
