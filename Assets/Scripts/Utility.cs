using System.Collections.Generic;
using UnityEngine;

public class Utility
{
    public static void SetVisible(GameObject o, bool visible)
    {
        Vector3 v = o.transform.position;

        if (visible)
            v.z = Mathf.Abs(v.z);
        else
            v.z = -1 * Mathf.Abs(v.z);

        o.transform.position = v;

        Debug.Log("Set Visible " + visible.ToString());
    }
}