using UnityEngine;
using System.Collections;

public class Item_PowerUp1 : MonoBehaviour {
	public int item_powerup1;		//パワーアップ段階
	GameObject player;				//オブジェクト入れる用

	void Start () {
		player = GameObject.FindWithTag ("Player");		//Playerオブジェクトを探す
	}

	//他のオブジェクトとの当たり判定
	void OnTriggerEnter(Collider other) {
		if(other.tag == "Player"){
			//スピード加算
			//puって仮の変数にPlayerのコンポーネントを入れる
			Player pu = player.GetComponent<Player>();
			//Playerで管理しているショットレベルの変数を使って計算
			pu.shotLevel = pu.shotLevel + item_powerup1;
			//このGameObjectを［Hierrchy］ビューから削除する
			Destroy(gameObject);
		}
	}
}
