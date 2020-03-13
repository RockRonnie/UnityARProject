 namespace Mapbox.Examples
{
    using Mapbox.Unity.MeshGeneration.Interfaces;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class InteractionScript : MonoBehaviour
    {
    [SerializeField] GameObject infoCanvas;
    // Update is called once per frame
    void Update()
    {   
         RaycastHit hit;
         for (var i = 0; i < Input.touchCount; ++i)
        {
            //Checking for touches
             if (Input.GetTouch(i).phase == TouchPhase.Began) 
             {
                  Unity.Utilities.Console.Instance.Log(
						 "touch detected"
						, "green"
					);
                    //Getting touch locations
                 Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);

                //If it hits something
                if(Physics.Raycast(ray, out hit))
                {
                    //Getting data from the target
                    var selection = hit.transform;
                    var selectionScript = selection.GetComponent<BarLabelText>();
                    Unity.Utilities.Console.Instance.Log(
						 "item selected"
						, "green"
					);
                    //If target object has a the script component we're looking for
                    if(selectionScript != null)
                    {
                        // Getting the information from the object into a variable.
                        var information = selectionScript.ShowMore();

                        Unity.Utilities.Console.Instance.Log(
						 "running the script"
						, "green");
                        // Getting the UI canvas element and script connected to it
                        var script = infoCanvas.GetComponent<ShowInformation>();
                         // Toggling it visible and sending it data.
                        script.ToggleInfo();
                        script.Set(information);  
                    // It doesn't have a script
                    }else{
                        Unity.Utilities.Console.Instance.Log(
						 "nothing here"
						, "red");
                    }
                }
         }
    }
    }
        
    }
}
