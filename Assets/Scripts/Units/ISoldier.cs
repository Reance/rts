using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISoldier  {

	Point CurrentPoint { get; set; }
    
    int Health { get; set; }
    void Move();
    void Attack();
    void TakeDamage(int damageAmount);
    void Die();
}
