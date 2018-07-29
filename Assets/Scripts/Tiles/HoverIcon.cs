﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverIcon : MonoBehaviour {

	public static HoverIcon Instance;

	// coordination
	private int posX;
	private int posY;
	
	// which icon?
	bool lightAttack;
	bool heavyAttack;
	bool useItem;
	bool rally;
	bool castSpell;
	bool specialAbility;

	Animator anim;

	void Start(){
		
		posX = (int)this.transform.position.x;
		posY = (int)this.transform.position.y;
		anim = GetComponent<Animator>();

		lightAttack = this.gameObject.GetComponent<IconProperties>().lightAttack;
		heavyAttack = this.gameObject.GetComponent<IconProperties>().heavyAttack;
		rally = this.gameObject.GetComponent<IconProperties>().rally;
		useItem = this.gameObject.GetComponent<IconProperties>().useItem;
		castSpell = this.gameObject.GetComponent<IconProperties>().castSpell;
		specialAbility = this.gameObject.GetComponent<IconProperties>().specialAbility;

	}

	void Awake() {
        Instance = this;
    }

	void OnMouseOver() {

		if( !GlobalVariables.freezeIconHUD ){
			// for all icons
			anim.Play("lit");
			GlobalFunctions.CleanUpTerrainInfoPanel(true);

			if(lightAttack){
				GlobalFunctions.DisplayBattleOptionInfo(Enums.BattleOption.LightAttack);
			}else if(heavyAttack){
				GlobalFunctions.DisplayBattleOptionInfo(Enums.BattleOption.HeavyAttack);
			}else if(useItem){
				GlobalFunctions.DisplayBattleOptionInfo(Enums.BattleOption.UseItem);
			}else if(rally){
				GlobalFunctions.DisplayBattleOptionInfo(Enums.BattleOption.Rally);
			}else if(castSpell){
				GlobalFunctions.DisplayBattleOptionInfo(Enums.BattleOption.CastSpell);
			}else if(specialAbility){
				GlobalFunctions.DisplayBattleOptionInfo(Enums.BattleOption.SpecialAbility);
			}
		}

    }

	void OnMouseExit(){
		
		if( !GlobalVariables.freezeIconHUD ){
			// clean up battle option HUD icon
			if(GameObject.Find("battleOptionIcon")){
				GameObject gotileIcon = GameObject.Find("battleOptionIcon");
				Destroy(gotileIcon);
			}
			// display terrian info again
			GlobalFunctions.DisplayTileInfo(GlobalVariables.selectedUnit.x, GlobalVariables.selectedUnit.y);
			anim.Play("idle");
		}

	}

	public void PlayIdle(){
		anim.Play("idle");
	}

	public void PlayLit(){
		anim.Play("lit");
	}

}