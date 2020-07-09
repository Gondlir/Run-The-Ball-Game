using Boo.Lang.Environments;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeProperties : MonoBehaviour 
{
	public GameObject myCube;
	public Color32 myColor;
	void Start () 
	{
		myColor = gameObject.GetComponent<MeshRenderer>().material.color;
	}
}
