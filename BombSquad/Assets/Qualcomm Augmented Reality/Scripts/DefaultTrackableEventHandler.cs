/*==============================================================================
Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Qualcomm Connected Experiences, Inc.
==============================================================================*/

using UnityEngine;

namespace Vuforia
{
    /// <summary>
    /// A custom handler that implements the ITrackableEventHandler interface.
    /// </summary>
    public class DefaultTrackableEventHandler : MonoBehaviour,
                                                ITrackableEventHandler
    {
		public Texture2D text;
        #region PRIVATE_MEMBER_VARIABLES
        private TrackableBehaviour mTrackableBehaviour;
		private bool drawButton = false;
		private string guiText = "Bomb not found...";
        #endregion // PRIVATE_MEMBER_VARIABLES



        #region UNTIY_MONOBEHAVIOUR_METHODS
    
        void Start()
        {
            mTrackableBehaviour = GetComponent<TrackableBehaviour>();
            if (mTrackableBehaviour)
            {
                mTrackableBehaviour.RegisterTrackableEventHandler(this);
            }

			GetComponent<AudioSource>().Play();
			GetComponent<AudioSource>().loop = true;
        }

        #endregion // UNTIY_MONOBEHAVIOUR_METHODS



        #region PUBLIC_METHODS

        /// <summary>
        /// Implementation of the ITrackableEventHandler function called when the
        /// tracking state changes.
        /// </summary>
        public void OnTrackableStateChanged(
                                        TrackableBehaviour.Status previousStatus,
                                        TrackableBehaviour.Status newStatus)
        {
            if (newStatus == TrackableBehaviour.Status.DETECTED ||
                newStatus == TrackableBehaviour.Status.TRACKED ||
                newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
            {
                OnTrackingFound();
            }
            else
            {
                OnTrackingLost();
            }
        }

        #endregion // PUBLIC_METHODS



        #region PRIVATE_METHODS


        private void OnTrackingFound()
        {
            Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

            // Enable rendering:
            foreach (Renderer component in rendererComponents)
            {
                component.enabled = true;
            }

            // Enable colliders:
            foreach (Collider component in colliderComponents)
            {
                component.enabled = true;
            }
			GetComponent<AudioSource> ().mute = false;
			drawButton = true;
			guiText = "Bomb found!";

            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
        }

		void OnGUI() {
			if (drawButton) {
				GUIStyle myButtonStyle = new GUIStyle(GUI.skin.button);
				myButtonStyle.fontSize = 50;
				myButtonStyle.normal.background = text;
				myButtonStyle.focused.background = text;
				myButtonStyle.hover.background = text;
				
				// Load and set Font
				Font myFont = (Font)Resources.Load ("Fonts/comic", typeof(Font));
				myButtonStyle.font = myFont;
				
				// Set color for selected and unselected buttons
				myButtonStyle.normal.textColor = Color.red;
				myButtonStyle.hover.textColor = Color.red;

				float butWidt = 270;
				float butHght = 110;

				if (GUI.Button (new Rect (Screen.width / 2 - butWidt / 2, Screen.height - 2 * butHght, butWidt, butHght),"", myButtonStyle)) {
					Handheld.Vibrate ();
					AndroidJavaClass jc = new AndroidJavaClass ("com.unity3d.player.UnityPlayer"); 
					AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject> ("currentActivity"); 
					jo.Call ("Launch");

				}
			}

			//draw text
			GUIStyle textStyle = new GUIStyle (GUI.skin.textArea);
			textStyle.fontSize = 30;

			Font myNewFont = (Font)Resources.Load ("Fonts/Normal", typeof(Font));
			textStyle.font = myNewFont;

			textStyle.normal.textColor = Color.green;
			textStyle.hover.textColor = Color.green;

			GUI.Label (new Rect (Screen.width / 2 - 175, Screen.height / 30, 330, 80), guiText, textStyle);
		
		}

        private void OnTrackingLost()
        {
            Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

            // Disable rendering:
            foreach (Renderer component in rendererComponents)
            {
                component.enabled = false;
            }

            // Disable colliders:
            foreach (Collider component in colliderComponents)
            {
                component.enabled = false;
            }
			GetComponent<AudioSource> ().mute = true;
			drawButton = false;
			guiText = "Bomb not found...";
            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
        }

        #endregion // PRIVATE_METHODS
    }
}
