using UnityEngine;
using System.Collections;

[System.Serializable]
public class SkewModifier : MonoBehaviour
{
    public Vector3 angles1;
    public Vector3 angles2;
    protected Vector3 angles1prev = Vector3.zero;
    protected Vector3 angles2prev = Vector3.zero;
    protected const float coeff = Mathf.PI/180;

    void Update()
    {
        if (angles1 != angles1prev || angles2 != angles2prev)
            updateMesh();
    }

    protected void updateMesh()
    {
        Matrix4x4 m = Matrix4x4.zero;
        m[0, 0] = 1;
        m[1, 1] = 1;
        m[2, 2] = 1;
        m[3, 3] = 1;
        m[0, 1] = Mathf.Tan(angles1.x * coeff) - Mathf.Tan(angles1prev.x * coeff); // skewing in xy
        m[0, 2] = Mathf.Tan(angles2.x * coeff) - Mathf.Tan(angles2prev.x * coeff); // skewing in xz
        m[1, 0] = Mathf.Tan(angles1.y * coeff) - Mathf.Tan(angles1prev.y * coeff); // skewing in yx
        m[1, 2] = Mathf.Tan(angles2.y * coeff) - Mathf.Tan(angles2prev.y * coeff); // skewing in yz
        m[2, 0] = Mathf.Tan(angles1.z * coeff) - Mathf.Tan(angles1prev.z * coeff); // skewing in zx
        m[2, 1] = Mathf.Tan(angles2.z * coeff) - Mathf.Tan(angles2prev.z * coeff); // skewing in zy

        Vector3[] verts = gameObject.GetComponent<MeshFilter>().mesh.vertices;
        int i = 0;
        while (i < verts.Length)
        {
            verts[i] = m.MultiplyPoint3x4(verts[i]);
            i++;
        }

        gameObject.GetComponent<MeshFilter>().mesh.vertices = verts;
        angles1prev = angles1;
        angles2prev = angles2;
    }
}
