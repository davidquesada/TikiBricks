using UnityEngine;
using System.Collections;

public class InstructionsController : Controller {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void BackToMenuButton_Clicked()
    {
        ApplicationController.Main.ShowScene(ApplicationController.Main.MenuControllerPrefab);
    }
}
