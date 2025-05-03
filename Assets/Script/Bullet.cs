using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Bullet : MonoBehaviour
{
    public float bigBulletSpeed;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * bigBulletSpeed);
    }

    private void OnBecameInvisible()
    {
        // 총알이 보이지 않을 때 비활성화
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
