using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput; //追加

public class player : MonoBehaviour {
	public float moveSpeed = 5f;					//
	public float rotationSpeed = 360f;			//
	CharacterController characterController;			//

	void Start () {
		characterController = GetComponent<CharacterController>();	//コンポーネントをキャッシュしておく
	}
	
	void Update () {
		// 水平と垂直方向への入力( -1.0 ～ 1.0 )
//		Debug.Log( "Horizontal : " + CrossPlatformInputManager.GetAxisRaw("Horizontal") );
//		Debug.Log( "Vertical : " + CrossPlatformInputManager.GetAxisRaw("Vertical") );

		Vector3 direction = new Vector3(	CrossPlatformInputManager.GetAxisRaw("Horizontal"),
											0,
											CrossPlatformInputManager.GetAxisRaw("Vertical")
		);
//		Vector3 direction = new Vector3(	Input.GetAxis("Horizontal"),
//											0,
//											Input.GetAxis("Vertical")
//		);
		
		if(direction.sqrMagnitude > 0.01f){
					Vector3 forward = Vector3.Slerp(	transform.forward,
												direction,
												rotationSpeed * Time.deltaTime / Vector3.Angle(transform.forward, direction)
			);
			transform.LookAt(transform.position + forward);
		}
		characterController.Move(direction * moveSpeed * Time.deltaTime);
	}
}