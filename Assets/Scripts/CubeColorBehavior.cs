using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeColorBehavior : MonoBehaviour
{
    private MeshRenderer _renderer;
    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<MeshRenderer>();
    }

    public void ChangeColor()
    {
        _renderer.material.color = Color.red;
    }
}
