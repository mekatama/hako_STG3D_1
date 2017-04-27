using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput; //追加
using UnityEngine.UI;

public class Player : MonoBehaviour {
	public float moveSpeed = 5f;			//移動速度
	public float rotationSpeed = 2f;		//旋回速度
	CharacterController characterController;//コンポーネントを入れる用
	bool shoorFlag;							//ショットフラグ

	public int shotLevel;							//ショットレベル
	public GameObject bulletObject = null;			//弾プレハブ
	public Transform bulletStartPosition = null;	//弾の発射位置を取得するボーン
	public Transform bulletStartPosition2a = null;	//弾の発射位置を取得するボーン
	public Transform bulletStartPosition2b = null;	//弾の発射位置を取得するボーン

	public float timeOut = 0.4f;		//弾の連射間隔
	private float timeElapsed = 0.0f;	//弾の連射間隔カウント用

	public GameObject bomObject = null;			//ボムのプレハブ

	void Start () {
		characterController = GetComponent<CharacterController>();	//コンポーネントをキャッシュしておく	
	}
	
	void Update () {
		// 水平と垂直方向への入力( -1.0 ～ 1.0 )
//		Debug.Log( "Horizontal : " + CrossPlatformInputManager.GetAxisRaw("Horizontal") );
//		Debug.Log( "Vertical : " + CrossPlatformInputManager.GetAxisRaw("Vertical") );

		//移動量からキー入力方向を取得
		Vector3 direction = new Vector3(	CrossPlatformInputManager.GetAxisRaw("Horizontal"),
											0,
											CrossPlatformInputManager.GetAxisRaw("Vertical")
		);
		
		//移動量があったら
		if(direction.sqrMagnitude > 0.01f){
			//現在の向きとキー入力方向から、新しい向きを求める
			Vector3 forward = Vector3.Slerp(	transform.forward,
												direction,
												rotationSpeed * Time.deltaTime / Vector3.Angle(transform.forward, direction)
			);
			//実際に向きを変更
			transform.LookAt(transform.position + forward);	
		}
		//実際に移動
		characterController.Move(direction * moveSpeed * Time.deltaTime);

		timeElapsed += Time.deltaTime;
        if(timeElapsed >= timeOut) {
			//パワーアップで発射する弾丸数を増やす
			if(shotLevel == 0){
				//弾を生成する位置を指定する
				Vector3 vecBulletPos	= bulletStartPosition.position;
				//弾を生成する
				Instantiate( bulletObject, vecBulletPos, transform.rotation);
			}else if(shotLevel == 1){
				//弾を生成する位置を指定する(2方向)
				Vector3 vecBulletPos2a	= bulletStartPosition2a.position;
				Vector3 vecBulletPos2b	= bulletStartPosition2b.position;
				//弾を生成する(2方向)
				Instantiate( bulletObject, vecBulletPos2a, transform.rotation);
				Instantiate( bulletObject, vecBulletPos2b, transform.rotation);
			}
			timeElapsed = 0.0f;
		}

		//ボタン処理(Button Handletで設定したNameを使用)
		if(CrossPlatformInputManager.GetButtonDown("Shot")){	//パッドのボタン入力判定
			//入力処理
			Debug.Log("BOM!!");
			//ボムは、弾を生成する位置と同じ
			Vector3 vecBomPos	= bulletStartPosition.position;
			//ボムを生成する
			Instantiate( bomObject, vecBomPos, transform.rotation);
			shoorFlag = true;
		}else{
			//入力しない処理
			shoorFlag = false;
		}
	}

	//他のオブジェクトとの当たり判定
	void OnTriggerEnter(Collider other){
		if(other.tag == "Enemy"){
//			Invoke("NextScene",1.0f);	//指定時間後に実行
		}
	}

	//シーン遷移
	void NextScene(){
		Application.LoadLevel("title");	//シーンが呼ばれる
	}
}