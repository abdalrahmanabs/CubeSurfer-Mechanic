using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CollectableCubeController : MonoBehaviour
{
    StackContoller stackContoller;
    bool isStacked = false;
    // Start is called before the first frame update
    void Start()
    {
        stackContoller = GameObject.FindObjectOfType<StackContoller>();
    }
    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Cube":
                if (!isStacked)
                {
                    isStacked = true;
                    stackContoller.IncreaseCubeStack(this.gameObject);
                    SoundManager.instance.PlaySound(SoundManager.sounds.collect);
                }
                break;
            case "Obstacle":
                    stackContoller.DecreaseCubeStack(this.gameObject);
                break;
        }
    }
}
