using UnityEngine;
using System.Collections;

public class Item_SpeedUp1 : MonoBehaviour {
	public float item_speedup1;	//加算スピード
	GameObject player;			//オブジェクト入れる用

	void Start () {
		player = GameObject.FindWithTag ("Player");		//Playerオブジェクトを探す
	}

	//他のオブジェクトとの当たり判定
	void OnTriggerEnter(Collider other) {
		if(other.tag == "Player"){
			//スピード加算
			//pcって仮の変数にPlayerのコンポーネントを入れる
			Player pc = player.GetComponent<Player>();
			//Playerで管理しているスコア表示用の変数を使って計算
			pc.moveSpeed = pc.moveSpeed + 3f;
			//このGameObjectを［Hierrchy］ビューから削除する
			Destroy(gameObject);
		}
	}
}
