using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;

public class HealthbarController : NetworkBehaviour {

	public RawImage healthbar;

    public const float maxHealth = 100;

    [SyncVar(hook = "OnChangeHealth")]
	public float currHealth = 50;

    public float recovery = 3;

    void OnChangeHealth(float health) {
        Debug.Log("change healthbar");
        healthbar.rectTransform.localScale = new Vector3(health / maxHealth, 1, 1);		
    }

    private void Start()
    {
        healthbar.rectTransform.localScale = new Vector3(currHealth / maxHealth, 1, 1);
    }

    public void TakeDamage(float damage){
        if (!isServer)
        {
            Debug.Log("Not server");
            return;
        }
        Debug.Log ("Player Damaged");
		currHealth -= damage;
		if (currHealth < 0) {
			currHealth = 0;
            Debug.Log("Dead");
        }
	}

    public void RecoverHealth()
    {
        if (currHealth < maxHealth)
        {
            currHealth += recovery * Time.deltaTime;
            if (currHealth > maxHealth)
            {
                currHealth = maxHealth;
            }
        }
    }


    public void Heal(float heal){
		currHealth += heal;
		if (currHealth > 100) {
			currHealth = 100;
		}
	}

}
