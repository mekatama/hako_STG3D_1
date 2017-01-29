using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput; //追加

public class player : MonoBehaviour {
	CharacterController controller;			//
	Vector3 moveDirection = Vector3.zero;	//
	public float gravity;					//
	public float speed;					//
	public float speedJump;					//
	public float rotateSpeed;				//
	//

	void Start () {
		controller = GetComponent<CharacterController>();	//コンポーネントをキャッシュしておく
	}
	
	void Update () {
		// 水平と垂直方向への入力( -1.0 ～ 1.0 )
//		Debug.Log( "Horizontal : " + CrossPlatformInputManager.GetAxisRaw("Horizontal") );
//		Debug.Log( "Vertical : " + CrossPlatformInputManager.GetAxisRaw("Vertical") );
/*
		if(controller.isGrounded){
			if(CrossPlatformInputManager.GetAxisRaw("Vertical") > 0.0f){
				moveDirection.z = CrossPlatformInputManager.GetAxisRaw("Vertical") * speedZ;
			}else{
				moveDirection.z = 0;
			}

			transform.Rotate(0, CrossPlatformInputManager.GetAxisRaw("Horizontal") * 3, 0);
		}
*/
if (controller.isGrounded) { 
	//Vector3 forward = Camera.mainCamera.transform.TransformDirection(Vector3.forward);
 //Vector3 right = Camera.mainCamera.transform.TransformDirection(Vector3.right);
  moveDirection = CrossPlatformInputManager.GetAxisRaw("Horizontal")*right + CrossPlatformInputManager.GetAxisRaw("Vertical")*forward; moveDirection *= speed;
}
		moveDirection.y -= gravity * Time.deltaTime;
		
		Vector3 grobalDirection = transform.TransformDirection(moveDirection);
		controller.Move(grobalDirection * Time.deltaTime);

		if(controller.isGrounded) moveDirection.y = 0;

		//
		var moveDirectionYzero = -moveDirection;
		moveDirectionYzero.y=0;

		if (moveDirectionYzero.sqrMagnitude > 0.001){
			//２点の角度をなだらかに繋げながら回転していく処理（stepがその変化するスピード）
			float step = rotateSpeed*Time.deltaTime;
			Vector3 newDir = Vector3.RotateTowards(transform.forward,moveDirectionYzero,step,0f);

			transform.rotation = Quaternion.LookRotation(newDir);
		}
	}
}