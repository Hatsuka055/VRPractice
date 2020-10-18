using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Attention : MonoBehaviour
{

	[SerializeField]
	Transform headPositon;
	[SerializeField]
	Transform parentTrans;
	[SerializeField]
	float distance;
	[SerializeField]
	float alpha;
	[SerializeField]
	Color m_color;
	[SerializeField]
	Image image;
	
	// Start is called before the first frame update
    void Start()
    {
		if (!headPositon)
		{
			headPositon =  GameObject.Find("CenterEyeAnchor").transform;
		}
		alpha = 0f;
		image = this.GetComponent<Image>();
		parentTrans = this.transform.parent.parent;

    }

    // Update is called once per frame
    void Update()
    {
		if (Vector3.Distance(this.parentTrans.position, headPositon.position) < distance)
		{
			alpha = Mathf.Abs(Mathf.Sin(Time.realtimeSinceStartup));
			image.color = new Color(image.color.r, image.color.g, image.color.g, alpha);

		}else
		{
			alpha = 0f;
			image.color = new Color(image.color.r, image.color.g, image.color.g, alpha);
		}

    }
}
