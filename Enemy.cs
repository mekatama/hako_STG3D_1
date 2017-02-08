using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public GameObject targe;
	NavMeshAgent agent;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();	//コンポーネントをキャッシュしておく
	}
	
	// Update is called once per frame
	void Update () {
		//targetに向かうようになる
		agent.destination = targe.transform.position;
	}
}
