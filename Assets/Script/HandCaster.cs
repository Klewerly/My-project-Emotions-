using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCaster : MonoBehaviour
{
	[SerializeField] private Transform startSpellTransform;
	[SerializeField] private GameObject projectilePrefab;
	[SerializeField] public SpellEffect spellEffect;
	[SerializeField] private ForceMode forceMode = ForceMode.Impulse;
	[SerializeField] private float force = 50;
	[SerializeField] private Animator animator;
	public float projectileSpeed = 20;



	private void Start()
	{

	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(1))
		{

			animator.SetTrigger("Fire");
			StartCoroutine(DelayCoroutine(1.15f));
		}

	}

	public void FireButton()
	{

		var projectile = Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);

		projectile.GetComponent<Rigidbody>().velocity = startSpellTransform.forward * projectileSpeed;
			
			//AddForce(startSpellTransform.forward * force, forceMode);
	}

	private IEnumerator DelayCoroutine(float timeDelay)
	{
		yield return new WaitForSeconds(timeDelay);
		var projectile = Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
		projectile.GetComponent<Rigidbody>().velocity = startSpellTransform.forward * projectileSpeed;
	}
}


