using UnityEngine;
using System.Collections;

public class Boundary : MonoBehaviour {

    public BoundaryType Type;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay(Collider other)
    {
        Ball b = other.gameObject.GetComponent<Ball>();

        if (b != null)
        {
            Vector3 s = b.rigidbody.velocity;

            switch (Type)
            {
                case BoundaryType.Top:
                    s.y = -1 * Mathf.Abs(s.y);
                    break;
                case BoundaryType.Bottom:
                    break;
                case BoundaryType.Left:
                    s.x = Mathf.Abs(s.x);
                    break;
                case BoundaryType.Right:
                    s.x = -1 * Mathf.Abs(s.x);
                    break;
                default:
                    break;
            }

            b.rigidbody.velocity = s;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Paddle p = other.gameObject.GetComponent<Paddle>();

        Ball b = null;
        if (p != null)
        {
            p.OnBoundary(Type);
        }
        else if ((b = other.gameObject.GetComponent<Ball>()) != null)
        {

            int xs = 1;
            int ys = 1;

            switch (Type)
            {
                case BoundaryType.Top:
                    ys = -1;
                    break;
                case BoundaryType.Bottom:
                    Destroy(b.gameObject, 3f);
                    break;
                case BoundaryType.Left:
                    xs = -1;
                    break;
                case BoundaryType.Right:
                    xs = -1;
                    break;
                default:
                    break;
            }

            Vector3 vel = other.rigidbody.velocity;
            vel.x *= xs;
            vel.y *= ys;
            other.rigidbody.velocity = vel;

            GamePiece g = other.gameObject.GetComponent<GamePiece>();
            if (g != null)
                LevelController.Main.OnBoundaryCollision(g, Type);
        }
    }

    void OnTriggerExit(Collider other)
    {
        Paddle p = other.gameObject.GetComponent<Paddle>();

        if (p != null)
        {
            p.LeaveBoundary();
        }
    }
}
