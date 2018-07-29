﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverTile : MonoBehaviour {
	
	public static HoverTile Instance;
	// private GameObject availableCell;

	private int posX;
	private int posY;

	void Start(){
		posX = (int)this.transform.position.x;
		posY = (int)this.transform.position.y;
	}

	void Awake() {
        Instance = this;
    }

	void OnMouseOver() {

		if( GlobalVariables.selectedUnit.x == 0 && GlobalVariables.selectedUnit.y == 0 ){
			GlobalFunctions.UpdateHUDcursor(posX, posY);
			GlobalFunctions.DisplayTileInfo(posX,posY);
			if( GlobalVariables.unitsMatrix [posX,posY ] != null && 
			    !GlobalVariables.unitsMatrix[ posX,posY ].displayAvailableCells && 
				GlobalVariables.unitsMatrix[ posX,posY ].canMove ){
					GlobalFunctions.DisplayAvailableCells(posX,posY);
			}
		}
		
    }

	void OnMouseExit(){

		if( (GlobalVariables.selectedUnit.x == 0 && GlobalVariables.selectedUnit.y == 0) ){
			int posX = (int)this.transform.position.x;
			int posY = (int)this.transform.position.y;
			GlobalFunctions.CleanUpOldHUDcursor();
			// CleanUpHUDinfoPanel();
			GlobalFunctions.CleanUpUnitInfoPanel();
			GlobalFunctions.CleanUpTerrainInfoPanel();
			GlobalFunctions.CleanUpHUDavailable(posX,posY);
		}
		
	}



	

}