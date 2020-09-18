using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffhandGrabbable : OVRGrabbable
{
	protected OVRGrabber offhand;
	bool isScalable = false;
	float initDistance = 1;
	OVRGrabber reservedOffhand
	{
		get { return offhand; }
	}

	public override void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity)
	{
		if (this.grabbedBy && this.reservedOffhand)
		{

		}

		base.GrabEnd(linearVelocity, angularVelocity);

	}

	public void ReserveOffhand(EscapegameGrabber offhand)
	{
		this.offhand = offhand;
		this.initDistance = Vector3.Distance(offhand.transform.position, this.grabbedBy.transform.position);
		
	}
	public void ScaleEnable(bool scalable)
	{
		this.isScalable = scalable;
	}
	void Update()
	{
		if (isScalable)
		{
			//ここに拡大縮小のロジックを書く
			float grabbingDistance = Vector3.Distance(offhand.transform.position,
															this.grabbedBy.transform.position);

			this.transform.position = (	offhand.transform.position 
										+ this.grabbedBy.transform.position
										) / 2;
			this.transform.localScale *= grabbingDistance / initDistance;
		}

	}
}
