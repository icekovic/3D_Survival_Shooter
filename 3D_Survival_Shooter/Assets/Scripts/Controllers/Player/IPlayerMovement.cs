using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerMovement
{
    void Move(float horizontal, float vertical);
    void Turn();
    void Animate(float horizontal, float vertical);
}
