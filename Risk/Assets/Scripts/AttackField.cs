using UnityEngine;
using System.Collections;

public class AttackField : UnityEngine.UI.InputField {
	new void Start()
	{
		onValidateInput += delegate(string input, int charIndex, char addedChar) { return ValidateAsPositiveInteger(addedChar); };
	}

	private char ValidateAsPositiveInteger(char charToValidate)
	{
		if (charToValidate <48 || charToValidate > 57)
		{
			charToValidate = '\0';
		}
		return charToValidate;
	}

	public void EditArmiesMethod(int attackingArmies, int defendingArmies) {
			text = attackingArmies.ToString ();
	}


}
