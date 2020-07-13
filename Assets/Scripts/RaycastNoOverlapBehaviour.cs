using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastNoOverlapBehaviour : MonoBehaviour 
{

	[SerializeField] private GameObject[] items;
	[SerializeField] private LayerMask spawnObjtLayer;
	public float raycastDistance = 100f;
	public float overLapBoxSize;
	public static RaycastNoOverlapBehaviour instance;

	void Start () 
	{
		instance = this;
		RayCastPosition();
	}
	public void RayCastPosition() 
	{
		Debug.Log("entrou no método");
		RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, raycastDistance))
        {
			Quaternion objRotation = Quaternion.FromToRotation(Vector3.up, hit.normal);

			Vector3 overlapBoxScale = new Vector3(overLapBoxSize, overLapBoxSize, overLapBoxSize);
			Collider[] colliderInsideOverlapBox = new Collider[1];
			int numberofCollidersFound = Physics.OverlapBoxNonAlloc(hit.point, overlapBoxScale, colliderInsideOverlapBox, objRotation, spawnObjtLayer);
			Debug.Log("Number of Colliders = " + numberofCollidersFound);
            if (numberofCollidersFound == 0)
            {
				Debug.Log("spawned");
				//CubesSpawn.instance.SpawnObjects(hit.point, Quaternion.identity);
			}
            else
            {
				Debug.Log("name of collider = " + colliderInsideOverlapBox[0].name);
            }
        }
	}
}
