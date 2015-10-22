using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerATKAndDamage : ATKAndDamage {

	public float attackB = 80;
	public float attackRange = 100;
	public float attackGun = 100;

	public void AttackA() {


		GameObject enemy = null;
		float distance = attackDistance;
		foreach (GameObject go in SpawnManager._instance.enemyList) 
		{
			float temp = Vector3.Distance(go.transform.position, transform.position);
			if ( temp< distance) 
			{
				enemy = go;
				distance = temp;
			}
		}
		if (enemy != null)
		{
			Vector3 targetPos = enemy.transform.position;
			targetPos.y=transform.position.y;
			transform.LookAt(targetPos);
			enemy.GetComponent<ATKAndDamage>().TakeDamage( normalAttack );
		}
	}

	public void AttackB() {

		GameObject enemy = null;
		float distance = attackDistance;

		//循环检查玩家与敌人的距离，当小于攻击距离时赋值给临时变量enemy，并对它作伤害处理
		foreach (GameObject go in SpawnManager._instance.enemyList) 
		{
			float temp = Vector3.Distance(go.transform.position, transform.position);
			if ( temp< distance) 
			{
				enemy = go;
				distance = temp;
			}
		}
		if (enemy != null)
		{
			Vector3 targetPos = enemy.transform.position;
			targetPos.y=transform.position.y;
			transform.LookAt(targetPos);
			enemy.GetComponent<ATKAndDamage>().TakeDamage( attackB );
		}
	}

	public void AttackRange() {

		List<GameObject> enemyList = new List<GameObject>();
		foreach (GameObject go in SpawnManager._instance.enemyList)
		{
			float temp = Vector3.Distance(go.transform.position, transform.position);
			if (temp < attackDistance) 
			{
				enemyList.Add(go);
				//go.GetComponent<ATKAndDamage>().TakeDamage(attackRange);
			}
		}
		foreach (GameObject go in enemyList)
		{
			go.GetComponent<ATKAndDamage>().TakeDamage(attackRange);
		}

	}

	public void AttackGun() {
	}


}
