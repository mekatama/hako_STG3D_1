using UnityEngine;
using System.Collections;

public class EnemyGenerator : MonoBehaviour {
	public GameObject enemyObject;			//Enemyプレハブ
	public float timeOut;
	private float timeElapsed = 2.0f;
	
	void Update () {
		timeElapsed += Time.deltaTime;
        if(timeElapsed >= timeOut) {
			//敵を生成する
			Instantiate( enemyObject, transform.position, transform.rotation);
			timeElapsed = 0.0f;
 		}
	}
}
