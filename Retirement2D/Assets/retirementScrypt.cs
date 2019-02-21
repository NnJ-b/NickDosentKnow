using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class retirementScrypt : MonoBehaviour {

    public InputField Age;
    public InputField RetirementAge;

    public InputField Cont0;
    public InputField Cont1;
    public InputField Cont2;
    public InputField Cont3;

    public InputField TellAge0;
    public InputField TellAge1;
    public InputField TellAge2;
    public InputField TellAge3;




    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	public void Calculate () {
        for (int i = int.Parse(Age.text); i < int.Parse(RetirementAge.text); i++)
        {

        }
	}
}
