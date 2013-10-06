using UnityEngine;
using System.Collections;

public class ApplicationController: Controller {

    public static ApplicationController Main { get; private set; }

    public ApplicationController()
    {
        Main = this;
    }


    public Controller ActiveController;
    public int CurrentLevel = -1;

    public Transform MenuControllerPrefab;
    public Transform InstructionsPrefab;

    public Transform TapToStartButtonObject;
    public Transform WinPanelObject;
    public Transform LosePanelObject;

    public Transform[] Levels;


    public Transform FadeScreen;

    public float FadeTime = .5f;

	// Use this for initialization
	void Start () {
        OnStart();
	}

    private void LoadMenu()
    {
        MenuController m = ((GameObject)Object.Instantiate(MenuControllerPrefab.gameObject, Vector3.zero, Quaternion.identity)).GetComponent<MenuController>();

        if (m == null)
        {
            Debug.Log("Failed to create menu controller.");
        }
        else
        {
            m.OnStart();
            ActiveController = m;
        }
    }

    public override void OnStart()
    {
        LoadMenu();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    internal void StartNewGame()
    {
        LevelController.ResetLevelController();

        CurrentLevel = -1;
        LoadLevel(++CurrentLevel);
    }

    void StartNewScene(Transform sceneType, bool destroyCurrentScene)
    {
        if (destroyCurrentScene && ActiveController != null)
        {
            ActiveController.OnDestroy();
        }

        Controller c = GameObject.Instantiate(sceneType.gameObject, Vector3.zero, Quaternion.identity) as Controller;

        ActiveController = c;

        ActiveController.OnStart();
    }

    void LoadLevel(int index)
    {
        //StartCoroutine(ShowSceneImpl(index));
        ShowScene(Levels[index]);
    }

    public void ShowScene(Transform scene)
    {
        StartCoroutine(ShowSceneImpl(scene));
    }

    IEnumerator ShowSceneImpl(Transform scene)//int index)
    {
        FadeOut();
        yield return new WaitForSeconds(FadeTime * 1.2f);
        if (ActiveController != null)
        {
            ActiveController.transform.Translate(100, 0, 0);
            //ActiveController.OnDestroy();
            Destroy(ActiveController.gameObject, 5.0f);
        }
        Controller c = ((GameObject)GameObject.Instantiate(scene.gameObject, Vector3.zero, Quaternion.identity)).GetComponent<Controller>();
        if (c == null)
        {
            Debug.Log("Unable to get handle on new controller");
        }
        else
        {
            ActiveController = c;
        }

        yield return new WaitForSeconds(.2f);

        FadeIn();

        yield return null;
    }

    public void FadeOut()
    {
        FadeScreen.position = new Vector3(0, 0, 0.5f);
        iTween.FadeTo(FadeScreen.gameObject, 1.0f, FadeTime);
    }

    public void FadeIn()
    {
        StartCoroutine(FadeInImpl());
    }

    IEnumerator FadeInImpl()
    {
        iTween.FadeTo(FadeScreen.gameObject, 0.0f, FadeTime);
        yield return new WaitForSeconds(FadeTime);
        FadeScreen.Translate(20, 0, 0);
        yield return null;
    }

    /// <summary>
    /// Called whenever a level is won. Derp.
    /// </summary>
    public void OnLevelWin()
    {
        // If this is the last level
        if (CurrentLevel == Levels.Length - 1)
        {
            LevelController.Main.ShowWinScreen();
        }
        else
        {
            CurrentLevel++;
            iTween.ScaleBy(ActiveController.gameObject, new Vector3(3, 3, 1), 1.1f);
            iTween.RotateBy(ActiveController.gameObject, new Vector3(0, 0, 1), 1.1f);
            LoadLevel(CurrentLevel);
        }
    }

    public void ReturnToMenu()
    {
        Utility.SetVisible(WinPanelObject.gameObject, false);
        Utility.SetVisible(LosePanelObject.gameObject, false);
        ShowScene(MenuControllerPrefab);
        Utility.SetVisible(ApplicationController.Main.TapToStartButtonObject.gameObject, false);

    }

    public void TapToStartButton_Clicked()
    {
        LevelController c = ActiveController as LevelController;
        if (c != null)
            c.TapToStartButton_Clicked();
    }
}
