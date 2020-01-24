using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalPatrol : MonoBehaviour
{
    private Vector3 m_portalAStartPos;
    private Vector3 m_portalBStartPos;//The Initial Position of Both Portals.

    public Vector3 PortalAEndpoint = new Vector3(999, 999, 999);
    public Vector3 PortalBEndpoint = new Vector3(999, 999, 999);//The End Positions of Both Portals.

    public bool Patrolling = false;//Should the Portals be patrolling? False has them not move. True has them move

    public float PortalASpeed = 1.0f;
    public float PortalBSpeed = 1.0f;//The Speed of each portal

    private bool m_portalAGoingToEnd = true;
    private bool m_portalBGoingToEnd = true; //Tracks if the Portal is going to the end goal or the starting goal.

    private float m_clearance = 0.02f;//The distance around a waypoint at which the portal is considered arrived.

    void Start()
    {
        if (PortalAEndpoint == new Vector3(999, 999, 999) && PortalBEndpoint == new Vector3(999, 999, 999))//If the default values are not changed then set the endgoal to the Empty Objects. This is to allow rough path mapping using drag tools.
        {
            PortalAEndpoint = transform.GetChild(2).transform.position;
            PortalBEndpoint = transform.GetChild(3).transform.position; //Setting the Default EndPositions.
        }
        m_portalAStartPos = transform.GetChild(0).transform.position;
        m_portalBStartPos = transform.GetChild(1).transform.position;//Saving the Starting Positiongs
    }

    // Update is called once per frame
    void Update()
    {
        if (Patrolling)//If the Portals are allowed to move.
        {
            // Move our position a step closer to the target.
            float step = PortalASpeed * Time.deltaTime; // calculate distance to move

            if (m_portalAGoingToEnd)//Portal A is moving to the end.
            {
                transform.GetChild(0).transform.position = Vector3.MoveTowards(transform.GetChild(0).transform.position, PortalAEndpoint, step);

                // Check if the positions are within the clearance range.
                if (Vector3.Distance(transform.GetChild(0).transform.position, PortalAEndpoint) < m_clearance)
                {

                    m_portalAGoingToEnd = !m_portalAGoingToEnd;//Portal A is now moving back to the start.
                }

            }
            else
            {
                transform.GetChild(0).transform.position = Vector3.MoveTowards(transform.GetChild(0).transform.position, m_portalAStartPos, step);

                // Check if the positions are within the clearance range.
                if (Vector3.Distance(transform.GetChild(0).transform.position, m_portalAStartPos) < m_clearance)
                {

                    m_portalAGoingToEnd = !m_portalAGoingToEnd;
                }
            }

            if (m_portalBGoingToEnd)//Portal B is moving to the Endpoint
            {
                transform.GetChild(1).transform.position = Vector3.MoveTowards(transform.GetChild(1).transform.position, PortalBEndpoint, step);

                // Check if the positions are within the clearance range.
                if (Vector3.Distance(transform.GetChild(1).transform.position, PortalBEndpoint) < m_clearance)
                {

                    m_portalBGoingToEnd = !m_portalBGoingToEnd;//Portal B is now moving back to the start.
                }

            }
            else
            {
                transform.GetChild(1).transform.position = Vector3.MoveTowards(transform.GetChild(1).transform.position, m_portalBStartPos, step);

                // Check if the positions are within the clearance range.
                if (Vector3.Distance(transform.GetChild(1).transform.position, m_portalBStartPos) < m_clearance)
                {

                    m_portalBGoingToEnd = !m_portalBGoingToEnd;
                }
            }
        }
    }
}
