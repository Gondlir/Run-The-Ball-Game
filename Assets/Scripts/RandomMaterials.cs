using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class RandomMaterials : MonoBehaviour {

	[SerializeField] private MeshRenderer[] renderersArray; 
	[SerializeField] private MeshRenderer renderersStart; 
	void Start () 
	{
		//Color myColor = Random.ColorHSV();
		Color myColor = Random.ColorHSV(0f, .5f);
		//Color myColor = Random.ColorHSV(0f, .25f, 0.4f, .1f);
		//ApplyColor(myColor, 0);
		StartColor(myColor, 0);
	}


	private void ApplyColor(Color color, int index) 
	{
		Material generateMaterial = new Material(Shader.Find("Standard"));
		generateMaterial.SetColor("_Color", color);
        for (int i = 0; i < renderersArray.Length; i++)
        {
			renderersArray[i].material = generateMaterial;
        }
	}
	private void StartColor(Color color, int index) 
	{
		Material generateMaterial = new Material(Shader.Find("Standard"));
		generateMaterial.SetColor("_Color", color);
		renderersStart.material = generateMaterial;
	}
}
