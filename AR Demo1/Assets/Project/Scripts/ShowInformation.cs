 namespace Mapbox.Examples
{
using Mapbox.Unity.MeshGeneration.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowInformation : MonoBehaviour
{
	//UI Elements
    [SerializeField]
	TextMeshProUGUI _name;
	[SerializeField]
	TextMeshProUGUI _body;
    [SerializeField]
	GameObject _UI;
	 [SerializeField]
	GameObject _infoButton;
	 [SerializeField]
	GameObject _openButton;
	 [SerializeField]
	GameObject _addressButton;

	//Variables
    string name = "";
	string address = "";
	string postalCode = "";
	string city = "";
	string url = "";
	string description = "";
	string images = "";
	string state = "";

	//Original color and the highlight color
	Color originalColor = new Color(0.1294118f,0.04313726f,0.007843138f,0.9803922f);
	Color32 selectedColor = new Color(0.29f,0.11f,0.03f,0.98f);

	Dictionary<string, string> open = new Dictionary<string, string>();
		public void Set(Dictionary<string, object> props)
		{
			_name.text = "";
			_body.text ="";
			//Umm.... loads of if elses? just getting the data from the source...
			if (props.ContainsKey("name"))
			{
				name = props["name"].ToString();
			}
            else{
                name = "No name";
            }
			if (props.ContainsKey("address"))
			{
				address = props["address"].ToString();
			}
            else{
                address = "No address";
            }
			if (props.ContainsKey("postal code"))
			{
				postalCode = props["postal code"].ToString();
			}
            else{
               postalCode = "No postal code";
            }
			if (props.ContainsKey("city"))
			{
				city = props["city"].ToString();
			}else{
                city = "No city";
            }
			if (props.ContainsKey("url"))
			{
				url = props["url"].ToString();
			}
            else{
                url = "No url";
            }
			if (props.ContainsKey("description"))
			{
				description = props["description"].ToString();
			}else{
                description = "No description";
            }
			if (props.ContainsKey("opening hours"))
			{
				Dictionary<string, object>.KeyCollection keyColl = props.Keys;
				foreach( object myObject in keyColl )
				{
    					Unity.Utilities.Console.Instance.Log(
						myObject.ToString()
						, "yellow");	
				}			
				open.Add("monday","No opening hours information available");
			}else{
                open.Add("monday" ,"No opening hours information available");
            }
			if (props.ContainsKey("images"))
			{
				images = props["images"].ToString();
			}else{
                images = "No image url found";
            }
           	UpdateUI();
			Unity.Utilities.Console.Instance.Log(
						 "Everything SET"
						, "green");
		}
		//Toggling the menu visibility
        public void ToggleInfo(){
			_UI.SetActive(!_UI.activeSelf);
			Invoke("UpdateUI", 1);
			Unity.Utilities.Console.Instance.Log(
						 string.Format("UI SET TO STATE {0}", _UI.activeSelf)
						, "green");		
		}
		//Updating the UI
        private void UpdateUI() {
			_name.text = name;
			state = "info";
			SelectedTab(state);
			ChangeColor("info");
        }
		//Changing the state and tab based on it
		public void ChangeState(string newState){
			state = newState;
			SelectedTab(state);
		}
		//Changing the color of the buttons
		private void ChangeColor(string button){
			_infoButton.GetComponent<Image>().color = originalColor;
			_addressButton.GetComponent<Image>().color = originalColor;
			_openButton.GetComponent<Image>().color = originalColor;
			switch (button)
			{
				case "info": _infoButton.GetComponent<Image>().color = selectedColor;
					break;
				case "open": _openButton.GetComponent<Image>().color = selectedColor;
					break;
				case "address": _addressButton.GetComponent<Image>().color = selectedColor;
					break;
				default: 
					break;
			}
		}
		//Switching the tab
		public void SelectedTab(string tab){
			switch (tab)
			{
				case "info": 
				_name.text = name;
				_body.text = description;
				ChangeColor("info");
					break;
				case "open": 
				_name.text = name;
				_body.text = open["monday"];
				ChangeColor("open");
					break;
				case "address": 
				_name.text = name;
				_body.text = string.Format("{0} \n {1} \n {2} \n", address, city, postalCode);
				ChangeColor("address");
					break;
				default: 
				_name.text = name;
				_body.text = description;
					break;
			}
		}
}
}