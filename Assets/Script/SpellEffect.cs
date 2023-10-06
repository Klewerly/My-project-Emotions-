using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class SpellEffect : MonoBehaviour
{
	public void EffectFromSpell(Collision collision)
	{
	}
}
[Serializable]
public class SpellEffect1 : SpellEffect// -10-
{
	public new void EffectFromSpell(Collision collision)
	{
		
	}
}
[Serializable]
public class SpellEffect2 : SpellEffect // -10 - 0
{
	public new void EffectFromSpell(Collision collision)
	{
	}
}
[Serializable]
public class SpellEffect3 : SpellEffect // 0 - 10
{
	public new void EffectFromSpell(Collision collision)
	{
	}
}
[Serializable]
public class SpellEffect4 : SpellEffect // 10+
{
	public new void EffectFromSpell(Collision collision)
	{
		Collider[] colliders = Physics.OverlapSphere(transform.position, 3);
		foreach (Collider go in colliders)
		{
			if (go.gameObject.tag == "Enemy")
			{
				go.gameObject.transform.Translate(collision.transform.position);

			}

		}
	}
}
