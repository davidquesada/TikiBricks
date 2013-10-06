using System.Collections.Generic;
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteText))]
class PrefixedTextComponent : MonoBehaviour
{

    public string Prefix = "";

    private string text = "";


    public virtual void SetValue(int value)
    {
        text = string.Concat(Prefix, value.ToString());
        //txt.Text = text;
    }

    protected SpriteText txt;

    void Start()
    {
        txt = gameObject.GetComponent<SpriteText>();
    }

    void Update()
    {
        txt.Text = text;
    }

    public void SetColor(Color col)
    {
        txt.color = col;
    }
}