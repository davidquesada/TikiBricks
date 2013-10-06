using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public virtual void OnStart()
    {
    }

    /// <summary>
    /// Called whenever a "scene" needs to be destroyed. This method is also
    /// responsible for destroying the scene container.
    /// </summary>
    public virtual void OnDestroy()
    {
    }
}
