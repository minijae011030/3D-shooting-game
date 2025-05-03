using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerFire : MonoBehaviour
{
    public GameObject bulletFactory;
    public Transform firePosition;
    public GameObject spark;
    public AudioClip fireSfx;
    public AudioSource source = null;

    Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !GameManager.isExitScreenActive)
        {
            ShotBigBullet();
        }

    }

    private void ShotBigBullet()
    {
        Instantiate(bulletFactory, new Vector3(firePosition.position.x, firePosition.position.y, firePosition.position.z), transform.rotation);
        GameObject data = Instantiate(spark, firePosition.position, firePosition.rotation);
        Destroy(data, 0.1f);

        source.PlayOneShot(fireSfx);

    }


}
