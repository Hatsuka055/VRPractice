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
	[SerializeField] EscapegameGrabber conRight;
	[SerializeField] EscapegameGrabber conLeft;

	override protected void OffhandGrabbed(OVRGrabbable grabbable){
		//両手持ち可能なGrabbableだった場合、
		//1,もう片方の手の情報を渡す
		//2,拡大縮小モードをONにする
		if (m_grabbedObj  == grabbable){
			if (grabbable.GetComponent<OffhandGrabbable>()) {
				var cast = grabbable.GetComponent<OffhandGrabbable>();
				cast.InitializeDistance(conRight,conLeft);
				cast.ScaleEnable(true);
				cast.reservedHand = (EscapegameGrabber) grabbable.grabbedBy;
				GrabbableRelease(Vector3.zero, Vector3.zero);
			}
			else
			{
				GrabbableRelease(Vector3.zero, Vector3.zero);
			}
		}
    }
	public void executeGrabBegin()
	{
		base.GrabBegin();
	}
	public void executeGrabEnd()
	{
		base.GrabEnd();
	}
	public void executeGrabableRelease()
	{
		base.GrabbableRelease(Vector3.zero,Vector3.zero);
	}
	public OVRInput.Controller offhand
	{
		get { return this.m_controller; }
	}
	//EscapegameGrabberでgripTransformを取得するためにprotectedを強引に回避
	public Transform attachedGriptransform
	{
		get { return m_gripTransform; }
	}

}
