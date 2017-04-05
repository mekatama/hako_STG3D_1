using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Item_Score1 : MonoBehaviour {
//【使用方法】Hierarchyに配置してあるアイテムをduplicateして使用すること

	public int item_score1;					//アイテムの点数
	public GameController gameController;	//スコア表示を管理しているオブジェクト

	//他のオブジェクトとの当たり判定
	void OnTriggerEnter(Collider other) {
		if(other.tag == "Player"){
//			item_score1 = 11;		//
			gameController.total_Score = gameController.total_Score + item_score1;
			//このGameObjectを［Hierrchy］ビューから削除する
			Destroy(gameObject);
		}
	}
}
