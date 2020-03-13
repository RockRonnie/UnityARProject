 namespace Mapbox.Examples
{
	using Mapbox.Unity.MeshGeneration.Interfaces;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.UI;

	public class BarLabelText : MonoBehaviour, IFeaturePropertySettable
	{
		//AR Label object
		[SerializeField]
		Text _text;
		[SerializeField]
		Image _background;

		//Dictionary for storing the GeoJson
		Dictionary<string,object> theseProps = new Dictionary<string, object>();

		string name = "";

		public void Set(Dictionary<string, object> props)
		{
			//Checking if the GeoJson props contains a name and showing it on the label, saving the props for later use
			_text.text = "";
			theseProps = props;

			if (props.ContainsKey("name"))
			{
				name = props["name"].ToString();	
				_text.text = props["name"].ToString();
			}
			RefreshBackground();
		}
		//Making the background match the text
		public void RefreshBackground()
		{
			RectTransform backgroundRect = _background.GetComponent<RectTransform>();
			LayoutRebuilder.ForceRebuildLayoutImmediate(backgroundRect);
		}
		
		//Public function for other elements in the application to get the data from this object.
		public Dictionary<string,object> ShowMore()
		{	
			Unity.Utilities.Console.Instance.Log(
							"Showmore function ran"
						, "Purple"
					);
			return theseProps;
		}
	}
}