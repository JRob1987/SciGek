using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSmoke : MonoBehaviour
{

    [SerializeField] private GameObject _smokeEffect;
    [SerializeField] private GameObject _smokePosition;

    //Collision detection when feet touch the platform
    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == LevelOneTags.LEVELPLATFORM)
        {
            //Debug.Log("Right and left feet are touching the Platform");
            if(_smokePosition.activeInHierarchy)
            {
                Instantiate(_smokeEffect, _smokePosition.transform.position, Quaternion.identity);
            }
        }
    }






} //end class
