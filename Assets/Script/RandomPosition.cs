using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class RandomPosition : MonoBehaviour
{
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(RepositionWithDelay());
    }

    IEnumerator RepositionWithDelay()
    {
        while (true)
        {
            SetRandomPosition();
            yield return new WaitForSeconds(3);
        }
    }

    void SetRandomPosition()
    {
        // 시도 횟수 제한을 두어 유효한 위치를 찾도록 함
        int maxAttempts = 10;
        int attempts = 0;

        do
        {
            // NavMesh의 경계 내에서 랜덤 위치 생성
            Vector3 randomDirection = Random.insideUnitSphere * 30f;
            randomDirection += transform.position;

            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomDirection, out hit, 30f, NavMesh.AllAreas))
            {
                // 유효한 위치를 찾았을 경우 이동 명령을 내림
                agent.SetDestination(hit.position);
                break;
            }

            attempts++;
        } while (attempts < maxAttempts);

    }

    // Update is called once per frame
    void Update()
    {
    }
}