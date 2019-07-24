using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.iOS;
using UnityEngine.UI;

public class GenerateImageAnchor : MonoBehaviour {


	[SerializeField]
	private ARReferenceImage referenceImage;

	[SerializeField]
	private GameObject prefabToGenerate;

	private GameObject imageAnchorGO;

	private GameObject notesText;

	private UpdateNotes notesScript;


	public bool textStick;

	public int anchorID;



	public string applianceName;

	

	// Use this for initialization
	void Start () {
		textStick = false;
	

		notesText = GameObject.FindWithTag("InfoUpdate");

		notesScript = notesText.GetComponent<UpdateNotes>();

        anchorID = 0;
		
		UnityARSessionNativeInterface.ARImageAnchorAddedEvent += AddImageAnchor;
		UnityARSessionNativeInterface.ARImageAnchorUpdatedEvent += UpdateImageAnchor;
		UnityARSessionNativeInterface.ARImageAnchorRemovedEvent += RemoveImageAnchor;
		
	}

	void AddImageAnchor(ARImageAnchor arImageAnchor)
	{
		Debug.LogFormat("image anchor added[{0}] : tracked => {1}", arImageAnchor.identifier, arImageAnchor.isTracked);
		if (arImageAnchor.referenceImageName == referenceImage.imageName) {
			Vector3 position = UnityARMatrixOps.GetPosition (arImageAnchor.transform);
			Quaternion rotation = UnityARMatrixOps.GetRotation (arImageAnchor.transform);

			imageAnchorGO = Instantiate(prefabToGenerate, position, rotation);
			anchorID = referenceImage.imageID;
			//applianceName = imageAnchorGO.GetComponent<SwitchTextShown>().nameUtility;

			//notesScript.GetID(anchorID);
			
		}
	}

	void UpdateImageAnchor(ARImageAnchor arImageAnchor)
	{
		
		Debug.LogFormat("image anchor updated[{0}] : tracked => {1}", arImageAnchor.identifier, arImageAnchor.isTracked);
		if (arImageAnchor.referenceImageName == referenceImage.imageName) {
            if (arImageAnchor.isTracked)
            {
                if (!imageAnchorGO.activeSelf)
                {
                    imageAnchorGO.SetActive(true);
					
					anchorID = referenceImage.imageID;

					//notesScript.GetID(anchorID);
					
					

                }
                imageAnchorGO.transform.position = UnityARMatrixOps.GetPosition(arImageAnchor.transform);
                imageAnchorGO.transform.rotation = UnityARMatrixOps.GetRotation(arImageAnchor.transform);

				anchorID = referenceImage.imageID;

				//notesScript.GetID(anchorID);
			
				

				
            }
            else if (imageAnchorGO.activeSelf)
            {
                imageAnchorGO.SetActive(false);
                
				anchorID = 0;

				//notesScript.GetID(anchorID);
				

            }
        }
		
		
	}

	void RemoveImageAnchor(ARImageAnchor arImageAnchor)
	{
		Debug.LogFormat("image anchor removed[{0}] : tracked => {1}", arImageAnchor.identifier, arImageAnchor.isTracked);
		if (imageAnchorGO) {
			GameObject.Destroy (imageAnchorGO);
			anchorID = 0;

			//notesScript.GetID(anchorID);
		}

	}

	void OnDestroy()
	{
		UnityARSessionNativeInterface.ARImageAnchorAddedEvent -= AddImageAnchor;
		UnityARSessionNativeInterface.ARImageAnchorUpdatedEvent -= UpdateImageAnchor;
		UnityARSessionNativeInterface.ARImageAnchorRemovedEvent -= RemoveImageAnchor;

	}

	// Update is called once per frame
	void Update () {
		
        
        #if UNITY_EDITOR
		
		if (Input.GetMouseButtonDown(0))
		{
			
			if (textStick == false)
			{
				textStick = true;
			}
			else if (textStick == true)
			{
				textStick = false;
			}
		}

		#else

		if (Input.touchCount > 0)
		{
			
			var touch = Input.GetTouch(0);
			if (touch.phase == TouchPhase.Began)
			{
				if (textStick == false)
				{
					textStick = true;
				}
				else if (textStick == true)
				{
					textStick = false;
				}
				
			}
		}

		
		#endif


	}
}
