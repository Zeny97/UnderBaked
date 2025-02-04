using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private ScriptableAudioClip audioClip;
    // For now every Sound gets played at the location of the camera with the volume turned down
    // Sound should get played at the according Transform in the level

    // play sound at occuring position
    private void PlaySound(AudioClip _audioClip, Vector3 _position, float _volume = 1f)
    {
        AudioSource.PlayClipAtPoint(_audioClip, _position, _volume);
    }

    // If multiple Sounds for the same action exist, select a random one and play it
    private void PlaySound(AudioClip[] _audioClipArray, Vector3 _position, float _volume = 1f)
    {
        PlaySound(_audioClipArray[Random.Range(0, _audioClipArray.Length)], _position, _volume);
    }

    // Created an Event for when every sound should get played
    public void OnDeliveryFailed()
    {
        PlaySound(audioClip.deliveryFail,Camera.main.transform.position, 0.1f);
    }

    public void OnDeliverySuccess()
    {
        PlaySound(audioClip.deliverySuccess, Camera.main.transform.position, 0.1f);

    }

    public void OnCuttingIngredient()
    {
        PlaySound(audioClip.chop, Camera.main.transform.position, 0.05f);
    }

    public void OnCookingIngredient()
    {
        PlaySound(audioClip.stoveSizzle, Camera.main.transform.position, 0.01f);
    }

    public void OnPlayerMove()
    {
        PlaySound(audioClip.footstep, Camera.main.transform.position, 0.05f);
    }

    public void OnPickedSomething()
    {
        PlaySound(audioClip.objectPickup, Camera.main.transform.position, 0.05f);
    }

    public void OnDroppedSomething()
    {
        PlaySound(audioClip.objectDrop, Camera.main.transform.position, 0.05f);
    }

    public void OnDroppedIntoTrash()
    {
        PlaySound(audioClip.trash, Camera.main.transform.position, 0.1f);
    }
}
