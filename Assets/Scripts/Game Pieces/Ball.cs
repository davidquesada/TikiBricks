using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PackedSprite))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]
public class Ball : GamePiece {

    PackedSprite spr;

    public float LaunchVelocity = .5f;

    // When launching the ball, add/subtract up to .8 radians (about 50')
    public float RandomLaunchAngleOffset = .8f;

	// Use this for initialization
	void Start () {
        spr = gameObject.GetComponent<PackedSprite>();
	}
	
	// Update is called once per frame
    void Update()
    {
    }

    public void Launch()
    {
        if (rigidbody.velocity.sqrMagnitude == 0)
        {
            float angle = Mathf.PI / 2 + Random.Range(-1 * RandomLaunchAngleOffset, RandomLaunchAngleOffset);
            //rigidbody.AddForce(LaunchVelocity * Mathf.Cos(angle), LaunchVelocity * Mathf.Sin(angle), 0, ForceMode.VelocityChange);
            Vector3 v = new Vector3(0, 0, 0);
            v.x = LaunchVelocity * Mathf.Cos(angle);
            v.y = LaunchVelocity * Mathf.Sin(angle);
            rigidbody.velocity = v;
        }
    }

    internal void OnBoundaryCollision(BoundaryType Type)
    {
        //throw new System.NotImplementedException();
    }
}
