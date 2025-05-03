using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Hit : MonoBehaviour
{
    public AudioClip hitAudio;
    public AudioSource source = null;
    public float respawnDelay = 5f;
    private new Renderer renderer;
    public GameObject killMent;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        renderer = GetComponent<Renderer>();
        killMent.SetActive(false);
        if (renderer == null)
        {
            renderer = gameObject.AddComponent<MeshRenderer>();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Bullet")
        {
            DisableRenderersInChildren();

            StartCoroutine(ShowKillMent());

            Invoke("Respawn", respawnDelay);
        }
    }

    private void Respawn()
    {
        EnableRenderersInChildren();
        // killMent 비활성화
        killMent.SetActive(false);
    }

    private void DisableRenderersInChildren()
    {
        // 현재 객체의 모든 하위 객체들의 Renderer를 찾아서 비활성화
        Renderer[] renderers = GetComponentsInChildren<Renderer>();
        int count = 0;
        foreach (Renderer renderer in renderers)
        {
            if (renderer.enabled != false && count == 0)
            {
                count++;
                source.PlayOneShot(hitAudio);
                GameManager.score++;
            }
            renderer.enabled = false;
        }
    }

    private void EnableRenderersInChildren()
    {
        // 현재 객체의 모든 하위 객체들의 Renderer를 찾아서 활성화
        Renderer[] renderers = GetComponentsInChildren<Renderer>();
        foreach (Renderer renderer in renderers)
        {
            renderer.enabled = true;
        }
    }

    // 죽은 후 1초 동안 killMent를 보여주는 코루틴
    IEnumerator ShowKillMent()
    {
        // killMent 활성화
        killMent.SetActive(true);
        yield return new WaitForSeconds(1f);
        // 1초 후 killMent 비활성화
        killMent.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}