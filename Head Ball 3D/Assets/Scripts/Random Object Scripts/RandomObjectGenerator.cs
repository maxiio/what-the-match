    using UnityEngine;
using Random = UnityEngine.Random;

public class RandomObjectGenerator : MonoBehaviour
{
    
    [SerializeField] private GameObject[] objectPrefabs;
    [SerializeField] private GameObject player;
    
    public Color GizmosColor = new Color(0.5f, 0.5f, 0.5f, 0.2f);
    
    void OnDrawGizmos()
    {
        Gizmos.color = GizmosColor;
        Gizmos.DrawCube(transform.position, transform.localScale);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn",5f,25f);
    }
    
    private void Spawn()
    {
        Vector3 origin =  transform.position;
        Vector3 range = transform.localScale / 2.0f;
        Vector3 randomRange = new Vector3(Random.Range(-range.x, range.x),
            2f,
            Random.Range(-range.z, range.z));
        Vector3 randomCoordinate = origin + randomRange;

        if (Mathf.Abs(player.transform.position.x - randomCoordinate.x) > 4 ||
            Mathf.Abs(player.transform.position.z - randomCoordinate.z) > 4)
        {
            if (LevelManager.Instance.GetCurrentLevel() % 2 == 0)
            {
                Instantiate(objectPrefabs[1],randomCoordinate,Quaternion.identity);
            }
            else
            {
                Instantiate(objectPrefabs[0],randomCoordinate,Quaternion.identity);
            }
           
        }
        
       
    }
    
}