using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    public MyEvent onFinishSound;

    public void PlayAudioWithPause(Audio audioClip)
    {
        GetComponent<AudioSource>().PlayOneShot(audioClip.Clip);
        StartCoroutine(WaitForSeconds(audioClip));
    }

    public void PlayAudioWithOutPause(Audio audioClip)
    {
        GetComponent<AudioSource>().PlayOneShot(audioClip.Clip);
    }

    public void StopAudio()
    {
        GetComponent<AudioSource>().Stop();
    }

    private IEnumerator WaitForSeconds(Audio audioClip)
    {
        yield return new WaitForSeconds(audioClip.Clip.length);
        onFinishSound.Invoke(audioClip.Name);
    }

}
