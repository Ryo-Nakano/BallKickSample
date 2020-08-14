using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
	[SerializeField] float forwardSpeed;//前方向の移動速度
	[SerializeField] float horizontalSpeed;//横方向の移動速度
    /// <summary>
    /// [SerializeField]はpublicと同じ！
	/// Unityからアタッチできる！
    /// </summary>

    
    void Update()
    {
		Move();//Playerの動き
    }

	void Move()
	{
		this.transform.position += transform.forward * forwardSpeed * Time.deltaTime;//前進

        if (Input.GetKey(KeyCode.RightArrow))//右押した時
        {
            this.transform.position += new Vector3(horizontalSpeed * Time.deltaTime, 0, 0);//右に進む
        }
        else if (Input.GetKey(KeyCode.LeftArrow))//左押した時
        {
            this.transform.position += new Vector3(-horizontalSpeed * Time.deltaTime, 0, 0);//左に進む
        }
	}
    
	void OnCollisionEnter(Collision col)//衝突した時
	{
		if(col.gameObject.tag == "Can")//当たった相手のtagが"Can"だった時
		{
			Debug.Log("hit!!!!!!!!");
			Rigidbody rb = col.gameObject.GetComponent<Rigidbody>();//当たった相手のRigidbodyを取得

			Vector3 myPosition = this.transform.position;//自分の現在地を取得
			Vector3 canPosition = col.gameObject.transform.position;//Canの現在地を取得
			Vector3 direction = (canPosition - myPosition).normalized;//自分→相手の方向ベクトルを算出(その後単位ベクトル化)
			direction += new Vector3(0, Random.Range(0.4f, 0.7f), 0);//ちょっと上むきにする
			float randomPower = Random.Range(15.0f, 25.0f);//Canを飛ばす力をランダムに
            
			rb.velocity = direction.normalized * randomPower;//directionの方向に、randomPowerの力で飛ばす！
		}
	}
}
