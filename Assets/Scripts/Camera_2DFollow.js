﻿#pragma strict

var Target : Transform; 

var distance = 5;

var targetDistance = -4.2;

function LateUpdate () { 

    transform.position = Target.position + Vector3(0, distance, -30); 

    transform.LookAt (Target); 
	var currentHeight = transform.position.y;
	
	
	// Set the height of the camera
	
	//set the camera's position in front of the Target
	transform.position.z = targetDistance;
}