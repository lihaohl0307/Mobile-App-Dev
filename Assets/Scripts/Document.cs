using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Document
{
    public string title;
    public string content;
    private string v;

    public Document(string v)
    {
        this.v = v;
    }

    public Document(string title, string content)
    {
        this.title = title;
        this.content = content;
    }
}
