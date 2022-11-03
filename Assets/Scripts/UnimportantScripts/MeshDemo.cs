using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshDemo : MonoBehaviour
{
    [SerializeField] private int zSize;
    [SerializeField] private int ySize;

    [SerializeField] private float deformationRadius = 0.5f;
    [SerializeField] private float deformationScale = 0.05f;
    private Mesh mesh;

    private Vector3[] vertices;
    private int[] triangles;

    private void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        CreateShape();
        UpdateMesh();
    }

    private void OnCollisionEnter(Collision collision)
    {
        bool IsDeformate = false;
        vertices = mesh.vertices;
        for (int i = 0; i < mesh.vertexCount; i++)
        {
            for (int j = 0; j < collision.contacts.Length; j++)
            {
                Vector3 Point = transform.InverseTransformPoint(collision.contacts[j].point);
                Vector3 Force = transform.InverseTransformVector(collision.relativeVelocity);
                float Distance = Vector3.Distance(Point, vertices[i]);
                if (Distance < deformationRadius)
                {
                    Vector3 Deformate = Force * (deformationRadius - Distance) * deformationScale;
                    vertices[i] += Deformate;
                    IsDeformate = true;
                }

            }
        }

        if (IsDeformate)
        {
            UpdateMesh();
        }
    }

    private void CreateShape()
    {
        vertices = new Vector3[(zSize + 1 ) * (ySize + 1)];
        triangles = new int[zSize * ySize * 6];


        for (int i = 0, z = 0; z <= zSize; z++)
        {
            for (int y = 0; y <= ySize; y++)
            {
                vertices[i] = new Vector3(0, y/10, z/10);;
                i++;
            }
        }

        for (int vert = 0, tris = 0, y = 0; y < ySize; y++)
        {
            for (int z = 0; z < zSize; z++)
            {

                triangles[tris] = vert;
                triangles[tris + 1] = triangles[tris + 4] = vert + zSize + 1;
                triangles[tris + 2] = triangles[tris + 3] = vert + 1;
                triangles[tris + 5] = vert + zSize + 2;

                vert++;
                tris += 6;
            }
            vert++;
        }
        
    }

    private void UpdateMesh()
    {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
        GetComponent<MeshCollider>().sharedMesh = mesh;
    }

}
