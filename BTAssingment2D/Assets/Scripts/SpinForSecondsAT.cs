using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class SpinForSecondsAT : ActionTask<Transform> {

        public BBParameter<float> duration;
        public BBParameter<float> spinSpeed; //  IN degrees per second

        private float elapsedTime = 0f;
        private Quaternion originalRotation;

        private MonoBehaviour aiChaseScript;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
            elapsedTime = 0f;
            originalRotation = agent.rotation;

            if (aiChaseScript != null) // Disabled script
            {
                aiChaseScript.enabled = false;
            }
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {

            elapsedTime += Time.deltaTime;

            agent.Rotate(Vector3.forward, spinSpeed.value * Time.deltaTime); // Rotate around Z-axis

            if (elapsedTime >= duration.value)
            {

                if (aiChaseScript != null) // Enabled Script
                {
                    aiChaseScript.enabled = true;
                }
                EndAction(true);
            }
        }

		//Called when the task is disabled.
		protected override void OnStop() {

            agent.rotation = originalRotation; // Reset rotation

        }

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}