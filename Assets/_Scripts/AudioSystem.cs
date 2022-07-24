using UnityEngine;

public class AudioSystem : MonoBehaviour
{
    private static AudioSystem Instance;

    [SerializeField] AudioSource sfxSource;

    #region Global
    public static void PlaySFX_Global(AudioClip audioClip)
    {
        if (Instance == null)
            return;

        Instance.PlaySFX_Local(audioClip);
    }
    #endregion

    #region Local
    void PlaySFX_Local(AudioClip audioClip)
    {
        sfxSource.PlayOneShot(audioClip);
    }
    #endregion

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
    }
}
