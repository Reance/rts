using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifleman : MonoBehaviour,ISoldier {

    public Point CurrentPoint { get; set; }

    public int Health { get; set; }
  

    public void Attack()
    {
        throw new System.NotImplementedException();
    }

    public void Die()
    {
        throw new System.NotImplementedException();
    }

    public void Move()
    {
        throw new System.NotImplementedException();
    }

    public void TakeDamage(int damageAmount)
    {
        throw new System.NotImplementedException();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameManager.Instance.SelectSoldier(this);
        }
    }
}
