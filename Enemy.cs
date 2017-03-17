using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	NavMeshAgent agent;		//ナビメッシュ用
	Transform player;		//位置情報とか入れるっぽい
	public int enemyHp;		//EnemyのHP

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
			Bullet s = other.GetComponent<Bullet>();	//接触したBulletのコンポーネントを取得
			enemyHp = enemyHp - s.attackPower;			//Bulletスクリプトの攻撃力をHPから引く
			Debug.Log(enemyHp);
			if(enemyHp <= 0){
				//このGameObjectを［Hierrchy］ビューから削除する
				Destroy(gameObject);
			}
		}
	}
}