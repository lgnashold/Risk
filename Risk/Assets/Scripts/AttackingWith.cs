using UnityEngine;
using System.Collections;

public class AttackingWith: UnityEngine.UI.InputField {
	new void Start()
	{
		onValidateInput += delegate(string input, int charIndex, char addedChar) { 
			if(charIndex>0 || addedChar < 49 || addedChar > 51) { return '\0';}
			return addedChar;
		};
	}
}