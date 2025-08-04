using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager instance;

    [SerializeField] private AudioSource soundFXObject;
    [Range(0, 1)][SerializeField] float volume;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    public void PlaySFXClip(AudioClip audioClip)
    {
        AudioSource audioSource = Instantiate(soundFXObject);

        audioSource.clip = audioClip;
        audioSource.volume = volume;
        audioSource.Play();
        float clipLength = audioSource.clip.length;

        Destroy(audioSource.gameObject, clipLength);
    }
}
