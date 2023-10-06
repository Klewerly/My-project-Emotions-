using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour
{
    NavMeshAgent enemy;
    Animator animator;
    [SerializeField] private GameObject target;
    


    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        target = GameObject.Find("Player").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        enemy.transform.LookAt(target.transform.position); //������� �� ������
        enemy.SetDestination((transform.position - target.transform.position).normalized * 2 + target.transform.position); // ����� � ���� � ������ ��������� ���������, ���� �����
        float dist = Vector3.Distance(enemy.transform.position, target.transform.position); //������� ���������

        if (dist <= 2)
        {
            animator.SetTrigger("GhoulPunch"); //����� �������� ����� �� ��������, ������� ����� ��������� ������ ��� ������� ��� ������������� � ���� ������
        }
      

    }


    
}
