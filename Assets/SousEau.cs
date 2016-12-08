using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class SousEau : MonoBehaviour {

    public Color color = new Color(0.22f, 0.65f, 0.77f, 0.5f);
    public GameObject Bubble;
    private FirstPersonController FpsScript;
    private FpsPerso fpsPerso;
    // Use this for initialization
    void Start () {

        FpsScript = GetComponent<FirstPersonController>();
        fpsPerso = GetComponent<FpsPerso>();

        RenderSettings.fog = false;
        RenderSettings.fogColor = color;
        RenderSettings.fogDensity = 0.1f;
    }

    bool IsUnderWater()
    {
        return gameObject.transform.position.y < -1;
    }
	
	// Update is called once per frame
	void Update () {
        RenderSettings.fog = IsUnderWater();

        if(IsUnderWater())
        {
            Bubble.SetActive(true);
            FpsScript.enabled = false;
            fpsPerso.enabled = true;
        }
        else
        {
            Bubble.SetActive(false);
            FpsScript.enabled = true;
            fpsPerso.enabled = false;
        }
	}
}
