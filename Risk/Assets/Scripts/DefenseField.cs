using UnityEngine;
using System.Collections;

public class DefenseField : UnityEngine.UI.InputField {
	new void Start()
	{
		// Sets the MyValidate method to invoke after the input field's default input validation invoke (default validation happens every time a character is entered into the text field.)
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
			text = defendingArmies.ToString ();
	}


}
