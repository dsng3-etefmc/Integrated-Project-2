using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour {

    Animator animator;
    CharacterController controller;
    public float walkingSpeed;
    public float animationBreakpoint = .1f;
    enum PlayerMovement {
        Positive = 1,
        Null = 0,
        Negative = -1
    }
    enum PlayerDirection { Left, Right, Null }

    // Start is called before the first frame update
    void Start() {
        this.animator = this.GetComponent<Animator>();
        this.controller = this.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update() {
        this.HandleInput();
    }

    void HandleInput() {
        var inputX = Input.GetAxis(axisName: "Horizontal");
        var inputY = Input.GetAxis(axisName: "Vertical");

        var input = new Vector3(inputX, inputY, 0);
        var deltaTime = Time.deltaTime;

        this.controller.Move(input * deltaTime * walkingSpeed);

        this.SetAnimation(
            InputToMovement(inputX),
            InputToMovement(inputY)
        );
    }

    PlayerDirection getDirection() {
        return Mathf.Sign(transform.localScale.x) == 1
        ? PlayerDirection.Left
        : PlayerDirection.Right
    ;}

    void turnCharacterToDirection (PlayerDirection playerNewDirection) {
        print(playerNewDirection + ":" + this.getDirection());
        var shouldFlip = this.getDirection() != playerNewDirection && playerNewDirection != PlayerDirection.Null;
        print(shouldFlip);
        var x = (shouldFlip ? -1 : 1) * transform.localScale.x;
        transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);
    }

    PlayerMovement InputToMovement(float input) {
        if (input > this.animationBreakpoint) 
            return PlayerMovement.Positive;
        else if (input < - this.animationBreakpoint)
            return PlayerMovement.Negative;
        else
            return PlayerMovement.Null;
    }

    void Translate(float tx, float ty) {
        transform.Translate(tx, ty, 0);
    }
    void SetAnimation(
        PlayerMovement playerMovementX, 
        PlayerMovement playerMovementY
    ) {
        var up = playerMovementY == PlayerMovement.Positive;
        var right = playerMovementX == PlayerMovement.Positive;
        var down = playerMovementY == PlayerMovement.Negative;
        var left = playerMovementX == PlayerMovement.Negative;

        var direction = right ? PlayerDirection.Right : PlayerDirection.Null;
        direction = left ? PlayerDirection.Left : direction;
        this.turnCharacterToDirection(direction);

        this.animator.SetBool("up", up);
        this.animator.SetBool("down", down);
        this.animator.SetBool("horizontal", left || right);
        // this.animator.SetBool("right", right);
        // this.animator.SetBool("left", left);
    }
}
