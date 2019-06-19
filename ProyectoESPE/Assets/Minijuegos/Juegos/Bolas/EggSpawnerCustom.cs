using UnityEngine;
using System.Collections;

public class EggSpawnerCustom : MonoBehaviour 
{
	[Tooltip("Index of the player, tracked by this component. 0 means the 1st player, 1 - the 2nd one, 2 - the 3rd one, etc.")]
	public int playerIndex = 0;

	[Tooltip("Prefab (model and components) used to instantiate eggs in the scene.")]
    public Transform eggPrefab;

    private float nextEggTime = 0.0f;
    private float spawnRate = 1.5f;

	private int balls=0;
	private float timeRate=0f;

	public KinectManager manager;
 	
	void Update () 
	{
        if (nextEggTime < Time.time)
        {
            SpawnEgg();
			nextEggTime = Time.time + spawnRate;

            spawnRate = Mathf.Clamp(spawnRate, 0.3f, 99f);
        }
	}

	public KinectManager GetKinectManager(){
		return manager;
	}

    void SpawnEgg()
    {
		manager = KinectManager.Instance;

		if(eggPrefab && manager && manager.IsInitialized() && manager.IsUserDetected(playerIndex))
		{
			long userId = manager.GetUserIdByIndex(playerIndex);
			Vector3 posUser = manager.GetUserPosition(userId);

			float addXPos = Random.Range(-4f, 4f);
			Vector3 spawnPos = new Vector3(addXPos, 6.5f, posUser.z);
			
			Transform eggTransform = Instantiate(eggPrefab, spawnPos, Quaternion.identity) as Transform;
			eggTransform.parent = transform;	
			balls++;
			Debug.Log (balls);
			spawnRate = spawnRate - 0.1f;
		}
    }

}
