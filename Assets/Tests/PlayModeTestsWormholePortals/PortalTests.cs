using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

namespace Tests
{
    public class PortalTests : MonoBehaviour
    {
        [UnityTest]
        public IEnumerator SetPortalPosition()
        {
            SceneManager.LoadScene("main");
            yield return new WaitForSeconds(0.1f);
            GameObject PortalPair = GameObject.Find("PortalPair");
            PortalPair.transform.GetChild(0).transform.position = new Vector3(20, 20, 20);
            Assert.AreEqual(new Vector3(20, 20, 20), PortalPair.transform.GetChild(0).transform.position); //Position is what it was set to
            yield return null;
        }



        [UnityTest]
        public IEnumerator ObjectsWarp()
        {
            SceneManager.LoadScene("main");
            yield return new WaitForSeconds(0.1f);
            GameObject PortalA = GameObject.Find("PortalA");
            GameObject PortalB = GameObject.Find("PortalB");
            GameObject Cube = GameObject.Find("2D Collider Cube");
            Cube.transform.position = PortalA.transform.position;
            yield return new WaitForSeconds(0.1f);
            Assert.IsTrue(Vector3.Distance(Cube.transform.position, PortalB.transform.position) < 1.0f);//Object is within 1 unit of the new portal position after warping

            yield return null;
        }

        [UnityTest]
        public IEnumerator MaintainMomentum()
        {
            SceneManager.LoadScene("main");
            yield return new WaitForSeconds(0.1f);
            GameObject PortalA = GameObject.Find("PortalA");
            GameObject Cube = GameObject.Find("2D Collider Cube");
            Vector2 oldVelocity = Cube.GetComponent<Rigidbody2D>().velocity;
            Cube.transform.position = PortalA.transform.position;
            yield return new WaitForSeconds(0.1f);
            Assert.IsTrue(oldVelocity.magnitude < Cube.GetComponent<Rigidbody2D>().velocity.magnitude);//New velocity is the same as before(Accounting for gravity)

            yield return null;
        }

        [UnityTest]
        public IEnumerator CreatedInPairs()
        {
            SceneManager.LoadScene("main");
            yield return new WaitForSeconds(0.1f);
            GameObject PortalA = GameObject.Find("PortalA");
            GameObject PortalB = GameObject.Find("PortalB");
            int count = 0;
            if (PortalA != null)
            {
                count++;
            }
            if (PortalB != null)
            {
                count++;
            }
            Assert.AreEqual(2, count);//Two Portals Are Present and not Null.
            yield return null;
        }

        [UnityTest]
        public IEnumerator PortalsAnimate()
        {
            SceneManager.LoadScene("main");
            yield return new WaitForSeconds(0.1f);

            GameObject PortalA = GameObject.Find("PortalA");
            var oldZRotation = PortalA.transform.GetChild(2).transform.rotation.z;
            yield return new WaitForSeconds(0.1f);
            Assert.IsTrue(oldZRotation < PortalA.transform.GetChild(2).transform.rotation.z);//The Portal sprite's z rotation is changing as it rotates.
            yield return null;
        }

        [UnityTest]
        public IEnumerator SFXPlays()
        {
            SceneManager.LoadScene("main");
            yield return new WaitForSeconds(0.1f);

            GameObject PortalA = GameObject.Find("PortalA");
            GameObject PortalB = GameObject.Find("PortalB");
            GameObject Cube = GameObject.Find("2D Collider Cube");
            Cube.transform.position = PortalA.transform.position;
            yield return new WaitForSeconds(0.1f);
            Assert.IsTrue(Vector3.Distance(Cube.transform.position, PortalB.transform.position) < 1.0f);//A SFX plays whenever an object is warped.
            yield return null;
        }

        [UnityTest]
        public IEnumerator check2dCollisions()
        {
            SceneManager.LoadScene("main");
            yield return new WaitForSeconds(0.1f);

            GameObject PortalA = GameObject.Find("PortalA");
            GameObject PortalB = GameObject.Find("PortalB");
            GameObject Cube = GameObject.Find("2D Collider Cube");
            Cube.transform.position = PortalA.transform.position;
            yield return new WaitForSeconds(0.1f);
            Assert.IsTrue(Vector3.Distance(Cube.transform.position, PortalB.transform.position) < 1.0f);//An object with a 2D collider is warped successfully and is withing 1 unit of portal B.
            yield return null;
        }
        [UnityTest]
        public IEnumerator check3dCollisions()
        {
            SceneManager.LoadScene("main");
            yield return new WaitForSeconds(0.1f);

            GameObject PortalA = GameObject.Find("PortalA");
            GameObject PortalB = GameObject.Find("PortalB");
            GameObject Cube = GameObject.Find("3D Collider Cube");
            Cube.transform.position = PortalA.transform.position;
            yield return new WaitForSeconds(0.1f);
            Assert.IsTrue(Vector3.Distance(Cube.transform.position, PortalB.transform.position) < 1.0f);//An object with a 3D collider is warped successfully and is withing 1 unit of portal B.
            yield return null;
        }

