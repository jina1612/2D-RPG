using UnityEditor.Tilemaps;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string CharacterName;
    public string UserID;

    public float PlayerHP = 100f; //ü��
    public float PlayerExp = 1f; //����ġ
    public int coin = 0;
    private GameObject player;


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

        DontDestroyOnLoad(Instance);
    }

    private void Start()
    {
        UserID = PlayerPrefs.GetString("ID");
    }

    public GameObject SpawnPlayer(Transform spawnPos)
    {
        GameObject playerPrefab = Resources.Load<GameObject>("Characters/" + CharacterName);
        player = Instantiate(playerPrefab, spawnPos.position, spawnPos.rotation);

        return player;
    }    
}
