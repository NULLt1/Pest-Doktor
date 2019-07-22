using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LocationBasedGame
{

    public class SaveGameHandler : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private Save CreateSaveGameObject()
        {
            return null;
            /*
            Save save = new Save();
            int i = 0;
            foreach (GameObject targetGameObject in targets)
            {
                Target target = targetGameObject.GetComponent<Target>();
                if (target.activeRobot != null)
                {
                    save.livingTargetPositions.Add(target.position);
                    save.livingTargetsTypes.Add((int)target.activeRobot.GetComponent<Robot>().type);
                    i++;
                }
            }

            save.hits = hits;
            save.shots = shots;

            return save;
             */
        }
    }

}