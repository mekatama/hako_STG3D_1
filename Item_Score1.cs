using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Item_Score1 : MonoBehaviour {
	public int item_score1;		//アイテムの点数
	GameObject gameController;	//スコア表示を管理しているオブジェクト入れる用

	void Start () {
		gameController = GameObject.FindWithTag ("GameController");		//GameControllerオブジェクトを探す
	}

	//他のオブジェクトとの当たり判定
	void OnTriggerEnter(Collider other) {
		if(other.tag == "Player"){
			//スコア加算
			//gcって仮の変数にGameControllerのコンポーネントを入れる
			GameController gc = gameController.GetComponent<GameController>();
			//GameControllerで管理しているスコア表示用の変数を使って計算
			gc.total_Score = gc.total_Score + item_score1;
			//このGameObjectを［Hierrchy］ビューから削除する
			Destroy(gameObject);
		}
	}
}
