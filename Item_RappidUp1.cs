using UnityEngine;
using System.Collections;

public class Item_RappidUp1 : MonoBehaviour {
	public float item_rappidup1;	//連射スピード
	GameObject player;				//オブジェクト入れる用

	void Start () {
		player = GameObject.FindWithTag ("Player");		//Playerオブジェクトを探す
	}

	//他のオブジェクトとの当たり判定
	void OnTriggerEnter(Collider other) {
		if(other.tag == "Player"){
			//スピード加算
			//pcって仮の変数にPlayerのコンポーネントを入れる
			Player pc = player.GetComponent<Player>();
			//Playerで管理しているれんし間隔の変数を使って計算
			pc.timeOut = pc.timeOut - item_rappidup1;
			//このGameObjectを［Hierrchy］ビューから削除する
			Destroy(gameObject);
		}
	}
}
