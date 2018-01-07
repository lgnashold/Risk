using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MainScript : MonoBehaviour {
	//The number of armies in the defending country
	public int defenseTroops;
	public int attackTroops;
	public int numberAttackingWith;
	public AttackField attackInputField;
	public DefenseField defenseInputField;
	//In the format (attackingarmies, defending armies)
	public  delegate void EditArmies(int numAttackingArmies, int numDefendingArmies);
	public event EditArmies editArmies;
	public InputField numAttackingWith;

	// Use this for initialization
	void Start () {
		attackInputField.onEndEdit.AddListener(UpdateAttackMethod);
		defenseInputField.onEndEdit.AddListener(UpdateDefenseMethod);
		numAttackingWith.onEndEdit.AddListener (SetAttackingWith);
		editArmies += attackInputField.EditArmiesMethod;
		editArmies += defenseInputField.EditArmiesMethod;
	}

	public void Step() {
		if (defenseTroops > 0 && attackTroops > 1) {
			if (attackTroops - numberAttackingWith < 1)
				numberAttackingWith = attackTroops - 1;
			int [] attackDice = new int[numberAttackingWith];
			int [] defenseDice = new int[defenseTroops];
			for(int i=0; i < attackDice.Length; i++){
				attackDice [i] = rollDice ();
			}
			for(int i=0; i < defenseDice.Length; i++){
				defenseDice [i] = rollDice ();
			}
			if (attackDice [0] > defenseDice [0])
				defenseTroops--;
			else
				attackTroops--;
			if(attackDice.Length>1 && defenseDice.Length>1){
				if (attackDice [1] > defenseDice [1])
					defenseTroops--;
				else
					attackTroops--;
			}
		}
		editArmies.Invoke (attackTroops, defenseTroops);
	}

	private int rollDice(){
		return Random.Range (1, 6);
	}
		
	public void UpdateAttackMethod(string num) {
		int number = int.Parse (num);
		if (number > 0)
			this.attackTroops = number;
	}

	public void UpdateDefenseMethod(string num) {
		int number = int.Parse (num);
		if (number > 0)
			this.defenseTroops = number;
	}

	public void Skip() {
		while (defenseTroops > 0 && attackTroops > 1)
			Step ();
	}

	public void SetAttackingWith(string numAttackingWith) {
		numberAttackingWith = int.Parse (numAttackingWith);
	}

	public void StepFiveTimes () {
		for (int i = 0; i < 5; i++) {
			Step ();
		}
	}
}
