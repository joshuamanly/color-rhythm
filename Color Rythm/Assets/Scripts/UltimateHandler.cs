using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UltimateHandler : MonoBehaviour
{
    public Image ultimateBar;
    public Text ultimateText;
    public float myUltimate;
    public float currentUltimate;
    public float ultimateRegenRate;
    

    private void Start()
    {
        currentUltimate = 0;
    }
    private void Update()
    {
        if (currentUltimate < myUltimate)
        {
            ultimateBar.fillAmount = Mathf.MoveTowards(ultimateBar.fillAmount, 1f, Time.deltaTime * ultimateRegenRate);
            currentUltimate = Mathf.MoveTowards(currentUltimate / myUltimate, 1f, Time.deltaTime * ultimateRegenRate) * myUltimate;
        }

        ultimateText.text = "" + Mathf.FloorToInt(currentUltimate);
        if (currentUltimate >= myUltimate) 
        { 
            currentUltimate = myUltimate;
            
            if(Input.GetKeyDown(KeyCode.Space)) 
            {
                DoUltimate();
            }

        }
        

    }
    public void DoUltimate()
    {
        currentUltimate -= myUltimate;
        Player.Instance.DoUltimate();
    }
    public void GainUltimate(float ultimate)
    {
        currentUltimate += ultimate;
        ultimateBar.fillAmount += ultimate / myUltimate;
    }


    public void ReduceUltimate(float ultimate)
    {
        currentUltimate -= ultimate;
        ultimateBar.fillAmount -= ultimate / myUltimate;
    }
}
