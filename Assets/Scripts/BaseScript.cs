using UnityEngine;
using System.Collections;

public class BaseScript: MonoBehaviour {

    public float MoveDistance = .4f;
    public float MoveTime = .4f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Move(int x, int y)
    {
        iTween.MoveBy(gameObject, new Vector3(x * MoveDistance, y * MoveDistance, 0), MoveTime);
    }

    void MoveRight()
    {
        Move(1, 0);
    }

    void MoveUp()
    {
        Move(0, 1);
    }

    void MoveLeft()
    {
        Move(-1, 0);
    }

    void MoveDown()
    {
        Move(0, -1);
    }
}
