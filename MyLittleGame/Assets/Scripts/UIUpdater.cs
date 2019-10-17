using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIUpdater : MonoBehaviour {
    private Health healthComponent;
    public HealthUI healthUI;
    private double lastHealth;

    // Start is called before the first frame update
    void Start() {
        healthComponent = this.GetComponent<Health>();
        lastHealth = -1;
    }

    // Update is called once per frame
    void Update() {
        if (healthComponent!=null)
            UpdateHealthUI();
    }

    private void UpdateHealthUI() {
        double currentHealth = healthComponent.GetHealth();
        
        if (currentHealth != lastHealth) {
            healthUI.healthSlider.value = (float) currentHealth / healthComponent.maxHealth;
            healthUI.healthText.text = (float) currentHealth + " / " + healthComponent.maxHealth;

            lastHealth = currentHealth;
        }
    }
}

[System.Serializable]
public class HealthUI {
	public Slider healthSlider;
    public Text healthText;
}