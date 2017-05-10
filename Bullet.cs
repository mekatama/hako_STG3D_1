using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public float bulletMoveSpeed = 10.0f;	//1秒間に弾が進む距離
	public int attackPower = 1;				//弾の攻撃力

	void Start(){
		//このGameObjectを指定時間後［Hierrchy］ビューから削除する
//		Destroy(gameObject, 0.05f);
	}

	void Update() {
		//1秒間の移動量
		Vector3 vecAddPos = (Vector3.forward * bulletMoveSpeed);
		//移動量、回転量には Time.deltaTime をかけて実行環境(フレーム数の差)による違いが出ないようにします
		transform.position += ((transform.rotation * vecAddPos) * Time.deltaTime);
	}

	//他のオブジェクトとの当たり判定
	void OnTriggerEnter( Collider other) {
		if(other.tag == "Wall"){
			//このGameObjectを［Hierrchy］ビューから削除する
			Destroy( gameObject);
		}
		if(other.tag == "Enemy"){
			//このGameObjectを［Hierrchy］ビューから削除する
			Destroy( gameObject);
		}
	}
}
