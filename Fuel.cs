using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 
using UnityEngine;
public class Fuel : MonoBehaviour
{
    public float FuelAmount = 1.0f;
    [SerializeField] Image FuelBarImage;

    private void Update()
    {
        FuelAmount -= 0.05f * Time.deltaTime;
        FuelBarImage.fillAmount = FuelAmount;
        if(FuelAmount <= 0)
        {
            Debug.Log("gameOver"); 
            SceneManager.LoadScene("GameOverTwo"); 
        }

        if(FuelAmount > 1.0f)
        {
            FuelAmount = 1.0f; 
        }
    }
}
