using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRoot : MonoBehaviour
{

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start()
    {
        GameModel.MakeArea();

    }

    // Update is called once per frame
    void Update()
    {

    }
}