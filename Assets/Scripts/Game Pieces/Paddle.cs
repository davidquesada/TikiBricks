using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PackedSprite))]
[RequireComponent(typeof(BoxCollider))]
//[RequireComponent(typeof(Rigidbody))]
public class Paddle : MonoBehaviour {

    public float Speed = .06f;
    public float NudgeSpeed = 0;//10.0f;

    public Transform ReflectionPointObject;

    private enum PaddleState
    {
        Left,
        Middle,
        Right
    }

    private PaddleState State = PaddleState.Middle;

    public Direction MovingDirection = Direction.None;

	// Use this for initialization
	void Start () {
	
	}

    public void MovePaddle(Direction d)
    {
        float displacement = 0;

        if (d == Direction.Left && State != PaddleState.Left)
            displacement = -1 * Speed;
        else if (d == Direction.Right && State != PaddleState.Right)
            displacement = Speed;

        transform.Translate(displacement, 0, 0);
            
    }
	
	// Update is called once per frame
	void Update () {

        MovePaddle(MovingDirection);
        return;
        float displacement = Input.GetAxis("Horizontal");
        displacement *= Speed * Time.deltaTime;

        switch (State)
        {
            case PaddleState.Left:
                displacement = Mathf.Max(NudgeSpeed * Time.deltaTime, displacement);
                break;
            case PaddleState.Middle:
                break;
            case PaddleState.Right:
                displacement = Mathf.Min(-1 * NudgeSpeed * Time.deltaTime, displacement);
                break;
            default:
                break;
        }

        //rigidbody.velocity

        //Physics.Raycast(new Ray(

        Vector3 v = rigidbody.velocity;
        v.x = displacement;
        //rigidbody.velocity = v;
        //rigidbody.AddForce(displacement, 0, 0, ForceMode.VelocityChange);

        transform.Translate(displacement, 0, 0);
	}

    public void OnBoundary(BoundaryType type)
    {
        Debug.Log("OnBoundary");

        switch (type)
        {
            case BoundaryType.Top:
                break;
            case BoundaryType.Bottom:
                break;
            case BoundaryType.Left:
                State = PaddleState.Left;
                break;
            case BoundaryType.Right:
                State = PaddleState.Right;
                break;
            default:
                break;
        }
    }

    public void LeaveBoundary()
    {
        State = PaddleState.Middle;
    }

    void OnTriggerEnter(Collider other)
    {
        Ball b = other.gameObject.GetComponent<Ball>();

        if (b != null)
        {
            if (b.rigidbody.velocity.y < 0)
            {
                Vector3 normalVector = b.transform.position - ReflectionPointObject.transform.position;
                float mag = b.rigidbody.velocity.magnitude;
                normalVector.z = 0;
                //b.rigidbody.velocity
                normalVector = Vector3.Reflect(b.rigidbody.velocity, normalVector);//Vector3.up);
                normalVector = normalVector.normalized * mag;
                b.rigidbody.velocity = normalVector;
            }
        }
    }
}
