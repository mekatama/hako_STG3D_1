using UnityEngine;
using System.Collections;

public class Bom1 : MonoBehaviour {
	public float bulletMoveSpeed = 0.5f;	//1秒間にボムが進む距離
	public int attackPower = 10;			//ボムの攻撃力

	void Start(){
		//このGameObjectを指定時間後［Hierrchy］ビューから削除する
		Destroy(gameObject, 3);
	}

	void Update() {
		//1秒間の移動量
		Vector3 vecAddPos = (Vector3.forward * bulletMoveSpeed);
		//移動量、回転量には Time.deltaTime をかけて実行環境(フレーム数の差)による違いが出ないようにします
		transform.position += ((transform.rotation * vecAddPos) * Time.deltaTime);
	}
}
