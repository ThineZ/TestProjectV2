using UnityEngine;

public class CollidedSpawn : MonoBehaviour
{
    [SerializeField] bool PlayerFalling = false;
    [Space]
    [Header("Spawn Location")]
    public Transform SpawnLocation;
    [Space]
    [Header("Player Obj")]
    public Transform Player;

    private void Update()
    {
        FallSpawn();

        if(Player.position.y < 1f)
        {
            SpawnLocation.position = new Vector3
                (SpawnLocation.position.x, 
                 SpawnLocation.position.y, 
                 Player.position.z);
        }
    }

    private void FallSpawn()
    {
        if (PlayerFalling) 
        {
            Player.position = SpawnLocation.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            PlayerFalling = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.name == "Player") 
        {
            PlayerFalling = false;
        }
    }
}
