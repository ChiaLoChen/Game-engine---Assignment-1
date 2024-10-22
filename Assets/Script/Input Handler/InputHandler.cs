using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private PlayerMovement _player;

    private Command _forward, _back, _left, _right, _jump, _shoot;

    public KeyCode _kForward, _kBack, _kLeft, _kRight, _kJump, _kShoot;

    private Invoker _invoker;
    private bool _isReplaying;
    private bool _isRecording;
    
    // Start is called before the first frame update
    void Start()
    {
        //_player = GetComponent<PlayerMovement>();
        _player = FindObjectOfType<PlayerMovement>();
        _invoker = gameObject.AddComponent<Invoker>();

        _forward = new Forward(_player);
        _left = new Left(_player);
        _right = new Right(_player);
        _back = new Backwards(_player);
        _jump = new Jump(_player);
        _shoot = new Shoot(_player);

        _kForward = KeyCode.W;
        _kBack = KeyCode.S;
        _kLeft = KeyCode.A;
        _kRight = KeyCode.D;
        _kJump = KeyCode.Space;
        _kShoot = KeyCode.Mouse0;
        
        _isReplaying = false;
        _isRecording = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isReplaying)
        {
            if (Input.GetKey(_kForward))
            {
                //Debug.Log("pressing forward");
                _forward.Execute();
            }

            if (Input.GetKey(_kBack))
            {
                _back.Execute();
            }

            if (Input.GetKey(_kLeft))
            {
                _left.Execute();
            }

            if (Input.GetKey(_kRight))
            {
                _right.Execute();
            }

            if (Input.GetKey(_kJump))
            {
                _jump.Execute();
            }

            if (Input.GetKey(_kShoot))
            {
                _shoot.Execute();
            }
        }
    }

    public void UpdateKeys(KeyCode key, KeyCode newKey)
    {
        if(key == _kForward)
        {
            _kForward = newKey;
        }
        else if(key == _kBack)
        {
            _kBack = newKey;
        }
        else if(key == _kLeft)
        {
            _kLeft = newKey;
        }
        else if(key == _kRight)
        {
            _kRight = newKey;
        }
        else if(key == _kJump)
        {
            _kJump = newKey;
        }
        else if(key == _kShoot)
        {
            _kShoot = newKey;
        }
        else
        {
            Debug.Log("Invalid key!");
            Debug.Log(key.ToString());
        }
    }

    void OnGUI()
    {
        if (GUILayout.Button("Start Recording"))
        {
            //_player.ResetPosition();
            _isReplaying = false;
            _isRecording = true;
            _invoker.Record();
        }

        if (GUILayout.Button("Stop Recording"))
        {
            //_player.ResetPosition();
            _isRecording = false;
        }

        if (!_isRecording)
        {
            if (GUILayout.Button("Start Replay"))
            {
                //_player.ResetPosition();
                _isRecording = false;
                _isReplaying = true;
                _invoker.Replay();
            }
        }
    }
}
