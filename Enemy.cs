using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {
	NavMeshAgent agent;			//ナビメッシュ用
	Transform player;			//位置情報とか入れるっぽい
	public int enemyHp;			//EnemyのHP
	public GameObject item;		//Enemyから出現させるアイテム
	public int enemy_score1;	//enemyの点数
	GameObject gameController;	//スコア表示を管理しているオブジェクト入れる用
	public GameObject renbaku;	//Enemy破壊時の爆発
	public bool bakuhatu;		//連爆の有無
	public int renbakuLevel;	//連爆サイス受渡し用


	void Start () {
		agent = GetComponent<NavMeshAgent>();							//コンポーネントをキャッシュしておく
		player = GameObject.FindGameObjectWithTag ("Player").transform;	//Playerタグの位置情報ゲット
		gameController = GameObject.FindWithTag ("GameController");		//GameControllerオブジェクトを探す
	}
	
	void Update () {
		//targetに向かうようになる
//		agent.SetDestination(player.position);	//無駄かもしれないけど毎フレーム追いかける
		agent.destination = player.position;	//↑どっちでも動く
	}

	//他のオブジェクトとの当たり判定
	void OnTriggerEnter( Collider other) {
		if(other.tag == "Bullet"){
			Bullet s = other.GetComponent<Bullet>();	//接触したBulletのコンポーネントを取得
			enemyHp = enemyHp - s.attackPower;			//Bulletスクリプトの攻撃力をHPから引く
			Debug.Log(enemyHp);
			if(enemyHp <= 0){
				//スコア加算
				//gcって仮の変数にGameControllerのコンポーネントを入れる
				GameController gc = gameController.GetComponent<GameController>();
				//GameControllerで管理しているスコア表示用の変数を使って計算
				gc.total_Score = gc.total_Score + enemy_score1;
				//
				renbakuLevel = gc.renbaku_Level;
				//このGameObjectを［Hierrchy］ビューから削除する
				Destroy(gameObject);
				if(bakuhatu == true){
					//敵破壊時に連爆
					Instantiate (renbaku, transform.position, transform.rotation);
				}
				//四分の一の確率で回復アイテムを落とす
				if (Random.Range (0, 4) == 0) {
					Instantiate (item, transform.position, transform.rotation);
				}
			}
		}
		if(other.tag == "Bom"){
			Bom1 b = other.GetComponent<Bom1>();	//接触したBomのコンポーネントを取得
			enemyHp = enemyHp - b.attackPower;		//Bom1スクリプトの攻撃力をHPから引く
			Debug.Log("enemyHp" + enemyHp);
			if(enemyHp <= 0){
				//スコア加算
				//gcって仮の変数にGameControllerのコンポーネントを入れる
				GameController gc = gameController.GetComponent<GameController>();
				//GameControllerで管理しているスコア表示用の変数を使って計算
				gc.total_Score = gc.total_Score + enemy_score1;
				//このGameObjectを［Hierrchy］ビューから削除する
				Destroy(gameObject);
				if(bakuhatu == true){
					//敵破壊時に連爆
					Instantiate (renbaku, transform.position, transform.rotation);
				}
				//三分の一の確率で回復アイテムを落とす
				if (Random.Range (0, 3) == 0) {
					Instantiate (item, transform.position, transform.rotation);
				}
			}
		}
	}
}