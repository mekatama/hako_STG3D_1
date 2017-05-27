using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Renbaku_Size : MonoBehaviour {
	private float renbaku_scale;	//連爆用のスケール管理用
	public float renbaku_tyousei;	//連爆スコア調整用
	GameObject enemy;				//オブジェクト入れる用

	void Start () {
		enemy = GameObject.FindWithTag ("Enemy");	//Playerオブジェクトを探す
		Vector3 s = transform.localScale;			//スケール設定用

		//enって仮の変数にEnemyのコンポーネントを入れる
		Enemy en = enemy.GetComponent<Enemy>();
		//Enemyで管理しているボムレベル変数を使って計算
		renbaku_scale = en.renbakuLevel * renbaku_tyousei;
		//連爆スケール変化
		s.x = renbaku_scale;				//スケール設定
		s.y = renbaku_scale;
		s.z = renbaku_scale;
		transform.localScale = s;			//反映する

		Debug.Log("renbak_Scale=" + renbaku_scale);
	}
}
