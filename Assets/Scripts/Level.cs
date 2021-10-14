using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]int BreakableBlocks;
    [SerializeField]SceneLoader sceneLoader;
    public void CountBreakableBlock()
    {
        BreakableBlocks++;
    }
    public void BlockDestroyed()
    {
        BreakableBlocks--;
        if (BreakableBlocks == 0)
        {
            sceneLoader.LoadLevelMenu();
        }
    }
}
