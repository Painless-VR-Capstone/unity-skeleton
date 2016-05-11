using UnityEngine;
using System.Collections;

public class SteamVR_Teleporter : MonoBehaviour
{
    public enum TeleportType
    {
        TeleportTypeUseTerrain,
        TeleportTypeUseCollider,
        TeleportTypeUseZeroY
    }

    public bool teleportOnClick = false;
    public TeleportType teleportType = TeleportType.TeleportTypeUseZeroY;
<<<<<<< HEAD
    Transform reference;

	// Use this for initialization
	void Start ()
    {
        Transform eyeCamera = GameObject.FindObjectOfType<SteamVR_Camera>().GetComponent<Transform>();
        // The referece point for the camera is two levels up from the SteamVR_Camera
        reference = eyeCamera.parent.parent;

        if (GetComponent<SteamVR_TrackedController>() == null)
        {
            Debug.LogError("SteamVR_Teleporter must be on a SteamVR_TrackedController");
            return;
        }
        GetComponent<SteamVR_TrackedController>().TriggerClicked += new ClickedEventHandler(DoClick);

        if (teleportType == TeleportType.TeleportTypeUseTerrain)
        {
            // Start the player at the level of the terrain
            reference.position = new Vector3(reference.position.x, Terrain.activeTerrain.SampleHeight(reference.position), reference.position.z);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

=======

	Transform reference
	{
		get
		{
			var top = SteamVR_Render.Top();
			return (top != null) ? top.origin : null;
		}
	}

	void Start ()
    {
		var trackedController = GetComponent<SteamVR_TrackedController>();
        if (trackedController == null)
        {
			trackedController = gameObject.AddComponent<SteamVR_TrackedController>();
        }

		trackedController.TriggerClicked += new ClickedEventHandler(DoClick);

        if (teleportType == TeleportType.TeleportTypeUseTerrain)
        {
			// Start the player at the level of the terrain
			var t = reference;
			if (t != null)
	            t.position = new Vector3(t.position.x, Terrain.activeTerrain.SampleHeight(t.position), t.position.z);
        }
	}
	
>>>>>>> 0a6a02c7630a6a10656409243cf8ba4d103576eb
    void DoClick(object sender, ClickedEventArgs e)
    {
        if (teleportOnClick)
        {
<<<<<<< HEAD
            // Teleport
            float refY = reference.position.y;
=======
			var t = reference;
			if (t == null)
				return;

            float refY = t.position.y;
>>>>>>> 0a6a02c7630a6a10656409243cf8ba4d103576eb

            Plane plane = new Plane(Vector3.up, -refY);
            Ray ray = new Ray(this.transform.position, transform.forward);

            bool hasGroundTarget = false;
            float dist = 0f;
<<<<<<< HEAD
            if (teleportType == TeleportType.TeleportTypeUseCollider)
=======
            if (teleportType == TeleportType.TeleportTypeUseTerrain)
>>>>>>> 0a6a02c7630a6a10656409243cf8ba4d103576eb
            {
                RaycastHit hitInfo;
                TerrainCollider tc = Terrain.activeTerrain.GetComponent<TerrainCollider>();
                hasGroundTarget = tc.Raycast(ray, out hitInfo, 1000f);
                dist = hitInfo.distance;
            }
            else if (teleportType == TeleportType.TeleportTypeUseCollider)
            {
                RaycastHit hitInfo;
                Physics.Raycast(ray, out hitInfo);
                dist = hitInfo.distance;
            }
            else
            {
                hasGroundTarget = plane.Raycast(ray, out dist);
            }
<<<<<<< HEAD
            if (hasGroundTarget)
            {
                Vector3 newPos = ray.origin + ray.direction * dist - new Vector3(reference.GetChild(0).localPosition.x, 0f, reference.GetChild(0).localPosition.z);

                reference.position = newPos;
=======

            if (hasGroundTarget)
            {
				Vector3 headPosOnGround = new Vector3(SteamVR_Render.Top().head.localPosition.x, 0.0f, SteamVR_Render.Top().head.localPosition.z);
				t.position = ray.origin + ray.direction * dist - new Vector3(t.GetChild(0).localPosition.x, 0f, t.GetChild(0).localPosition.z) - headPosOnGround;
>>>>>>> 0a6a02c7630a6a10656409243cf8ba4d103576eb
            }
        }
    }
}
