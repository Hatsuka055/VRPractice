using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapegameGrabber : OVRGrabber
{
	// Start is called before the first frame update
/*	private void Start()
	{
		base.Start();
	}
	override protected  void GrabBegin()
    {
        base.GrabBegin();
    }*/

	override protected void OffhandGrabbed(OVRGrabbable grabbable){
		//両手持ち可能なGrabbableだった場合、
		//1,もう片方の手の情報を渡す
		//2,拡大縮小モードをONにする
		if (m_grabbedObj  == grabbable){
			if (grabbable.GetComponent<OffhandGrabbable>()) {
				var cast = grabbable.GetComponent<OffhandGrabbable>();
				cast.ReserveOffhand(this);
				cast.ScaleEnable(true);
				GrabbableRelease(Vector3.zero, Vector3.zero);
			}
			else
			{
				GrabbableRelease(Vector3.zero, Vector3.zero);
			}
		}
    }
}
