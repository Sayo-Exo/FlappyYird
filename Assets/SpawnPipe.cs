using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SpawnPipe : MonoBehaviour
{
    public float maxTime = 2, height = 0.5f, distHeight = 0.3f;
    private float timer = 0;
    public GameObject pipe;
    public GameObject greenPipe;
    public GameObject redPipe;
    // Start is called before the first frame update
    void Start()
    {
        GameObject newPipe;
        switch (GameManager.currentPipe) {
            case "GREEN":
                newPipe = Instantiate(greenPipe);
                break;
            case "RED":
                newPipe = Instantiate(redPipe);
                break; 
            default:
                newPipe = Instantiate(greenPipe);
                break;
        }
        newPipe.transform.position += new Vector3(0, Random.Range(-height, height), 0);
        foreach (Transform item in newPipe.GetComponentInChildren<Transform>())
        {
            item.transform.position += new Vector3(0, Random.Range(-distHeight, distHeight), 0);
        }
        Destroy(newPipe, 15);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > maxTime) {
            GameObject newPipe;
            switch (GameManager.currentPipe) {
                case "GREEN":
                    newPipe = Instantiate(greenPipe);
                    break;
                case "RED":
                    newPipe = Instantiate(redPipe);
                    break; 
                default:
                    newPipe = Instantiate(greenPipe);
                    break;
            }
            newPipe.transform.position += new Vector3(0, Random.Range(-height, height), 0);
            foreach (Transform item in newPipe.GetComponentInChildren<Transform>())
            {
                item.transform.position += new Vector3(0, Random.Range(-distHeight, distHeight), 0);
            }
            Destroy(newPipe, 15);
            timer = 0;
        }

        if (!HahaBirdGoFly.grounded)
            timer += Time.deltaTime;
    }
}
