using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{

    [SerializeField] private float _audioFootVolume = 1f;
    [SerializeField] private float _randomPitchSoundEffects = 0.05f;
    [SerializeField] private AudioClip _genericFootSound;
    [SerializeField] private AudioClip _metalFootSound;
    private float _collisionSoundEffect = 1f;

    private AudioSource _source;
   
    

    // Start is called before the first frame update
    void Awake()
    {
        _source = GetComponent<AudioSource>();
    }

    private void FootSound()
    {
        //randomize the pitch of the sound effects
        _source.volume = _collisionSoundEffect * _audioFootVolume;
        _source.pitch = Random.Range(1.0f - _randomPitchSoundEffects, 1.0f + _randomPitchSoundEffects);
        Debug.Log("Played sound");

        if(Random.Range(0,2) > 0)
        {
            _source.clip = _genericFootSound;
        }
        else
        {
            _source.clip = _metalFootSound;
        }
        _source.Play();
    }
   
















} //class
