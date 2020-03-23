using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int breakableBlocks;

    SceneLoader sceneLoader;

    public void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void CountBreakableBlocks()
    {
        ++breakableBlocks;
    }

    public void BlockDestroyed()
    {
        if (--breakableBlocks > 0) return;
        sceneLoader.LoadNextScene();
    }
}
