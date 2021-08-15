using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A Class that deals with player movement
/// </summary>
public class PlayerMoviment : MonoBehaviour {
    // Self reference
    public static PlayerMoviment current;

    // Components
    Rigidbody2D rigidbody;
    Animator animator;

    public ScenesController scenesController;

    bool isPlayerHalted = true;
    public float walkingSpeed;
    public float animationBreakpoint = .1f;

    private void Awake() { current = this; }

    void Start() {
        this.animator = this.GetComponent<Animator>();
        this.rigidbody = this.GetComponent<Rigidbody2D>();

        this.rigidbody.gravityScale = 0;
    }

    void Update() {
        this.HandleInput();
    }

    // ---

    /// <summary>Disable or enable player movement</summary>
    public void shouldPlayerMove(bool should) {
        this.isPlayerHalted = should;
    }

    /// <summary>Handles given input</summary>
    void HandleInput() {
        var inputX = Input.GetAxis(axisName: "Horizontal");
        var inputY = Input.GetAxis(axisName: "Vertical");

        var input = new Vector2(inputX, inputY);
        var deltaTime = Time.deltaTime;

        if (this.isPlayerHalted) {
            // this.transform.position += input * deltaTime * walkingSpeed;
            this.Translate(input * this.walkingSpeed);            
            // this.Translate(input * deltaTime * walkingSpeed);

            this.SetAnimation(
                InputToMovement(inputX),
                InputToMovement(inputY)
            );
        }
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
    PlayerMovement InputToMovement(float input) {
        if (input > this.animationBreakpoint) 
            return PlayerMovement.Positive;
        else if (input < - this.animationBreakpoint)
            return PlayerMovement.Negative;
        else
            return PlayerMovement.Null;
    }

    /// <summary>Translate character to x, y position</summary>
    void Translate(Vector2 dx) {
        var deltaTime = Time.fixedDeltaTime;
        this.rigidbody.MovePosition(deltaTime * dx + this.rigidbody.position);
        // transform.Translate(dx);
    }

    /// <summary>Changes character animation depending on its direction</summary>
    void SetAnimation(
        PlayerMovement playerMovementX, 
        PlayerMovement playerMovementY
    ) {
        // Pressed keys
        var up = playerMovementY == PlayerMovement.Positive;
        var right = playerMovementX == PlayerMovement.Positive;
        var down = playerMovementY == PlayerMovement.Negative;
        var left = playerMovementX == PlayerMovement.Negative;

        var horizontalDirection = right ? PlayerDirection.Right : PlayerDirection.Null;
        horizontalDirection = left ? PlayerDirection.Left : horizontalDirection;
        this.turnCharacterToDirection(horizontalDirection);

        this.animator.SetBool("up", up);
        this.animator.SetBool("down", down);
        this.animator.SetBool("horizontal", left || right);
    }

    // Enums

    enum PlayerMovement {
        Positive = 1,
        Null = 0,
        Negative = -1
    }
    enum PlayerDirection { Left, Right, Null }
}
