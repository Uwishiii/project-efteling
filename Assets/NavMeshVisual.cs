using UnityEngine;
using UnityEngine.AI;

//Checking / Adding required components
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(LineRenderer))]
public sealed class NavMeshVisual : MonoBehaviour
{
    #region Variables

    private NavMeshAgent myNavMeshAgent;
    private GameObject PlayerNavMarker;
    private LineRenderer myLineRenderer;
    
    #endregion
    
    #region Functions

    void Start()
    {
        //Assigning variables
        myNavMeshAgent = GetComponent<NavMeshAgent>();
        PlayerNavMarker = GameObject.Find("Player NavMesh Marker");
        myLineRenderer = GetComponent<LineRenderer>();

        //Setting positionCount to zero so there isn't a weird dot line thing
        myLineRenderer.positionCount = 0;
    }
    
    void Update()
    {
        //Placeholder for actual mechanic to trigger guiding line (i.e picking up an item)
        if (Input.GetKeyDown(KeyCode.M))
        {
            //Calling SetDestination() and giving it the vec3 of the destination (should change to be more dynamic later)
            SetDestination(PlayerNavMarker.transform.position);
        }

        //Calling DrawPath() if the NavMeshAgent has a path
        if (myNavMeshAgent.hasPath)
        {
            DrawPath();
        }
    }

    private void SetDestination(Vector3 target)
    {
        //To keep the Update function less cluttered
        myNavMeshAgent.SetDestination(target);
    }

    private void DrawPath()
    {
        //Using NavMeshAgent's amount of corners as the amount of points for drawing the line (HOLY HELL THIS IS SO SMART)
        myLineRenderer.positionCount = myNavMeshAgent.path.corners.Length;
        
        //Setting starting position of the line on the player
        myLineRenderer.SetPosition(0, transform.position);

        //No need for complicated pathing if there's no bends in the path
        if (myNavMeshAgent.path.corners.Length < 2)
        {
            return;
        }

        //Loop for all corners
        for (var i = 1; i < myNavMeshAgent.path.corners.Length; i++)
        {
            //Laziness
            var path = myNavMeshAgent.path;
            
            //Fancy pathing connections between corners
            Vector3 pointPosition = new Vector3(path.corners[i].x, path.corners[i].y,
                path.corners[i].z);
            
            //Actually applying the calculated fancy connections
            myLineRenderer.SetPosition(i, pointPosition);
        }
        
    }

    #endregion
}
