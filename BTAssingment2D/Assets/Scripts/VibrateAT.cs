using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using System.Collections;


namespace NodeCanvas.Tasks.Actions {

	public class VibrateAT : ActionTask<Transform> {

		public float duration;
		public float magnitude;

        private Vector3 originalPos;
        private MonoBehaviour aiChaseScript; // Getting my script to disabled it so i can stop moving

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {

            aiChaseScript = agent.GetComponent<AIChase>();
            return null;

        }

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {

            originalPos = agent.localPosition;

            if (aiChaseScript != null) // Disabled script
            {
                aiChaseScript.enabled = false;
            }

            StartCoroutine(Vibrate());

        }

        private IEnumerator Vibrate()
        {
            float elapsed = 0f;

            while (elapsed < duration) // True while elapsed time is less then set duration
            {
                float offsetX = Random.Range(-1f, 1f) * magnitude; // Vibrating the thang with random offsets times set magnitude
                float offsetY = Random.Range(-1f, 1f) * magnitude;

                agent.localPosition = originalPos + new Vector3(offsetX, offsetY, 0f); // Shmoving
                elapsed += Time.deltaTime;

                yield return null;
            }

            agent.localPosition = originalPos;

            if (aiChaseScript != null) // Enabled again
            {
                aiChaseScript.enabled = true;
            }

            EndAction(true);
        }

        //Called once per frame while the action is active.
        protected override void OnUpdate() {
			
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}