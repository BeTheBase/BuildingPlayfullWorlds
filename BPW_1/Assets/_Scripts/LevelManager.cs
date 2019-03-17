using UnityEngine;
using UnityEngine.AI;

public class LevelManager : MonoBehaviour
{
    public NavMeshSurface[] Surface;

    // Start is called before the first frame update
    void Start()
    {
        foreach(var surf in Surface)
            surf.BuildNavMesh();
    }
}
