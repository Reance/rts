﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHover : Singleton<MouseHover>
{

    private SpriteRenderer spriteRenderer;
	// Use this for initialization
	void Start ()
	{
	    spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	    FollowMouse();
	}
    
    private void FollowMouse()
    {
        if(spriteRenderer.sprite != null)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
        
    }

    public void Activate(Sprite sprite)
    {
        this.spriteRenderer.sprite = sprite;
    }

    public void Deactivate()
    {
        this.spriteRenderer.sprite = null;
    }
}