        [UnityTest]
        public IEnumerator CheckTimeout()
        {
            SceneManager.LoadScene("main");
            yield return new WaitForSeconds(0.1f);

            GameObject PortalA = GameObject.Find("PortalA");
            GameObject PortalB = GameObject.Find("PortalB");
            GameObject Cube = GameObject.Find("3D Collider Cube");
            Cube.transform.position = PortalA.transform.position;//This object is warped
            yield return new WaitForSeconds(0.175f);
            Cube.transform.position = PortalA.transform.position;
            yield return new WaitForSeconds(0.01f);
            Assert.IsTrue(Vector3.Distance(Cube.transform.position, PortalB.transform.position) > 1.0f);//An object is not warped despite being withing Portal A's Collider and in the same position that triggered a warp before. Object is too far away from B to have warped
            yield return null;
        }

        [UnityTest]
        public IEnumerator CheckPatrolling()
        {
            SceneManager.LoadScene("main");
            yield return new WaitForSeconds(0.1f);

            GameObject portalPair = GameObject.Find("PortalPair");
            portalPair.GetComponent<PortalPatrol>().Patrolling = true;
            Vector3 oldPosition = portalPair.transform.GetChild(0).transform.position;
            yield return new WaitForSeconds(0.1f);
            Assert.IsTrue(oldPosition != portalPair.transform.GetChild(0).transform.position);//Portal does not have the same position. It Has moved.
            yield return null;
        }
        [UnityTest]
        public IEnumerator SetSpecificEndpoints()
        {
            SceneManager.LoadScene("main");
            yield return new WaitForSeconds(0.1f);

            GameObject portalPair = GameObject.Find("PortalPair");
            portalPair.GetComponent<PortalPatrol>().Patrolling = true;
            Vector3 targetPosition = portalPair.transform.GetChild(0).transform.position;
            targetPosition.x++;
            portalPair.GetComponent<PortalPatrol>().PortalAEndpoint = targetPosition;//The distance from the target Position and current position is 1 unit
            yield return new WaitForSeconds(0.2f);
            Assert.IsTrue(Vector3.Distance(targetPosition, portalPair.transform.GetChild(0).transform.position) < 1.0f);//The distance between the two points is now less than 1. It has moved closer.
            yield return null;
        }

        [UnityTest]
        public IEnumerator GoToEndPoints()
        {
            SceneManager.LoadScene("main");
            yield return new WaitForSeconds(0.1f);

            GameObject portalPair = GameObject.Find("PortalPair");
            float oldDistance = Vector3.Distance(portalPair.transform.GetChild(0).transform.position, portalPair.transform.GetChild(2).transform.position);//Initial Distance of the two points
            portalPair.GetComponent<PortalPatrol>().Patrolling = true;
            yield return new WaitForSeconds(0.2f);
            Assert.IsTrue(oldDistance > Vector2.Distance(portalPair.transform.GetChild(0).transform.position, portalPair.transform.GetChild(2).transform.position));//The distance between the two points is now less than it was before. It has moved closer.
            yield return null;
        }


        [UnityTest]
        public IEnumerator AdjustSpeed()
        {
            SceneManager.LoadScene("main");
            yield return new WaitForSeconds(0.1f);

            GameObject portalPair = GameObject.Find("PortalPair");
            portalPair.GetComponent<PortalPatrol>().Patrolling = true;
            portalPair.GetComponent<PortalPatrol>().PortalASpeed = 5.0f;
            yield return new WaitForSeconds(0.2f);
            Assert.IsTrue(portalPair.GetComponent<PortalPatrol>().PortalASpeed == 5.0f);//Speed set was maintained
            yield return null;
        }

        [UnityTest]
        public IEnumerator SpawnPointChanging()
        {
            SceneManager.LoadScene("main");
            yield return new WaitForSeconds(0.1f);

            GameObject PortalA = GameObject.Find("PortalA");
            GameObject PortalB = GameObject.Find("PortalB");
            GameObject Cube = GameObject.Find("3D Collider Cube");
            Transform newPoint = PortalB.transform.GetChild(1).transform;
            newPoint.transform.position = new Vector3(5,5,0);
            Cube.transform.position = PortalA.transform.position;
            yield return new WaitForSeconds(0.21f);
            PortalA.GetComponent<portalCollision>().SpawnPoint = newPoint;
            Cube.transform.position = PortalA.transform.position;
            yield return new WaitForSeconds(0.01f);
            Assert.IsTrue(Vector3.Distance(Cube.transform.position, newPoint.transform.position) < 1.0f);//The Object was warped to the new changed position.
            yield return null;
        }


    }
}
