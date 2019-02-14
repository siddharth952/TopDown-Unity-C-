using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour {



    private void MoveCrossHairAndShoot()
    {
        Vector3 aim = new Vector3(Input.GetAxis("AimHorizontal"), Input.GetAxis("AimVertical"), 0.0f);
        Vector2 ShootingDirection = new Vector2(Input.GetAxis("AimHorizontal"), Input.GetAxis("AimVertical"));



        if (aim.magnitude > 0.0f) //Only move Crosshair when we move with joystick ie transform
        {
            aim.Normalize(); //Crosshair move with player while aiming! Circular motion!
            aim *= 0.4f; //Reduce distance from player 
            crossHair.transform.localPosition = aim;
            crossHair.SetActive(true);
        }
        else
        {
            crossHair.SetActive(false);
        }

        ShootingDirection.Normalize(); // Joystick fully to side or not, will be same

        if (Input.GetButtonDown("Fire") || Input.GetButtonDown("Fire1")) //Down for not for every frame
        {
            GameObject arrow = Instantiate(arrowPrefab, transform.position, Quaternion.identity); //Quaternion for rotation and identity is for no rotation
            Debug.Log("Fire!!");

            arrow.GetComponent<Rigidbody2D>().velocity = ShootingDirection * 3 ;  //right
        }
    }

    public Animator animator;
    public GameObject crossHair;

    public GameObject arrowPrefab;

    

	void Start () {
		
	}
	
	
	void Update () {

        Vector3 movement = new Vector3(Input.GetAxis("MoveHorizontal"), Input.GetAxis("MoveVertical"), 0.0f); //Adding factor from user input
      



        MoveCrossHairAndShoot();

        animator.SetFloat("Horizontal", movement.x); //X Comp of movement vector
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Magnitude", movement.magnitude);

        transform.position = transform.position + movement *Time.deltaTime;
		
	}


}
