using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {
	public Text text;
	private enum States {cell, mirror, sheet_0, lock_0, cell_mirror, sheets_1, lock_1, freedom};
	private States currentState;
	// Use this for initialization
	void Start () {
		currentState = States.cell;
	}
	
	// Update is called once per frame
	void Update () {
		print(currentState);
		if(currentState == States.cell){state_cell();}
		else if(currentState == States.sheet_0){state_sheet_0();}
		else if(currentState == States.lock_0){state_lock_0();}
		else if(currentState == States.mirror){state_mirror();}
		else if(currentState == States.cell_mirror){cell_mirror();}
		else if(currentState == States.sheets_1){sheets_1();}
		else if(currentState == States.lock_1){lock_1();}
		else if(currentState == States.freedom){freedom();}
	}

	void state_cell(){
		text.text = "You are in a prison cell, and you want to escaoe." +
		"There are some dirty sheets on the bed, a mirror on the wall, and the door " +
		"is locked form the outside.\n\n"+
		"Press S for sheets, M for mirror and L for view lock.";
		if(Input.GetKeyDown(KeyCode.S))
			currentState = States.sheet_0;
		else if(Input.GetKeyDown(KeyCode.L))
			currentState = States.lock_0;
		else if(Input.GetKeyDown(KeyCode.M))
			currentState = States.mirror; 
	}
	void state_sheet_0(){
		text.text = "You find nothing. press R to keep searching.";
		if(Input.GetKeyDown(KeyCode.R))
			currentState = States.cell;  
	}
	void state_lock_0(){
		text.text = "You find nothing. press R to keep searching.";
		if(Input.GetKeyDown(KeyCode.R))
			currentState = States.cell;
	}
	void state_mirror(){
		text.text = "You see something in the mirror, press T to move the mirror.";
		if(Input.GetKeyDown(KeyCode.T))
			currentState = States.cell_mirror;
	}
	void cell_mirror(){
		text.text = "You are in a prison cell, and you want to escaoe." +
		"There are some dirty sheets on the bed, a mirror on the wall, and the door " +
		"is locked form the outside.\n\n"+
		"Press S for sheets, M for mirror and L for view lock.";
		if(Input.GetKeyDown(KeyCode.S))
			currentState = States.sheets_1;
		else if(Input.GetKeyDown(KeyCode.L))
			currentState = States.lock_1;
		else if(Input.GetKeyDown(KeyCode.M))
			currentState = States.freedom; 
	}

	void sheets_1(){
		text.text = "You find nothing. press R to keep searching.";
		if(Input.GetKeyDown(KeyCode.R))
			currentState = States.cell_mirror;  
	}
	void lock_1(){
		text.text = "You find nothing. press O to open.";
		if(Input.GetKeyDown(KeyCode.O))
			currentState = States.freedom;
	}
	void freedom(){
		text.text = "You are free! press P to Play again";
		if(Input.GetKeyDown(KeyCode.P))
			currentState = States.cell;
	}
}
