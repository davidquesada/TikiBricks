using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Collections;

class LevelControllerBase : Controller
{
    //public float BallDieTime = .6f;

    //public static LevelControllerBase Main;

    //public Transform ScoreIndicatorObject;
    //public Transform LivesIndicatorObject;
    //public Transform LevelIndicatorObject;
    //public Transform MoveLeftButtonObject;
    //public Transform MoveRightButtonObject;
    //public Transform PaddleObject;

    //public Transform TapToStartButtonObject;

    //protected PrefixedTextComponent scoreIndicator;
    //protected PrefixedTextComponent livesIndicator;
    //protected PrefixedTextComponent levelIndicator;
    //protected MoveButton moveLeftButton;
    //protected MoveButton moveRightButton;
    //protected Paddle paddle;

    //protected Ball ball;

    //public Transform BallPrefab;

    //public LevelState State = LevelState.Idle;

    //private List<Brick> AliveBricks = new List<Brick>();

    //#region Model

    //static int Lives = 0;
    //static int Score = 0;

    //#endregion

    //void Start()
    //{
        
    //}

    //protected IEnumerator ResetBall()
    //{
    //    yield return new WaitForSeconds(.01f);

    //    UnityEngine.Object obj = GameObject.Instantiate(BallPrefab.gameObject, paddle.transform.position + Vector3.up * .6f, Quaternion.identity);// as Ball;


    //    State = LevelState.Idle;

    //    yield return new WaitForSeconds(.01f);

    //    ball = ((GameObject)obj).GetComponent<Ball>();
    //    ball.transform.parent = gameObject.transform;

    //    Utility.SetVisible(TapToStartButtonObject.gameObject, true);

    //    yield return null;
    //}

    //protected void CommonStart()
    //{
    //    LoadObjects();
    //    StartCoroutine(ResetBall());
    //    ApplicationController.Main.FadeIn();
    //}

    //protected void ResetLevelController()
    //{
    //    Lives = 3;
    //    Score = 0;
    //}

    //void Update()
    //{
        
    //}

    

    //protected void CommonUpdate()
    //{
    //    livesIndicator.SetValue(Lives);
    //    scoreIndicator.SetValue(Score);

    //    if (AliveBricks.Count == 0)
    //    {
    //        if (State != LevelState.Won)
    //            OnWin();
    //    }
    //    if (Lives == 0)
    //    {
    //        // TODO: You just lost the game.
    //    }

    //    Touch[] touches = Input.touches;

    //    Direction dir = Direction.None; 

    //    if (Input.GetMouseButton(0))
    //    {
    //        //Touch t = touches[i];
    //        //Ray r = Camera.main.ScreenPointToRay(t.position);
    //        Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);


    //        foreach (var item in Physics.RaycastAll(r))
    //        {
    //            MoveButton b = item.collider.gameObject.GetComponent<MoveButton>();

    //            if (b != null)
    //            {
    //                if (b.isRight)
    //                    dir = Direction.Right;
    //                else
    //                    dir = Direction.Left;
    //            }
    //        }
    //    }

    //    for (int i = 0; i < touches.Length; i++)
    //    {
    //        Touch t = touches[i];
    //        Ray r = Camera.main.ScreenPointToRay(t.position);


    //        foreach (var item in Physics.RaycastAll(r))
    //        {
    //            MoveButton b = item.collider.gameObject.GetComponent<MoveButton>();

    //            if (b != null)
    //            {
    //                if (b.isRight)
    //                    dir = Direction.Right;
    //                else
    //                    dir = Direction.Left;
    //            }
    //        }
    //    }

    //    if (Input.GetKey(KeyCode.LeftArrow))
    //        dir = Direction.Left;
    //    else if (Input.GetKey(KeyCode.RightArrow))
    //        dir = Direction.Right;

    //    paddle.MovingDirection = dir;

    //    switch (dir)
    //    {
    //        case Direction.Left:
    //            moveLeftButton.buttonIsPressed = true;
    //            moveRightButton.buttonIsPressed = false;
    //            break;
    //        case Direction.None:
    //            moveLeftButton.buttonIsPressed = false;
    //            moveRightButton.buttonIsPressed = false;
    //            break;
    //        case Direction.Right:
    //            moveLeftButton.buttonIsPressed = false;
    //            moveRightButton.buttonIsPressed = true;
    //            break;
    //        default:
    //            break;
    //    }
    //}

    //private void OnWin()
    //{
    //    State = LevelState.Won;
    //    Debug.Log("You won the game.");
    //}

    //void FixedUpdate()
    //{
        
    //}

    //protected void CommonFixedUpdate()
    //{

    //}

    //protected void LoadObjects()
    //{
    //    levelIndicator = LevelIndicatorObject.GetComponent<PrefixedTextComponent>();
    //    scoreIndicator = ScoreIndicatorObject.GetComponent<PrefixedTextComponent>();
    //    livesIndicator = LivesIndicatorObject.GetComponent<PrefixedTextComponent>();
    //    moveLeftButton = MoveLeftButtonObject.GetComponent<MoveButton>();
    //    moveRightButton = MoveRightButtonObject.GetComponent<MoveButton>();
    //    paddle = PaddleObject.GetComponent<Paddle>();
    //}

    //internal void OnBoundaryCollision(GamePiece g, BoundaryType Type)
    //{
    //    Ball b = g as Ball;
    //    if (b != null)
    //    {
    //        if (Type == BoundaryType.Bottom)
    //        {
    //            // TODO: Take off a life here.
    //            iTween.PunchScale(LivesIndicatorObject.gameObject, new Vector3(1.2f, 1.2f, 1.2f), .4f);
    //            iTween.FadeTo(ball.gameObject, 0.0f, BallDieTime);
    //            iTween.ScaleTo(ball.gameObject, new Vector3(0, 0, 0), BallDieTime);
    //            DestroyObject(ball, BallDieTime);

    //            Lives--;

    //            if (Lives > 0)
    //                StartCoroutine(ResetBall());
                
    //        } else
    //            b.OnBoundaryCollision(Type);
    //    }
    //}

    //internal void OnBrickDestroyed(Brick brick)
    //{
    //    Score += brick.PointValue;
    //    iTween.PunchScale(ScoreIndicatorObject.gameObject, new Vector3(1.1f, 1.1f, 1.1f), 0.5f);
    //    AliveBricks.Remove(brick);
    //}

    //public void AddBrick(Brick b)
    //{
    //    if (!AliveBricks.Contains(b))
    //        AliveBricks.Add(b);
    //}

    //protected void TapToStartButton_Clicked()
    //{
    //    Debug.Log("TapToStartButton_Clicked");
    //    ball.Launch();
    //    State = LevelState.Playing;
    //    Utility.SetVisible(TapToStartButtonObject.gameObject, false);
    //}
}