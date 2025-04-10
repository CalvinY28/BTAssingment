using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class BirdArmyAT : ActionTask<Transform> {

        public GameObject birdPrefab;
        public GameObject poopPrefab;

        public BBParameter<int> birdCount;
        public BBParameter<float> spacing;
        public BBParameter<float> speed;
        public BBParameter<float> poopDropInterval;
        public BBParameter<float> flightHeight;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {

            Vector3 startPos = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 10)); // Spawn at top left, z=10 becasue I cant see the birds for some reason
            startPos.y = agent.position.y + flightHeight.value;

            for (int i = 0; i < birdCount.value; i++) // Looping bird spawns
            {
                Vector3 pos = startPos + Vector3.down * spacing.value * i; // Stacking them
                GameObject bird = Object.Instantiate(birdPrefab, pos, Quaternion.identity); // Instantiating
                bird.AddComponent<CarpetBomb>().Initialize(speed.value, poopPrefab, poopDropInterval.value); // Giving it the pooping ability
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