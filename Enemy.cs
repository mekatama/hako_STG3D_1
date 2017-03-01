using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	NavMeshAgent agent;	//ナビメッシュ用
	Transform player;	//位置情報とか入れるっぽい

	void Start () {
		agent = GetComponent<NavMeshAgent>();							//コンポーネントをキャッシュしておく
		player = GameObject.FindGameObjectWithTag ("Player").transform;	//Playerタグの位置情報ゲット
	}
	
	void Update () {
		//targetに向かうようになる
//		agent.SetDestination(player.position);	//無駄かもしれないけど毎フレーム追いかける
		agent.destination = player.position;	//どっちでも動く
	}

	//他のオブジェクトとの当たり判定
	void OnTriggerEnter( Collider other) {
		if(other.tag == "Ballet"){
			//このGameObjectを［Hierrchy］ビューから削除する
			Destroy( gameObject);
		}
	}
}