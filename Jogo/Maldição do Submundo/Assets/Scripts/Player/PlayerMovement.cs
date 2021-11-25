using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A Class that deals with player movement
/// </summary>
public class PlayerMovement : MonoBehaviour, IMoveable {
    // Components
    private Rigidbody2D rb;
    private Animator animator;

    private bool shouldPlayerMove = true;
    [SerializeField]
    private float walkingSpeed;
    [SerializeField]
    private float animationBreakpoint = .1f;

    public void AllowPlayerToMove(bool value) {
        shouldPlayerMove = value;
    }

    void Start() {
        this.animator = this.GetComponent<Animator>();
        this.rb = this.GetComponent<Rigidbody2D>();

        this.rb.gravityScale = 0;
    }

    void Update() {
        this.HandleInput();
    }

    /// <summary>Handles given input</summary>
    void HandleInput() {
        var inputX = Input.GetAxis(axisName: "Horizontal");
        var inputY = Input.GetAxis(axisName: "Vertical");

        if (this.shouldPlayerMove) {
            Move(inputX, inputY);

            this.SetAnimation(
                InputToMovement(inputX),
                InputToMovement(inputY)
            );
        }
    }

    public void RequestStopMoving () {}

    /// takes input and transales it to a movement
    /// validates if the movement is valid
    void Move(float inputX, float inputY) {
        if (inputX == 0 && inputY == 0) return;

        var angle = Mathf.Atan2(inputY, inputX);
        var direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

        var deltaTime = Time.deltaTime;

        this.Translate(direction * this.walkingSpeed);
    }

    /// <summary>Gets horizontal direction</summary>
    PlayerDirection getDirection() {
        return Mathf.Sign(transform.localScale.x) == 1
        ? PlayerDirection.Left
        : PlayerDirection.Right
    ;}

    /// <summary>Flips character sprite to direction</summary>
    void turnCharacterToDirection (PlayerDirection playerNewDirection) {
        var shouldFlip = this.getDirection() != playerNewDirection && playerNewDirection != PlayerDirection.Null;
        var x = (shouldFlip ? -1 : 1) * transform.localScale.x;
        transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);
    }

    /// <summary>Converts input into a direction</summary>
    PlayerTypeMovement InputToMovement(float input) {
        if (input > this.animationBreakpoint) 
            return PlayerTypeMovement.Positive;
        else if (input < - this.animationBreakpoint)
            return PlayerTypeMovement.Negative;
        else
            return PlayerTypeMovement.Null;
    }

    /// <summary>Translate character to x, y position</summary>
    void Translate(Vector2 dx) {
        var deltaTime = Time.fixedDeltaTime;
        this.rb.MovePosition(deltaTime * dx + this.rb.position);
    }

    /// <summary>Changes character animation depending on its direction</summary>
    void SetAnimation(
        PlayerTypeMovement playerMovementX, 
        PlayerTypeMovement playerMovementY
    ) {
        // Pressed keys
        var up = playerMovementY == PlayerTypeMovement.Positive;
        var right = playerMovementX == PlayerTypeMovement.Positive;
        var down = playerMovementY == PlayerTypeMovement.Negative;
        var left = playerMovementX == PlayerTypeMovement.Negative;
        var moving = playerMovementX != PlayerTypeMovement.Null || playerMovementY != PlayerTypeMovement.Null;

        var horizontalDirection = right ? PlayerDirection.Right : PlayerDirection.Null;
        horizontalDirection = left ? PlayerDirection.Left : horizontalDirection;
        this.turnCharacterToDirection(horizontalDirection);

        this.animator.SetBool("up", up);
        this.animator.SetBool("down", down);
        this.animator.SetBool("horizontal", left || right);
        this.animator.SetBool("moving", moving);
    }

    // Enums

    enum PlayerTypeMovement {
        Positive = 1,
        Null = 0,
        Negative = -1
    }
    enum PlayerDirection { Left, Right, Null }
}
