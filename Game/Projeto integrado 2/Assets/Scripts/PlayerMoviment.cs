using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour {

    Animator animator;
    CharacterController controller;
    public float walkingSpeed;
    public float animationBreakpoint = .1f;

    // Start is called before the first frame update
    void Start() {
        this.animator = this.GetComponent<Animator>();
        this.controller = this.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update() {
        this.HandleInput();
    }

    enum PlayerMovement {
        Positive,
        Null,
        Negative
    }

    void HandleInput() {
        var inputX = Input.GetAxis(axisName: "Horizontal");
        var inputY = Input.GetAxis(axisName: "Vertical");

        var input = new Vector3(inputX, inputY, 0);
        var deltaTime = Time.deltaTime;

        // this.controller.Move(input * deltaTime * walkingSpeed);

        this.SetAnimation(
            InputToMovement(inputX),
            InputToMovement(inputY)
        );
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

        this.animator.SetBool("up", up);
        this.animator.SetBool("right", right);
        this.animator.SetBool("down", down);
        this.animator.SetBool("left", left);
        // print(playerMovementX + ":" + playerMovementY);

        // if (!up && !right && !down && !left)
        //     this.animator.speed = 0;
        // else
        //     this.animator.speed = 1;

        print(playerMovementX == PlayerMovement.Negative);
    }
}
