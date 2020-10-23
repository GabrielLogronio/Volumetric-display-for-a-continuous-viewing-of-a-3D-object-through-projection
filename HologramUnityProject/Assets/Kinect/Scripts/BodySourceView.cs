 using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Kinect = Windows.Kinect;
using Joint = Windows.Kinect.Joint;

public class BodySourceView : MonoBehaviour 
{
    public BodySourceManager mBodySourceManager;
    [SerializeField]
    private GameObject userPrefab;
    //private GameObject[] userPrefabs;

    private Dictionary<ulong, GameObject> mBodies = new Dictionary<ulong, GameObject>();
    [SerializeField]
    private Kinect.JointType[] userJoints;
    /*private List<Kinect.JointType> userJoints = new List<Kinect.JointType>
    { 
        Kinect.JointType.Head, 
        Kinect.JointType.HandLeft, 
        Kinect.JointType.HandRight 
    };*/

    void Update () 
    {
        #region Get Kinect Data
        Kinect.Body[] data = mBodySourceManager.GetData();
        if (data == null)
            return;

        List<ulong> trackedIds = new List<ulong>();
        /*
         1 User ONLY Vesion
         if(data[0] != null && data[0].IsTracked)          
         */
        foreach (var body in data)
        {
            if (body == null)
                continue;
              
                
            if(body.IsTracked)
                trackedIds.Add (body.TrackingId);
            
        }
        #endregion

        #region Delete previous Kinect Bodies
        List<ulong> knownIds = new List<ulong>(mBodies.Keys);
        // First delete untracked bodies
        foreach(ulong trackingId in knownIds)
        {
            if(!trackedIds.Contains(trackingId))
            {
                Destroy(mBodies[trackingId]);
                mBodies.Remove(trackingId);
            }
        }
        #endregion

        #region Create Kinect Bodies
        foreach (var body in data)
        {
            if (body == null)
            {
                continue;
            }
            
            if(body.IsTracked)
            {
                if(!mBodies.ContainsKey(body.TrackingId))
                {
                    mBodies[body.TrackingId] = Instantiate(userPrefab); //CreateBodyObject(body.TrackingId);
                    mBodies[body.TrackingId].name = "Body " + body.TrackingId;
                }
                
                UpdateBodyObject(body, mBodies[body.TrackingId]);
            }
        }
        #endregion

        #region Tryout
        // ---------- TRACKING THE CLOSEST PERSON TRYOUT ---------
        /*
        #region Get Kinect Data
        Kinect.Body[] data = mBodySourceManager.GetData();
        if (data == null)
            return;

        List<ulong> trackedIds = new List<ulong>();
        float currentMinDistance = 100;
        if (data.Length == 1)
        {
            bodyTrackingID = 0;
        }
        else if (data.Length > 1)
        {
            for (int i = 0; i < data.Length; i++)
            {
                float distance = Vector3.Distance(GetVector3FromJoint(data[i].Joints[Kinect.JointType.Head]), Vector3.zero);
                if (distance < currentMinDistance)
                {
                    currentMinDistance = distance;
                    bodyTrackingID = i;
                }
            }
        }

        if (data[bodyTrackingID].IsTracked)
            trackedIds.Add(data[bodyTrackingID].TrackingId);

        #endregion

        #region Delete previous Kinect Bodies
        List<ulong> knownIds = new List<ulong>(mBodies.Keys);
        // First delete untracked bodies
        foreach (ulong trackingId in knownIds)
        {
            if (!trackedIds.Contains(trackingId))
            {
                Destroy(mBodies[trackingId]);
                mBodies.Remove(trackingId);
            }
        }
        #endregion

        #region Create Kinect Bodies
        if (data[bodyTrackingID].IsTracked)
        {
            if (!mBodies.ContainsKey(data[bodyTrackingID].TrackingId))
            {
                mBodies[data[bodyTrackingID].TrackingId] = CreateBodyObject(data[bodyTrackingID].TrackingId);
            }

            UpdateBodyObject(data[bodyTrackingID], mBodies[data[bodyTrackingID].TrackingId]);
        }
        /*
        foreach (var body in data)
        {
            if (body == null)
            {
                continue;
            }
            
            if(body.IsTracked)
            {
                if(!mBodies.ContainsKey(body.TrackingId))
                {
                    mBodies[body.TrackingId] = CreateBodyObject(body.TrackingId);
                }
                
                UpdateBodyObject(body, mBodies[body.TrackingId]);
            }
        }
        #endregion
        */
        #endregion

    }
    /*
    private GameObject CreateBodyObject(ulong id)
    {
        GameObject newBody = new GameObject("UserBody:" + id);
        for (int i = 0; i < userJoints.Length; i++) 
        {
            GameObject newJoint = Instantiate(userPrefabs[i]);

            newJoint.transform.parent = newBody.transform;
        }

        return newBody;
    }
    */
    private void UpdateBodyObject(Kinect.Body body, GameObject bodyObject)
    {
        for (int i = 0; i < userJoints.Length; i++)
        {
            Joint sourceJoint = body.Joints[userJoints[i]];
            Vector3 targetPosition = GetVector3FromJoint(sourceJoint);

            Transform selectedJoint = bodyObject.transform.GetChild(i);
            selectedJoint.position = targetPosition;
        }
    }
    
    private static Vector3 GetVector3FromJoint(Kinect.Joint joint)
    {
        // Kinect was giving flipped X axis, might need change
        return new Vector3( - joint.Position.X * 10, joint.Position.Y * 10, joint.Position.Z * 10);
    }
}
