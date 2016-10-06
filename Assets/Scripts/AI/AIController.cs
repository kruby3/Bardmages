using UnityEngine;
using System.Collections.Generic;

namespace Bardmages.AI {
    /// <summary>
    /// Controls AI bardmages.
    /// </summary>
    abstract class AIController : MonoBehaviour {

        /// <summary> The AI component for generating tunes. </summary>
        protected AIBard bard;
        /// <summary> The AI component for moving. </summary>
        protected AIControl control;

        /// <summary> The rhythms that are recognized for perfect attacks. </summary>
        protected List<LevelManager.RhythmType> enabledRhythms;

        /// <summary> All players in the scene. </summary>
        protected List<BaseControl> otherPlayers;

        /// <summary>
        /// Registers the AI in the level and finds the other players.
        /// </summary>
    	private void Start() {
            bard = GetComponent<AIBard>();
            control = GetComponent<AIControl>();
            enabledRhythms = LevelManager.instance.EnabledRhythms;
            LevelControllerManager.instance.AddPlayer(control.player, control);
            bard.timingVariance = 0.1f;

            MinionTuneSpawn minion = GetComponent<MinionTuneSpawn>();
            PlayerID selfID;
            if (minion != null) {
                selfID = minion.owner;
            } else {
                selfID = control.player;
            }

            otherPlayers = new List<BaseControl>();
            BaseControl[] otherPlayersArray = FindObjectsOfType<BaseControl>();
            foreach (BaseControl otherPlayer in otherPlayersArray) {
                if (otherPlayer.player != selfID && otherPlayer.GetComponent<MinionTuneSpawn>() == null) {
                    otherPlayers.Add(otherPlayer);
                }
            }

            InitializeAI();
    	}

        /// <summary>
        /// Changes any needed settings for the AI.
        /// </summary>
        protected virtual void InitializeAI() {
        }

        /// <summary>
        /// Updates the controller.
        /// </summary>
        private void Update() {
            bard.UpdateTune();
            control.UpdateControl();
            UpdateAI();
        }

        /// <summary>
        /// Updates the AI's actions.
        /// </summary>
        protected abstract void UpdateAI();

        /// <summary>
        /// Gets the closest player to the AI by distance.
        /// </summary>
        /// <returns>The closest player to the AI.</returns>
        protected BaseControl GetClosestPlayer() {
            BaseControl closestPlayer = null;
            float closestDistance = Mathf.Infinity;
            foreach (BaseControl player in otherPlayers) {
                float distance = Vector3.Distance(transform.position, player.transform.position);
                if (distance < closestDistance) {
                    closestPlayer = player;
                    closestDistance = distance;
                }
            }
            return closestPlayer;
        }
    }
}