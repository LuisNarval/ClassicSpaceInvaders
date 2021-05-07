using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable
{
    int Healt { get; set; }

    void ReceiveDamage(int amount);
    void Death();
}