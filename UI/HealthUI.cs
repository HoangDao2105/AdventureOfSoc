using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Sprite[] Healthsprite;
    public Player player;
    public Image healthUI;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        player.PlayerHealth= Mathf.Clamp(player.PlayerHealth, 0, 5);
        int index = player.PlayerHealth;
        healthUI.sprite = Healthsprite[index];
    }
}
