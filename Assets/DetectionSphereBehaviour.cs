using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class DetectionSphereBehaviour : MonoBehaviour
{   
    private Dictionary<GameObject, EnemyMarkerManager> EnemyMarkers;
    public EnemyMarkerManager EnemyMarkerPrefab;

    private Dictionary<GameObject, GameObject> EnemyWarningVolumes;

    public UnityEngine.Rendering.Volume WarningVolumePrefab;

    // Start is called before the first frame update
    void Start()
    {
        this.EnemyMarkers = new Dictionary<GameObject, EnemyMarkerManager>();
        this.EnemyWarningVolumes = new Dictionary<GameObject, GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(string.Format("Collided with gameobject {0}", collision.gameObject.name));
    }

    private void OnTriggerEnter(Collider collision)
    {
        //Debug.Log(string.Format("Collided with gameobject {0}", collision.gameObject.name));
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.layer = 9;
            //Remove markers for given enemy when seen again
            if (this.EnemyMarkers.ContainsKey(collision.gameObject))
            {
               Debug.Log("Found enemy again, removing LKP Marker");
               Destroy(this.EnemyMarkers[collision.gameObject].gameObject);
               this.EnemyMarkers.Remove(collision.gameObject);
            }

            if (this.EnemyWarningVolumes.ContainsKey(collision.gameObject))
            {
                this.EnemyWarningVolumes[collision.gameObject].transform.position = collision.transform.position;
            }
            else
            {
                var newVolume = Instantiate(WarningVolumePrefab, collision.gameObject.transform).gameObject;
                this.EnemyWarningVolumes.Add(collision.gameObject, newVolume);
            }
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        //TODO: let this happen slowly
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.layer = 0;
            LeaveLKPMarker(collision.gameObject, collision.transform);
        }
    }

    private void LeaveLKPMarker(GameObject enemy, Transform position)
    {
        //Debug.Log("Leaving LKP Marker")
        var enemyMarker = Instantiate(EnemyMarkerPrefab);
        enemyMarker.gameObject.transform.position = position.position;
        enemyMarker.SetAssociatedEnemy(enemy);
        this.EnemyMarkers.Add(enemy, enemyMarker);
    }

    Action<UnityEngine.Rendering.Universal.Bloom> FadeOut;

    private delegate void Action<GameObject>(GameObject mytarget);

    private float bloomIntensity = 1;
    private void SetFadeBehaviour(GameObject someTarget)
    {
        /*
        FadeOut = (target) =>
        {
            var volume = target.GetComponent<Volume>();
            bloomEffect = 
            volume.profile.TryGet<UnityEngine.Rendering.Universal.Bloom>()
        };
        */
    }
}
