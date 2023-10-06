using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Quest", menuName = "Add Quest")]
public class Quest : ScriptableObject
{
	public string questName;
	[TextArea(4, 5)]
	public string description;


}
