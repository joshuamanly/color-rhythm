using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LifeEnergyHandler : MonoBehaviour
{
   
    public Image lifeBar;
    public Image energyBar;
    

    public float myLife;
    public float myEnergy;
    public Text lifeText;
    public Text energyText;

    public float currentLife;
    public float currentEnergy;
    private float calculateLife;

   
    private void Start()
    {
        currentLife = myLife;
        currentEnergy = 0;
    }

    private void Update()
    {
        calculateLife = currentLife / myLife;
        lifeBar.fillAmount = Mathf.MoveTowards(lifeBar.fillAmount,calculateLife,Time.deltaTime);
        lifeText.text = "" + (int) currentLife;

        if(currentEnergy < myEnergy) 
        {
            energyBar.fillAmount = Mathf.MoveTowards(energyBar.fillAmount,1f,Time.deltaTime * 0.001f);
            currentEnergy = Mathf.MoveTowards(currentEnergy/myEnergy, 1f, Time.deltaTime * 0.001f) * myEnergy;
        }

        energyText.text = "" + Mathf.FloorToInt(currentEnergy);
        if(currentEnergy >= myEnergy) { currentEnergy = myEnergy; }

       

       
    }
    public void Damage(float damage)
    {
        currentLife -= damage;
    }
    public void GainEnergy(float energy)
    {
        currentEnergy += energy;
        energyBar.fillAmount += energy / myEnergy;
    }

    
    public void ReduceEnergy(float energy)
    {
            currentEnergy -= energy;
            energyBar.fillAmount -= energy / myEnergy;   
    }
}
