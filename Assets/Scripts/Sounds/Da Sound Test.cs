using UnityEngine;

public class DaSoundTest : MonoBehaviour
{
    [SerializeField]
    private AudioClip _audioClip;
    [SerializeField]
    private AudioSource _audioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _audioSource.clip = _audioClip;
        _audioSource.Play();
    }
}
