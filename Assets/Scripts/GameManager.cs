using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Define.Player SelectedPlayer;
    public string UserID;

    public float PlayerHP = 100f; //체력
    public float PlayerExp = 1f; //경험치
    public int coin = 0;
    public GameObject player;


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        UserID = PlayerPrefs.GetString("ID");
        DontDestroyOnLoad(Instance);
    }

    public GameObject SpawnPlayer(Transform spawnPos)
    {
        GameObject playerPrefab = Resources.Load<GameObject>("Characters/" + SelectedPlayer.ToString());
        player = Instantiate(playerPrefab, spawnPos.position, spawnPos.rotation);

        return player;
    }

    internal GameObject SpawnPlayer(object transform)
    {
        throw new NotImplementedException();
    }
}
