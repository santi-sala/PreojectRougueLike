using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Resource : MonoBehaviour
{
    [field: SerializeField]
    public SO_ResourceData ResourceData { get; set; }

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PickUpResource()
    {
        StartCoroutine(DestroyItemCoroutine());
    }

    IEnumerator DestroyItemCoroutine()
    {
        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        _audioSource.Play();
        yield return new WaitForSeconds(_audioSource.clip.length);
        Destroy(gameObject);
    }
}
