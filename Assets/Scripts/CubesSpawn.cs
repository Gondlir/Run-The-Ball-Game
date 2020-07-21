using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CubesSpawn : MonoBehaviour
{
	[SerializeField] private GameObject[] cubesToSpawn;
	public int numbersToSpawnTheObjects;
	public int linePositionX; // posição da grid no plano X
	public int linePositionZ; // posição da grid no plano Z
	public float cubesPositionOffSet; // distancia dos cubos
	public Vector3 originPosition = Vector3.zero;
	public static CubesSpawn instance;
	private RaycastNoOverlapBehaviour raycastScript;
	void Start()
	{
		instance = this;
        for (int i = 0; i < numbersToSpawnTheObjects; i++)
        {
			SpawnCubes();
			Debug.Log("chamou");
		}	
	}

	public void SpawnCubes()
	{
		originPosition.x = Random.Range(-7.5f, 10.50f);
		originPosition.z = Random.Range(30, 400);
		
		linePositionX = Random.Range(0, 8);
		linePositionZ = Random.Range(0, 6);

		for (int i = 0; i < linePositionX; i++)
		{
			for (int j = 0; j < linePositionZ; j++)
			{
				Vector3 spawnPositi = new Vector3(i * cubesPositionOffSet, 0, j * cubesPositionOffSet) + originPosition;
				SpawnObjects(spawnPositi, Quaternion.identity);
			}
		}	
	}

	public void SpawnObjects(Vector3 positionToSpawn, Quaternion rotationToSpawn)
	{
		int randomIndex = Random.Range(0, cubesToSpawn.Length);
		GameObject cloneObj = Instantiate(cubesToSpawn[randomIndex], positionToSpawn, rotationToSpawn);
	}
}
