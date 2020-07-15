//character controller script
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private float _movementSpeed = 1.0f;
    [SerializeField] private float _rotateSpeed = 1.0f;
    [SerializeField] private float _runningSpeed = 1.0f;
    [SerializeField] private GameObject _smokeEffect;
   // [SerializeField] private float _radius = 0.3f;

    private CharacterController _playerController;
    private PlayerAnimations _animations;
   

    private void Awake()
    {
        _animations = GameObject.Find("Player").GetComponent<PlayerAnimations>();
        _playerController = GetComponent<CharacterController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //starting position
        transform.position = new Vector3(0, 0, 0);
    }

   

    // Update is called once per frame
    void Update()
    {
        if (_playerPrefab != null)
        {
            RotatePlayer();
            PlayerWalk();
            PlayerRun();


        }
        else
        {
            Debug.Log("Player is null!");
        }
    }

    //method for rotating the player
    private void RotatePlayer()
    {
        float _horizontalMovement = Input.GetAxis("Horizontal");
        //rotate player around y axis
        transform.Rotate(0, _horizontalMovement * _rotateSpeed, 0);
    }

    //method for player walking movement
    private void PlayerWalk()
    {                

        if(Input.GetKey(KeyCode.W))
        {
            //move player forward 
            Vector3 forwardMovement = transform.TransformDirection(Vector3.forward * _movementSpeed);
            _animations.PlayerWalkAnimation();
            _playerController.SimpleMove(forwardMovement);
        }
        else if( Input.GetKeyUp(KeyCode.W))
        {
            _animations.PlayerStopWalkingAnimation();
        }

        
    } 

    //method for player running
    private void PlayerRun()
    {
        
        //player running
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Vector3 runningMovement = transform.TransformDirection(Vector3.forward * _runningSpeed);
            _animations.WalkToRun();
            _animations.PlayerRunAnimation();
            _smokeEffect.SetActive(true);
            _playerController.SimpleMove(runningMovement);
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _animations.PlayerStopRunningAnimation();
            _animations.IdleAnimation();
            _smokeEffect.SetActive(false);
        }

        

       
    }

    
           
    



} //end class
