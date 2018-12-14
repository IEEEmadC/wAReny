using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
class SerializableMeshInfo : MonoBehaviour
{
    //[SerializeField]
    [SaveMember]public List<Vector3> vertices;
    //[SerializeField]
    [SaveMember]public List<int> triangles;
    //[SerializeField] 
    [SaveMember]public int submeshCount;
    //[SerializeField]
    [SaveMember]public List<Vector2> uv;
    //[SerializeField]
    [SaveMember]public List<Vector2> uv2;
    //[SerializeField]
    [SaveMember]public List<Vector3> normals;
    //[SerializeField]
    [SaveMember]public List<Color> colors;
    [SaveMember] public bool islsaved;
    [DontSaveMember] public Mesh myMesh;

    private void Awake()
    {
        myMesh = GetComponent<MeshFilter>().mesh;
    }

    private void Start()
    {
        if (islsaved)
        {
            print("LOaded");
            GetComponent<MeshFilter>().mesh = GetMesh();
            islsaved = false;
        }
    }
    public void SerializeMeshInfo(Mesh m) // Constructor: takes a mesh and fills out SerializableMeshInfo data structure which basically mirrors Mesh object's parts.
    {
        
        m.GetVertices(vertices);
        submeshCount = m.subMeshCount;
        m.GetTriangles(triangles,0);
        m.GetUVs(0,uv);
        m.GetUVs(1,uv2);
        m.GetNormals(normals);
        m.GetColors(colors);
        islsaved = true;
    }

    // GetMesh gets a Mesh object from currently set data in this SerializableMeshInfo object.
    // Sequential values are deserialized to Mesh original data types like Vector3 for vertices.
    public Mesh GetMesh()
    {
        Mesh m = new Mesh();      
        m.SetVertices(vertices);
        m.SetTriangles(triangles,0);
        m.SetUVs(0, uv);       
        m.SetUVs(1, uv2);
        m.SetNormals(normals);
        m.SetColors(colors);

        return m;
    }
}