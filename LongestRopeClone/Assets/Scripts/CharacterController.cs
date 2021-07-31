using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;

public class CharacterController : MonoBehaviour
{
    [SerializeField] float _speed, _turnSpeed;
    [SerializeField] DynamicJoystick _joystick;

    // ROPE LENGTH PROCESS //
    [Header("ROPE LENGTH ")]
    [SerializeField] float length;
    [SerializeField] float changeLength;
    [SerializeField] ObiRopeCursor cursor;

    Animator _animator;

    public static CharacterController instance;


    private void Awake()
    {
        _animator = GetComponent<Animator>();

        if (instance == null) { instance = this; }
      
        
    }
    private void Start()
    {
        cursor.ChangeLength(length);
    }

    private void Update()
    {

        Move();
    }

    void Move()
    {
        float horizontalInput = _joystick.Horizontal;
        float verticalInput = _joystick.Vertical;

        if (FindObjectOfType<GameManager>().playerState == GameManager.PlayerState.Playing)
        {
            

            Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
            movementDirection.Normalize();

            transform.Translate(movementDirection * _speed * Time.deltaTime, Space.World);

            if (movementDirection != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, _turnSpeed * Time.deltaTime);
            }

        }

        // ANIMATION CONTROL //
        if (horizontalInput == 0 && verticalInput == 0)
        {
            _animator.SetInteger("Number", 0);
        }
        else
        {
            _animator.SetInteger("Number", 1);
        }
        /////////////////////////////////////////////

    }

    public void ExtendTheRope() 
    {
        length += changeLength;

        cursor.ChangeLength(length);
    }
}
