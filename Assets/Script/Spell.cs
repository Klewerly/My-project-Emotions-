using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Spell", menuName = "Add Spell")]
public class Spell : ScriptableObject
{
	public string spellName;
	public SpellEffect spellEffect;
	[TextArea(4, 5)]
	public string spellDescription;
	
}
