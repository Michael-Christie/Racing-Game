using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Envioment : MonoBehaviour
{
    public static Envioment instance;
    [Header("Colors")]
    public Material material;
    public Color[] baseColors;
    [Range(0,1)]
    public float[] baseStartHeights;
    public float[] baseBlends;

    public LayerMask raceMask;
    bool[,] map;
    float[,] heightMap;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    public IEnumerator CreateLandscape(int width, int height)
    {
        map = new bool[width, height];
        heightMap = new float[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                Ray ray = new Ray(new Vector3(x * 2, 10, z * 2) - (new Vector3(width * 2, 0, height * 2) * .5f), Vector3.down);
                Debug.DrawRay(ray.origin, ray.direction, Color.white, 10f);

                map[x, z] = Physics.Raycast(ray, 30, raceMask) ? true : false;

                heightMap[x, z] = -1;
            }
        }

        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                if (map[x, z])
                {
                    heightMap[x, z] = 0;
                    heightMap[x + 1, z] = 0;
                    heightMap[x - 1, z] = 0;
                    heightMap[x, z + 1] = 0;
                    heightMap[x, z - 1] = 0;
                }
            }
        }

        ////recursively
        for (int i = 0; i < 20; i++)
        {
            float[,] lastMap = new float[width, height];
            System.Array.Copy(heightMap, lastMap, width * height);

            Debug.Log(lastMap.Length);
            Debug.Log(heightMap.Length);

            for (int x = 1; x < width - 1; x++)
            {
                for (int z = 1; z < height - 1; z++)
                {
                    if (lastMap[x, z] < 0)
                    {
                        float average = 0;
                        int num = 0;

                        if (lastMap[x - 1, z] >= 0)
                        {
                            num++;
                            average += lastMap[x - 1, z];
                        }

                        if (lastMap[x + 1, z] >= 0)
                        {
                            num++;
                            average += lastMap[x + 1, z];
                        }

                        if (lastMap[x, z - 1] >= 0)
                        {
                            num++;
                            average += lastMap[x, z - 1];
                        }

                        if (lastMap[x, z + 1] >= 0)
                        {
                            num++;
                            average += lastMap[x, z + 1];
                        }

                        if (num > 0)
                        {
                            average /= num;

                            heightMap[x, z] = average + ( i < 18 ? (Random.value * 2) : 0);// - .5f; //Mathf.PerlinNoise(x *.05f,z * .05f);
                        }
                    }
                }
            }

            yield return new WaitForSeconds(.1f);
            FindObjectOfType<GameStart>().UpdateLoadingValue(1);
        }

        List<Vector3> verts = new List<Vector3>();
        //verts
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                float h = heightMap[x, z];
                 
                if (h < 0)
                    Debug.Log("Value is less than 0");
                if (h == 0)
                    h = -.3f;

                verts.Add(new Vector3(x * 2, h, z * 2) - (new Vector3(width * 2, 0, height * 2) * .5f));
            }
        }
        yield return new WaitForSeconds(.1f);
        FindObjectOfType<GameStart>().UpdateLoadingValue(1);
        List<int> tri = new List<int>();
        //tris
        for (int x = 0; x < width - 1; x++)
        {
            for (int z = 0; z < height - 1; z++)
            {
                tri.Add(x + (z * width));
                tri.Add((x + 1) + (z * width));
                tri.Add(x + ((z + 1) * width));

                tri.Add(x + ((z + 1) * width));
                tri.Add((x + 1) + (z * width));
                tri.Add((x + 1) + ((z + 1) * width));
            }
        }

        yield return new WaitForSeconds(.1f);
        FindObjectOfType<GameStart>().UpdateLoadingValue(1);
        Mesh m = new Mesh();
        m.SetVertices(verts.ToArray());
        m.SetTriangles(tri.ToArray(), 0);
        m.RecalculateNormals();

        //gameObject.AddComponent<MeshRenderer>();
        gameObject.AddComponent<MeshFilter>().mesh = m;
        gameObject.AddComponent<MeshCollider>().sharedMesh = m;

        transform.position = new Vector3(0, 1.2f, 0);
        gameObject.isStatic = true;

        ApplyToMaterial();
        FindObjectOfType<GameStart>().UpdateLoadingValue(1);
    }

    private void OnDrawGizmos()
    {
        if (map != null)
        {
            for (int x = 0; x < map.GetLength(0); x++)
            {
                for (int z = 0; z < map.GetLength(1); z++)
                {
                    if (heightMap[x, z] != 0)
                        Gizmos.DrawCube(new Vector3(x * 5, 10, z * 5) - (new Vector3(map.GetLength(0) * 5, 0, map.GetLength(1) * 5) * .5f), Vector3.one);
                }
            }
        }
    }

    void ApplyToMaterial()
    {
        material.SetInt("baseColorCount", baseColors.Length);
        material.SetColorArray("baseColors", baseColors);
        material.SetFloatArray("baseStartHeight", baseStartHeights);
        material.SetFloatArray("baseBlends", baseBlends);
    }
}
