using UnityEngine;
using System.Collections;

public class MenuController : Controller {

	// Use this for initialization
	void Start () {
        ApplicationController.Main.CurrentLevel = -1;
	}
	
	// Update is called once per frame
	void Update () {
        //Utility.SetVisible(ApplicationController.Main.TapToStartButtonObject.gameObject, false);
	}

    void PlayGameButton_Clicked()
    {
        ApplicationController.Main.StartNewGame();
    }

    void InstructionsButton_Clicked()
    {
        //ApplicationController.Main.FadeIn();
        //Debug.Log("InstructionsButton_Clicked");
        ApplicationController.Main.ShowScene(ApplicationController.Main.InstructionsPrefab);
    }
}
