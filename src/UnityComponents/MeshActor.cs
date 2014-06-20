using UnityEngine;
using System.Collections;

[System.Serializable]
public class MeshActor : Actor
{
    public Vector3 skewAngles1;
    public Vector3 skewAngles2;
    protected Vector3 angles1prev = Vector3.zero;
    protected Vector3 angles2prev = Vector3.zero;
    protected const float coeff = Mathf.PI/180;
    protected Mesh mesh;
    protected Vector3[] initialState;

    void Awake()
    {
        mesh = gameObject.GetComponent<MeshFilter>().mesh;
        initialState = mesh.vertices;
    }

    protected void Update()
    {
        base.Update();
        if (skewAngles1 != angles1prev || skewAngles2 != angles2prev)
            updateMesh();
    }

    protected void updateMesh()
    {
        Matrix4x4 m = Matrix4x4.zero;
        m[0, 0] = 1;
        m[1, 1] = 1;
        m[2, 2] = 1;
        m[3, 3] = 1;
        m[0, 1] = Mathf.Tan(skewAngles1.x * coeff); // skewing in xy
        m[0, 2] = Mathf.Tan(skewAngles2.x * coeff); // skewing in xz
        m[1, 0] = Mathf.Tan(skewAngles1.y * coeff); // skewing in yx
        m[1, 2] = Mathf.Tan(skewAngles2.y * coeff); // skewing in yz
        m[2, 0] = Mathf.Tan(skewAngles1.z * coeff); // skewing in zx
        m[2, 1] = Mathf.Tan(skewAngles2.z * coeff); // skewing in zy

        Vector3[] verts = new Vector3[initialState.Length];
        int i = 0;
        while (i < verts.Length)
        {
            verts[i] = m.MultiplyPoint3x4(initialState[i]);
            i++;
        }

        mesh.vertices = verts;
        angles1prev = skewAngles1;
        angles2prev = skewAngles2;
    }
}
