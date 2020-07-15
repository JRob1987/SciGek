//player behavior script

using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    //visible in inspector
    
    [SerializeField] private GameObject _playerPrefab;
    //[SerializeField] private float _jumpPower = 3f;
    [SerializeField] private Transform _groundCheckPosition;
    [SerializeField] private float _radius = 0.3f;
    [SerializeField] private LayerMask _groundLayer;
    

    //not visible in inspector
    //private Rigidbody _myBody;
    private bool _isGrounded;
    //private bool _playerJumped = false;
    //private PlayerAnimations _animations;
    //private Vector3 _movement;
   // private float distance = 2f;
   
    
  

    private void Awake()
    {
        //getting a reference to the components
       // _myBody = GetComponent<Rigidbody>();
        //_animations = GameObject.Find("Player").GetComponent<PlayerAnimations>();
        //
    }
    // Start is called before the first frame update
    void Start()
    {
        _isGrounded = true;     
       
        
    }

    
    void Update()
    {
        

        //null checking if player exists
        if (_playerPrefab != null)
        {
            
           
            IsPlayerGrounded();
            //Jump();
            
        }
        else
        {
            Debug.LogError("Player is null!");
        }
        
    }    

   


    //method to check if the player is grounded
    private void IsPlayerGrounded()
    {
        _isGrounded = Physics.OverlapSphere(_groundCheckPosition.position, _radius, _groundLayer).Length > 0;
       // Debug.Log("Player is touching the ground!");
        /*
        if(_isGrounded && _playerJumped)
        {
            _playerJumped = false;
            _animations.LandAnimation();
        }
       */
    }

    //method for player jump
    
   /* private void Jump()
    {
        if (Input.GetKey(KeyCode.Space) && _isGrounded == true)
        {
            _animations.JumpAnimation();
            _myBody.AddForce(new Vector3(0, _jumpPower, 0));
            _playerJumped = true;
            Debug.Log("jumped once");
        }          
              
    }
   */
  
    


} // class
