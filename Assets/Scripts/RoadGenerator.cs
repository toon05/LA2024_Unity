using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class RoadGenerator : MonoBehaviour
{
    [SerializeField] private GameObject loadPrefab;
    float roadPositionZ = 0;
    int[] roadPositionY = {8, 10, 12};
    private List<GameObject> roadInstances = new List<GameObject>();

    [SerializeField] GameObject player;

    [SerializeField] private GameObject itemPrefab;
    private List<GameObject> itemInstances = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            roadInstances.Add(Instantiate(loadPrefab, new Vector3(0, 12, roadPositionZ), Quaternion.identity));
            roadInstances.Add(Instantiate(loadPrefab, new Vector3(0, -12, roadPositionZ), Quaternion.identity));
            roadPositionZ += loadPrefab.transform.localScale.z;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (roadInstances.Count < 40)
        {
            GenerateRoad();
        }
        DestroyRoadPrefabs();
        DestroyItemPrefabs();
    }

    void GenerateRoad()
    {
        int randomPositionY = RandomPositionY();
        roadInstances.Add(Instantiate(loadPrefab, new Vector3(0, randomPositionY, roadPositionZ), Quaternion.identity));
        float bottomPositionY = GetBottomPosition(roadInstances[roadInstances.Count - 1].transform).y;
        GenerateItem(bottomPositionY - 1);

        randomPositionY = RandomPositionY();
        roadInstances.Add(Instantiate(loadPrefab, new Vector3(0, -randomPositionY, roadPositionZ), Quaternion.identity));
        float topPositionY = GetTopPosition(roadInstances[roadInstances.Count - 1].transform).y;
        GenerateItem(topPositionY + 1);

        roadPositionZ += loadPrefab.transform.localScale.z;
    }

    void GenerateItem(float positionY)
    {
        float randomValue = Random.Range(0f, 100f);

        if (randomValue < 10)
        {
            itemInstances.Add(Instantiate(itemPrefab, new Vector3(0, positionY, roadPositionZ), Quaternion.identity));
        }
    }

    int RandomPositionY()
    {
        int randomIndex = Random.Range(0, roadPositionY.Length);
        int randomPositionY = roadPositionY[randomIndex];
        return randomPositionY;
    }

    void DestroyRoadPrefabs()
    {
        // 削除対象を一時的に保持するリスト
        List<GameObject> roadsToRemove = new List<GameObject>();

        foreach (var roadInstance in roadInstances)
        {
            if (roadInstance.transform.position.z < player.transform.position.z - 20)
            {
                roadsToRemove.Add(roadInstance);
            }
        }

        // ループが終わった後に削除処理を行う
        foreach (var roadInstance in roadsToRemove)
        {
            roadInstances.Remove(roadInstance);
            Destroy(roadInstance);
        }
    }
    
    void DestroyItemPrefabs()
    {
        // 削除対象を一時的に保持するリスト
        List<GameObject> itemsToRemove = new List<GameObject>();

        foreach (var itemInstance in itemInstances)
        {
            if (itemInstance.transform.position.z < player.transform.position.z - 20)
            {
                itemsToRemove.Add(itemInstance);
            }
        }

        // ループが終わった後に削除処理を行う
        foreach (var itemInstance in itemsToRemove)
        {
            itemInstances.Remove(itemInstance);
            Destroy(itemInstance);
        }
    }

    // Cubeの上端の座標を取得するメソッド
    Vector3 GetTopPosition(Transform cubeTransform)
    {
        // Cubeの中心座標
        Vector3 cubeCenter = cubeTransform.position;
        
        // Cubeのローカルスケール（サイズ）
        float cubeHeight = cubeTransform.localScale.y;
        
        // 上端のY座標は中心からスケールの半分だけ上に移動
        Vector3 topPosition = cubeCenter + new Vector3(0, cubeHeight / 2, 0);
        
        return topPosition;
    }

    // Cubeの下端の座標を取得するメソッド
    Vector3 GetBottomPosition(Transform cubeTransform)
    {
        // Cubeの中心座標
        Vector3 cubeCenter = cubeTransform.position;
        
        // Cubeのローカルスケール（サイズ）
        float cubeHeight = cubeTransform.localScale.y;
        
        // 下端のY座標は中心からスケールの半分だけ下に移動
        Vector3 bottomPosition = cubeCenter - new Vector3(0, cubeHeight / 2, 0);
        
        return bottomPosition;
    }
}
