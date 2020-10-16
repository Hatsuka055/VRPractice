using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
public class Attention : MonoBehaviour
{

	[SerializeField]
	Transform headPositon;
	[SerializeField]
	float distance;
	Color color;
	[SerializeField]
	Image image;
	public float hoge;
	
	// Start is called before the first frame update
    void Start()
    {
		if (!headPositon)
		{
			GameObject.Find("CenterEyeAnchor");
		}
		color = GetComponent<Color>();
		image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
	//	if (Vector3.Distance(this.transform.position, headPositon.position) < distance)
		{
			color.a = Mathf.Abs(Mathf.Sin(Time.realtimeSinceStartup))*100;
			image.tintColor = color;
		}
    }
}
