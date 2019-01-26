using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerHealth
{
    void TakeDamage(int amount);
    void Die();
}
