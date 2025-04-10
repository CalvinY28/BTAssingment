using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class PulsateForSecondsAT : ActionTask<Transform> {

        public BBParameter<float> duration;
        public BBParameter<float> pulseSpeed;
        public BBParameter<float> scaleAmount; // How much it grows/shrinks

        private Vector3 originalScale;
        private float elapsed;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
            originalScale = agent.localScale;
            elapsed = 0f;
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {

            elapsed += Time.deltaTime;

            float scaleOffset = Mathf.Sin(elapsed * pulseSpeed.value) * scaleAmount.value; // Pulsate using a sine wave
            agent.localScale = originalScale + Vector3.one * scaleOffset;

            if (elapsed >= duration.value)
            {
                EndAction(true);
            }

        }

		//Called when the task is disabled.
		protected override void OnStop() {
            agent.localScale = originalScale; // reset
        }

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}