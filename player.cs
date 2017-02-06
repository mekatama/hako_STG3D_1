using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput; //追加

public class player : MonoBehaviour {
	public float moveSpeed = 5f;			//移動速度
	public float rotationSpeed = 2f;		//旋回速度
	CharacterController characterController;//コンポーネントを行ける用

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
	}
}