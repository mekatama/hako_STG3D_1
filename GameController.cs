using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public Text scoreLabel;
	public Text bomLabel;
	public Text renbakuLabel;
	public GameObject player;
	public int total_Score = 0;		//表示される合計スコア
	public int bom_Count = 3;		//表示されるボムの数
	public int renbaku_Level;	//表示される連爆レベル

	void Start () {
	}
	
	void Update () {
		scoreLabel.text = total_Score.ToString("000000");
		bomLabel.text = bom_Count.ToString("00");
		renbakuLabel.text = renbaku_Level.ToString("R_Lv:" + "00");
	}
}
