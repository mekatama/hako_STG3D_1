using UnityEngine;
using System.Collections;

public class EnemyGeneratorMaster : MonoBehaviour {
	public GameObject enemyObject;			//Enemyプレハブ
	public GameObject enemyPop1;			//出現位置用の空のオブジェクト
	public GameObject enemyPop2;			//出現位置用の空のオブジェクト
	public GameObject enemyPop3;			//出現位置用の空のオブジェクト
	public float timeOut;
	private float timeElapsed = 2.0f;

	void Update () {
		timeElapsed += Time.deltaTime;
        if(timeElapsed > timeOut) {
			if(Random.Range(0,2) == 0){
				//敵を生成
				Instantiate( enemyObject, enemyPop1.transform.position, enemyPop1.transform.rotation);
			}
			if(Random.Range(0,2) == 0){
				//敵を生成
				Instantiate( enemyObject, enemyPop2.transform.position, enemyPop2.transform.rotation);
			}
			if(Random.Range(0,2) == 0){
				//敵を生成
				Instantiate( enemyObject, enemyPop3.transform.position, enemyPop3.transform.rotation);
			}
//			Debug.Log("pop!");
			timeElapsed = 0.0f;
 		}
	}
}
