using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PackedSprite))]
[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
[ExecuteInEditMode()]
public class Brick : MonoBehaviour {

    public float DestroyTime = .4f;

    public BrickState State = BrickState.Red;
    public int PointValue = 100;

    //TODO: Static?
    public float Ratio = 0.5f; // height / width

    PackedSprite spr;

	// Use this for initialization
	void Start () {
        spr = gameObject.GetComponent<PackedSprite>();
        LevelController.Main.AddBrick(this);
	}
	
	// Update is called once per frame
	void Update () {
        spr.DoAnim((int)State);
	}

    void FixedUpdate()
    {
        // This doesn't need to be called quite as often as the per-frame
        // update. idk, This might make the game slightly more performant
        // on the demo phone.
//        spr.DoAnim(CurrentAnimation);
    }

    void OnTriggerEnter(Collider other)
    //void OnCollisionEnter(Collision other)
    {
        Ball ball = other.gameObject.GetComponent<Ball>();

        if (ball != null)
        {
            float dx = ball.transform.position.x - transform.position.x;
            float dy = ball.transform.position.y - transform.position.y;

            Ratio = 1.0f * transform.localScale.y / transform.localScale.x;

            float slope = dy / dx; // DERIVATIVE FTW!

            if (Mathf.Abs(slope) < Ratio)
                // Horizontal reflection
                ball.rigidbody.velocity = Vector3.Reflect(ball.rigidbody.velocity, Vector3.right);
            else
                // Vertical Reflection
                ball.rigidbody.velocity = Vector3.Reflect(ball.rigidbody.velocity, Vector3.up);

             //ball.rigidbody.velocity = Vector3.Reflect(ball.rigidbody.velocity, transform.position - ball.transform.position);

            

            if (State != BrickState.Stone)
            {
                iTween.ScaleTo(gameObject, new Vector3(0, 0, 0), DestroyTime);
                iTween.FadeTo(gameObject, 0.0f, DestroyTime);

                LevelController.Main.OnBrickDestroyed(this);
                Destroy(gameObject, DestroyTime);

                PointValue = 0;
            }
            else
                State = BrickState.CrackedStone;
        }
    }
}
