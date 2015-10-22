using UnityEngine;
using System.Collections;

public class ATKAndDamage : MonoBehaviour {

	public float hp = 100;
	public float normalAttack = 50;
	public float attackDistance = 1;

	protected Animator animator;

	protected void Awake() {
		animator = this.GetComponent<Animator>();
	}

	//受伤害
	public virtual void TakeDamage(float damage) {

		if(hp > 0 )
		{
			hp -= damage;
		}

		if(hp > 0)
		{
			animator.SetTrigger("Damage");
			if(this.tag == Tags.soulBoss)
			{
				GameObject.Instantiate(Resources.Load("HitBoss"), transform.position + Vector3.up, transform.rotation);
			}
		}
		else
		{
			animator.SetBool("Dead",true);

		}
	}
}
