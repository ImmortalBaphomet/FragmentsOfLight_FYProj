using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win_Criteria : MonoBehaviour
{
    public GameObject WinMenuUI;
    public GameObject FailMenuUI;
    public GameObject UI_Camera;
    public GameObject Main_Camera;

    public GameObject HappyPlayer;
    public GameObject SadPlayer;

    public Material material;
    public string intensityPropertyName = "_Intensity";
    private float intensityValue;
    public float defaultIntensity = 2f;
    public float intensityDecreaseRate = 1f;
    public float intensityIncreaseRate = 1f;
    public float maxIntensity = 6f;



    public Pause_Menu_Script pms;

 

    private void Start()
    {
       SadPlayer.SetActive(false);
       HappyPlayer.SetActive(false);

        // Initialize material property
        if (material != null)
        {
            intensityValue = defaultIntensity;
            material.SetFloat(intensityPropertyName, intensityValue);
        }
        else
        {
            Debug.LogError("Material not assigned. Please assign a material with the shader.");
        }

        Main_Camera.SetActive(true);
        UI_Camera.SetActive(false);
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Win_Area"))
        {
            HappyPlayer.SetActive(true);
            WinMenuUI.SetActive(true);
            Main_Camera.SetActive(false);
            UI_Camera.SetActive(true);

            
        }

        if (other.gameObject.CompareTag("Fail_Area"))
        {
            SadPlayer.SetActive(true);
            FailMenuUI.SetActive(true);
            Main_Camera.SetActive(false);
            UI_Camera.SetActive(true);

            
        }
        
    }

    private void Update()
    {

        

        if (pms.leaveGame)
        {
            // Gradually decrease intensity
            intensityValue = Mathf.MoveTowards(intensityValue, 0, intensityDecreaseRate * Time.deltaTime);
            material.SetFloat(intensityPropertyName, intensityValue);

            if (intensityValue <= 0)
            {
                Debug.Log("Intensity fully decreased!");
                intensityValue = 0f; 
            }
        }

        if (pms.WinGame)
        {
            intensityValue = Mathf.MoveTowards(intensityValue, maxIntensity, intensityIncreaseRate * Time.deltaTime);
            material.SetFloat(intensityPropertyName, intensityValue);

            if (intensityValue >= maxIntensity)
            {
                Debug.Log("Intensity fully increased!");
                intensityValue = maxIntensity;
            }
        }


      
    }

}
