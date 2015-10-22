using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

	private Transform player;
	public float speed = 2;

	void Start () {
		player = GameObject.FindGameObjectWithTag(Tags.player).transform;
	}

	void Update () {
		//摄像机的position和rotation都需要改变
		
		Vector3 targetPos = player.position + new Vector3(0, 2.28f, -3.2f);
		transform.position = Vector3.Lerp(transform.position, targetPos, speed * Time.deltaTime);
		//player.position-transform.position,摄像机看向玩家的向量
		Quaternion targetRotation = Quaternion.LookRotation( player.position-transform.position );
		transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);

	}
}
