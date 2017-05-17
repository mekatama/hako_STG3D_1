using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Item_RenbakuUp1 : MonoBehaviour {
	public int item_renbaku1;	//ボム回復数
	GameObject gameController;	//ボム残弾表示を管理しているオブジェクト入れる用

	void Start () {
		gameController = GameObject.FindWithTag ("GameController");		//GameControllerオブジェクトを探す
	}

	//他のオブジェクトとの当たり判定
	void OnTriggerEnter(Collider other) {
		if(other.tag == "Player"){
			//スコア加算
			//gcって仮の変数にGameControllerのコンポーネントを入れる
			GameController gc = gameController.GetComponent<GameController>();
			//GameControllerで管理しているボム残弾表示用の変数を使って計算
			gc.renbaku_Level = gc.renbaku_Level + item_renbaku1;
			//このGameObjectを［Hierrchy］ビューから削除する
			Destroy(gameObject);
		}
	}
}
