using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Diaglogue", menuName = "Add Diaglogue/Diaglogue")]
public class Diaglogue : ScriptableObject
{
	public List<DiaglogueStep> Step;

}
