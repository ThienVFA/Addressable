using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class SpawnAddressableObject : MonoBehaviour
{

    #region Methods
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            AsyncOperationHandle<GameObject> asyncOperationHandle =
                Addressables.LoadAssetAsync<GameObject>("Assets/Prefabs/YellowCube.prefab");

            asyncOperationHandle.Completed += LoadCudeComplete;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            AsyncOperationHandle<GameObject> asyncOperationHandle =
                Addressables.LoadAssetAsync<GameObject>("RedCube");

            asyncOperationHandle.Completed += LoadCudeComplete;
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            Addressables.LoadAssetsAsync<GameObject>("Cube", (cube) =>
            {
                Debug.Log(cube.name);
            });
        }
    }

    private void LoadCudeComplete(AsyncOperationHandle<GameObject> asyncOperationHandle )
    {
        if(asyncOperationHandle.Status == AsyncOperationStatus.Succeeded)
        {
            Instantiate(asyncOperationHandle.Result);
        }
        else
        {
            Debug.Log("Load fail.");
        }
        
        Test(100);
        Test(50);
        Test(20);
        Test(120);
    }

    async void Test(int time)
    {
        await System.Threading.Tasks.Task.Delay(time);

        Debug.Log($"Case {time}");
    }

    #endregion
}
