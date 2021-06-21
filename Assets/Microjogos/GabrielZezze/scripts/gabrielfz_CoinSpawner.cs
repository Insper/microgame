using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gabrielfz_CoinSpawner : MonoBehaviour {

    [SerializeField] private GameObject Coin;

    void Start() {
        SpawnCoins();
    }

    private int get_coin_count_by_level(int level) {
        return 6+(level*2);
    }

    public void SpawnCoins() {
        foreach (Transform child in transform) {
            GameObject.Destroy(child.gameObject);            
        }

        int coin_count = get_coin_count_by_level(GameData.level);
        for(int i=0; i < coin_count; i++) {
            float x_pos = Random.Range(0.25f, 0.85f);
            float y_pos = Random.Range(0.25f, 0.85f);

            Vector3 position_view_port = Camera.main.ViewportToWorldPoint(new Vector3(x_pos, y_pos, 10));
            Instantiate(Coin, position_view_port, Quaternion.identity, transform);
        }
    }

    // Update is called once per frame
    void Update() {
        if (transform.childCount <= 0) {
            GameData.lost = false;
        }
    }
}
