using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{

    public GameObject SpaceText;
    public GameObject StoreOpenText;

    private bool SpaceBarPressed = false;
    private bool StoreClicked = false;

    // Start is called before the first frame update
    void Start()
    {
        SpaceText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (StoreClicked && !SpaceBarPressed && Input.GetKeyDown(KeyCode.Space))
        {
            SpaceBarPressed = true;
            SpaceText.SetActive(false);
        }

        if (StoreClicked && SpaceBarPressed)
        {
            Destroy(gameObject);
        }
    }

    public void storeOpened()
    {
        if (!StoreClicked)
        {
            StoreOpenText.SetActive(false);
            StoreClicked = true;
            SpaceText.SetActive(true);
        }
    }
}
