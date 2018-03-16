using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Rifleman : MonoBehaviour,ISoldier {

    public Point CurrentPoint { get; set; }

    public int Health { get; set; }
    [SerializeField]
    private float speed;

    private Vector3 destination;
    private Stack<Node> path;
    public Stack<Node> Path {
        get { return path; }
        set
        {
            this.path = value;
            if(path.Count>0)
            {
                destination = path.Pop().WorldPosition;
            }
            else
            {
                path = null;
            }
        }
    }

    public void Attack()
    {
        throw new System.NotImplementedException();
    }

    public void Die()
    {
        //setting up tile availability  to prevent collisions with other objects
        LevelManager.Instance.Tiles[CurrentPoint].SetAvailability(1,1,true);
        path = null;
        GameManager.Instance.Pool.RelaseObject(this.gameObject);
        
    }

    public void Move()
    {
        if (path!=null)
        {

            transform.position = Vector2.MoveTowards(transform.position, destination, speed * Time.deltaTime);
            if (transform.position == destination && path.Count > 0)
            {
                LevelManager.Instance.Tiles[CurrentPoint].SetAvailability(1,1,true);
                CurrentPoint = path.Peek().GridPosition;
                LevelManager.Instance.Tiles[CurrentPoint].SetAvailability(1,1,false);
                destination = path.Pop().WorldPosition;
            }
            

        }
    }
    public void TakeDamage(int damageAmount)
    {
        throw new System.NotImplementedException();
    }

    // Use this for initialization
    void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update () {
		Move();
	}

    void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameManager.Instance.SelectSoldier(this);
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Die();
        }
    }
}
