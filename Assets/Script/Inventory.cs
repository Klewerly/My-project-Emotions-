using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	[SerializeField] public List<Emotion> emotionInventory = new List<Emotion>();
	public GameObject emotionGivePanel;
	public TMPro.TextMeshProUGUI emotionGiveTitle;
	public TMPro.TextMeshProUGUI emotionGiveText;
	public MouseLook mouseLook;
	public CharacterController characterController;

	private void Awake()
	{
		mouseLook = mouseLook.gameObject.GetComponent<MouseLook>();
		characterController = characterController.gameObject.GetComponent<CharacterController>();

	}

	public void addEmotionInventory(Emotion emotion)
	{
		Debug.Log(emotion);
		emotionInventory.Add(emotion);
		emotionGivePanel.SetActive(true);
		emotionGiveTitle.text = emotion.emotionName;
		emotionGiveText.text = emotion.description;
		StartCoroutine(DelayCoroutine(5));


	}
	public void EmotionGivePanelOnOff()
	{
		emotionGivePanel.SetActive(true);
		Cursor.lockState = CursorLockMode.None;
		mouseLook.enabled = false;
		characterController.enabled = false;
	}


	public IEnumerator DelayCoroutine(float timeDelay)
	{
		
		yield return new WaitForSeconds(timeDelay);
		emotionGivePanel.SetActive(false);
	}
}




