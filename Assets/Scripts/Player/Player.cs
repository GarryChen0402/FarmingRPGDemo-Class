using UnityEngine;

public class Player : SingletonMonoBehaviour<Player>
{
    //Movement Parameters
    private  float xInput;
    private  float yInput;
    private bool isIdle;
    private bool isCarrying;
    private  bool isWalking;
    private  bool isRunning;
    private  ToolEffect toolEffect = ToolEffect.none;
    private  bool isUsingToolRight;
    private  bool isUsingToolLeft;
    private  bool isUsingToolUp;
    private  bool isUsingToolDown;
    private  bool isLiftingToolRight;
    private  bool isLiftingToolLeft;
    private  bool isLiftingToolUp;
    private  bool isLiftingToolDown;
    private  bool isSwingingToolRight;
    private  bool isSwingingToolLeft;  
    private  bool isSwingingToolUp;
    private  bool isSwingingToolDown;
    private  bool isPickingRight;
    private  bool isPickingLeft;
    private  bool isPickingUp;
    private  bool isPickingDown;
    private  bool idleUp;
    private  bool idleDown;
    private  bool idleLeft;
    private  bool idleRight;

    private Rigidbody2D rigidbody2D;
    
    private Direction playerDirection;

    private float movementSpeed;

    private bool _playerInputIsDisabled = false;

    public bool PlayerInputIsDisabled
    {
        get => _playerInputIsDisabled;
        set => _playerInputIsDisabled = value;
    }

    protected override void Awake()
    {
        base.Awake();
        
        rigidbody2D = GetComponent<Rigidbody2D>(); 
    }
}
