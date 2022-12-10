using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoSingleton<ObjectPooler>
{
    public Texture2D levelTexture;
    public LevelPixel[] pixels;
    public Queue<GameObject> objectPool;

    private void Start()
    {
        objectPool = new Queue<GameObject>();
        GenerateLevel();

    }

    public void GenerateLevel()
    {
        int width = levelTexture.width;
        int height = levelTexture.height;

        GameObject container = new GameObject("Level");

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Color pixel = levelTexture.GetPixel(x, y);

                foreach (LevelPixel levelPixel in pixels)
                {
                    if (pixel == levelPixel.pixel)
                    {
                        GameObject obj = Instantiate(levelPixel.spawnToObject, new Vector3(x, y), Quaternion.identity, container.transform);
                        objectPool.Enqueue(obj);
                    }

                }
            }
        }
    }

    public GameObject GetPooledObject()
    {
        GameObject objectToSpawn = objectPool.Dequeue();
        objectToSpawn.SetActive(true);
        return objectToSpawn;
    }
}
