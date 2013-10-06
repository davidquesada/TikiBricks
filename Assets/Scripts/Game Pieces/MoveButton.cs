using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(PackedSprite))]
//[RequireComponent(typeof(
public class MoveButton : MonoBehaviour
{
    public bool isRight = false;

    public bool buttonIsPressed = false;

    PackedSprite spr;

    void Start()
    {
        spr = gameObject.GetComponent<PackedSprite>();
    }

    public void Update()
    {
        if (isRight)
        {
            if (!buttonIsPressed)
                spr.DoAnim(1);
            else
                spr.DoAnim(3);
        }
        else
        {
            if (!buttonIsPressed)
                spr.DoAnim(0);
            else
                spr.DoAnim(2);
        }
    }
}
