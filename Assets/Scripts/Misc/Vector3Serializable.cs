using UnityEngine;


[System.Serializable]
public class Vector3Serializable
{
    public float x, y, z;

    public Vector3Serializable() { }

    public Vector3Serializable(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public Vector3Serializable(Vector3 vector3)
    {
        this.x = vector3.x;
        this.y = vector3.y;
        this.z = vector3.z;
    }
}