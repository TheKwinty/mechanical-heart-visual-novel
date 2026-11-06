using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DIALOGUE;

namespace TESTING
{
    public class Testing_Architect : MonoBehaviour
    {
   
        DialogueSystem ds;
        TextArchitect architect;

        public TABuilder.BuilderTypes bm = TABuilder.BuilderTypes.Fade;

        string[] lines = new string[5]
        {
            "Понали мать вашу.",
            "Ми знайдемо роботу з'їдемося з булочкою і мені куплять моті!",
            "Все буде заєбісь, бо ми команда цибуляток!",
            "Мяу.",
            "Ia duje veri sori."
        };

        // Start is called before the first frame update
        void Start()
        {
            ds = DialogueSystem.instance;
            architect = new TextArchitect(ds.dialogueContainer.dialogueText, bm);
            architect.speed = 1.0f;
        }

        // Update is called once per frame
        void Update()
        {
            if (bm != architect.builderType)
            {
                architect.SetBuilderType(bm);
                architect.Stop();
            }

            if (Input.GetKeyDown(KeyCode.S))
                architect.Stop();

            //string longLine = "this is a very long line that makes no sense but I am just populating it with stuff because, you know, stuff is good right? I like stuff, you like stuff, we all like stuff and the turkey gets stuffed.";
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (architect.isBuilding)
                {
                    if (!architect.hurryUp)
                        architect.hurryUp = true;
                    else
                        architect.ForceComplete();
                }
                else
                    //architect.Build(longLine);
                    architect.Build(lines[Random.Range(0, lines.Length)]);
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                //architect.Append(longLine);
                architect.Append(lines[Random.Range(0, lines.Length)]);
            }
        }
    }
}