using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Exit : MonoBehaviour
{
	public int exitButtonClick; // 0 ��� 1 ��� ������ ��� �� ������?
    public Inventory playerInventory; // ��������� � ���������� ������
    Quest playerCurrentQuest;
	bool exitWindowOpen;
	public Player player;

    //����������
    [SerializeField] public List<Emotion> emotionCombinatorInv = new List<Emotion>(); // ��������� ������
	[SerializeField] public TMPro.TextMeshProUGUI[] textButtonInventory; 
	[SerializeField] public TMPro.TextMeshProUGUI[] textButtonCombinator;
	[SerializeField] public TMPro.TextMeshProUGUI questExitText;
	bool combinatorIsFull;
	private int buttonRemoveCombinator;
	private int buttonFinishCombination; //0 �� ������, 1 ������
	public int emotionPoints;
	public int spellChoise;



	private void Awake()
	{
		player = player.GetComponent<Player>();
	}

	private void Update()
	{
		if (player.exitWindowActive == true)
		{
			InventoryUpdate();
			playerCurrentQuest = player.currentQuest;
			questExitText.text = playerCurrentQuest.description;
		}
	}


	public void ExitWindow()
    {
		playerCurrentQuest = player.currentQuest;

		//������



	}
	public void InventoryUpdate()
	{

		foreach (TMPro.TextMeshProUGUI emot in textButtonInventory)
		{
			emot.text = null;
		}

		foreach (TMPro.TextMeshProUGUI combo in textButtonCombinator)
		{
			combo.text = null;
		}

		for (int i = 0; i < playerInventory.emotionInventory.Count; i++)
		{
			
			textButtonInventory[i].text = playerInventory.emotionInventory[i].emotionName;
		}

		for (int c = 0; c < emotionCombinatorInv.Count; c++)
		{

			textButtonCombinator[c].text = emotionCombinatorInv[c].emotionName;
		}
	} //��������� ��������� � ����������.
	public void AddEmotionCombinator(int inventorySlot) //��������� �� ������
	{

		CheckFullnessCombintor();

		if (combinatorIsFull == false)
		{
			for (int i = 0; i < playerInventory.emotionInventory.Count; i++)
			{

				if (inventorySlot == i)
				{
					emotionCombinatorInv.Add(playerInventory.emotionInventory[inventorySlot]);
					emotionPoints += playerInventory.emotionInventory[inventorySlot].emotionPoints;

					for (int c = 0; c < emotionCombinatorInv.Count; c++)
					{
						textButtonCombinator[c].text = emotionCombinatorInv[c].emotionName;
					}

					InventoryUpdate();
					playerInventory.emotionInventory.Remove(playerInventory.emotionInventory[inventorySlot]);
					InventoryUpdate();
				}

			}
		}
	} //�������� 3 �����
	public void RemoveEmotionCombinator(int inventorySlot)
	{
		for (int i = 0; i < emotionCombinatorInv.Count; i++)
		{
			if (i == inventorySlot)
			{
				playerInventory.emotionInventory.Add(emotionCombinatorInv[inventorySlot]);
				emotionPoints -= emotionCombinatorInv[inventorySlot].emotionPoints;
				emotionCombinatorInv.Remove(emotionCombinatorInv[inventorySlot]);
				
			}
		}
		InventoryUpdate();
	}

	public void FinishSpellInCombinator()
	{

		CheckFullnessCombintor();
		if (combinatorIsFull == true)
		{

			if (emotionPoints < -10) 
			{
				spellChoise = 1;
			}
			if (emotionPoints > -10 && emotionPoints  < 0)
			{
				spellChoise = 2;
			}
			if (emotionPoints > 0 && emotionPoints < 10)
			{
				spellChoise = 3;
			}
			if (emotionPoints > 10)
			{
				spellChoise = 4;
			}

		}
	}
	public void CheckFullnessCombintor()
	{
		for (int c = 0; c < emotionCombinatorInv.Count; c++)
		{
			if (c == 2)
			{
				combinatorIsFull = true;
			}
			else
			{
				combinatorIsFull = false;
			}

		}
	}

}


