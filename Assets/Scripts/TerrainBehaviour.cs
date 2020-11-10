using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainBehaviour : MonoBehaviour 
{
	public int numbersToSpawnTheObjects; //minimo 50

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			transform.position = new Vector3(0, 0, transform.position.z + 527 * 2);
            Debug.Log("Entrou no loop");
			CubesSpawn.instance.SpawnCubes();
			//CubesSpawn.instance.InstantiateNumbersOfTheCubes();
		}
	}
}
