using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{

    public Vector2 MoveInput;


    #region proMethod
    #endregion
    public void OnMove(InputValue input) => MoveInput = input.Get<Vector2>();
    //{ MoveInput = Input.Get<Vector2>(); }



   // public void OnMove(InputValue input)
   //     { MoveInput = Input.get<Vector2>(); }

}
