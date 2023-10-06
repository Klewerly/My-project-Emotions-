using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Projectile : MonoBehaviour
{
	public static float killCount;
	public Player player;
	public SpellEffect spellEffect;



	private void Start()
	{
		player.GetComponent<Player>();
		spellEffect = player.currentSpellEffect;

	}


	private void OnCollisionEnter(Collision collision)
	{
		EffectFromSpell();
	}

	public void EffectFromSpell()
	{
		Collider[] colliders = Physics.OverlapSphere(transform.position, 4);
		foreach (Collider go in colliders)
		{

			if (go.gameObject.tag == "Enemy")
			{
				go.gameObject.GetComponent<Animator>().SetTrigger("GhoulDead");
				go.gameObject.GetComponent<BoxCollider>().enabled = false;
				go.gameObject.GetComponent<EnemyAI>().enabled = false;
				go.gameObject.GetComponent<NavMeshAgent>().speed = 0;
				go.gameObject.GetComponent<Rigidbody>().isKinematic = true;
				killCount++;
				Destroy(gameObject);
			}


		}
	}

}
