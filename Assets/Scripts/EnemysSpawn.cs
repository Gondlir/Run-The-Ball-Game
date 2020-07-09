using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class EnemysSpawn : MonoBehaviour {

	[SerializeField] private GameObject[] enemysToSpawn;
	public int linePositionX = 0; // posição da grid no plano X
	public int linePositionZ = 0; // posição da grid no plano Z
	public float cubesPositionOffSet = 1f; // distancia dos cubos
	public Vector3 originPosition = Vector3.zero;
	public Vector3 randonPosition;
	
	void Start () 
	{
		SpawnEnemies();
	}
	void SpawnEnemies()
	{
		originPosition.z = Random.Range(25, 100);
		linePositionX = Random.Range(0, 10);
		linePositionZ = Random.Range(0,7);
                
		for (int i = 0; i < linePositionX; i++)
		{
			for (int j = 0; j < linePositionZ; j++)
			{
				Vector3 spawnPositi = new Vector3(i * cubesPositionOffSet, 0, j * cubesPositionOffSet) + originPosition;
				SpawnEnemy(spawnPositi, Quaternion.identity);
			}
		}						
	}
	Vector3 RandonPositions(Vector3 position) 
	{
		Vector3 randonPos = new Vector3(originPosition.x, originPosition.y, Random.Range(-originPosition.z, originPosition.z));
		return randonPos;
	}
		
	void SpawnEnemy(Vector3 positionToSpawn, Quaternion rotationToSpawn)
	{
		int randomIndex = Random.Range(0, enemysToSpawn.Length);
		GameObject cloneObj = Instantiate(enemysToSpawn[randomIndex], positionToSpawn, rotationToSpawn);
	}
}
