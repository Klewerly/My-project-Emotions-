using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
	public StartWave firstWave;
	public GameObject deadGhoulPanel;
	[SerializeField] GameObject player;
	MouseLook mouseLook;
	CharacterController characterController;
	public Animator deadGhoulAnime;
	public GameObject wavesPanel;
	public Projectile projectile;


	public GameObject[] enemyPrefabs; //������� ������
	private float spawnRangeXl = -32; //����� �� ���
	private float spawnRangeXr = -11;
	private float spawnRangeZ = 70; //����� �� �����

	public float startDelayWave; //����� ������� ��������� ������ �����
	public float spawnIntervalWave; //�������� ����� �������� �������������. ����� �������� �� ������ �� �� �������� �� ������, ���� �������� �� �������.
	public float enemyCount; 
	public float enemyCountWave;
	//����������� � ���������� � ����� ������ �����
	private void Start()
	{

		player = GameObject.Find("Player").gameObject;
		mouseLook = player.GetComponentInChildren<MouseLook>();
		characterController = player.GetComponent<CharacterController>();
		enemyCount = 0;
		enemyCountWave = 1;

	}

	private void Update()
	{


		if (enemyCount == enemyCountWave)
		{
			
			CancelInvoke("RandomEnemySpawn");
			if (Projectile.killCount == enemyCountWave)
			{
				enemyCount = 0;
				Projectile.killCount = 0;
				Cursor.lockState = CursorLockMode.None;
				mouseLook.enabled = false;
				characterController.enabled = false;
				wavesPanel.SetActive(true);
			}
			//�������� �� ����� ������� � ������� �� ���� �����
		}

	}

	public void RandomEnemySpawn()
	{
		int enemyIndex = Random.Range(0, enemyPrefabs.Length);
		Vector3 spawnPos = new Vector3(Random.Range(spawnRangeXl, spawnRangeXr), 0, spawnRangeZ);
		Instantiate(enemyPrefabs[enemyIndex], spawnPos, enemyPrefabs[enemyIndex].transform.rotation);
		enemyCount++;
	}

	public void StartWaveButton() //��������� �� ������ ��� ����������� ���� �����
	{

		enemyCountWave += 20; // �������� ������ � �����
		spawnIntervalWave = 1; // �������� ��������� � ������ ������ (��� ����� ���� ����� � �����?)
		InvokeRepeating("RandomEnemySpawn", startDelayWave, spawnIntervalWave);

		Cursor.lockState = CursorLockMode.Locked;
		mouseLook.enabled = true;
		characterController.enabled = true;
	}
	public void FirstWave()
	{
		deadGhoulPanel.SetActive(false);
		deadGhoulAnime.enabled = true;
		StartWaveButton();
	}

	public void WavesButton()
	{
		wavesPanel.SetActive(false);
		StartWaveButton();

	}
}
