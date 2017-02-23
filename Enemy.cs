using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public GameObject targe;
	NavMeshAgent agent;

	void Start () {
		agent = GetComponent<NavMeshAgent>();	//コンポーネントをキャッシュしておく
	}
	
	void Update () {
		//targetに向かうようになる
		agent.destination = targe.transform.position;
	}

	//他のオブジェクトとの当たり判定
	void OnTriggerEnter( Collider other) {
		if(other.tag == "Ballet"){
			//このGameObjectを［Hierrchy］ビューから削除する
			Destroy( gameObject);
		}
	}
}
