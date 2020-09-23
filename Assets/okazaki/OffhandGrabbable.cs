using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using UnityEditor;

public class OffhandGrabbable : OVRGrabbable
{
	
	protected EscapegameGrabber offhand;
	bool isScalable = false;
	[SerializeField]float initDistance = 1.11111f;
	[SerializeField] EscapegameGrabber reserved;

	Vector3 scaleBuffer;

	//grabbedByを継承クラスにキャストするためのプロパティ
	EscapegameGrabber grabbedBy_4Escapegame
	{
		set { m_grabbedBy = value; }
		get { return (EscapegameGrabber)this.grabbedBy; }
	}

	//最初に掴んでいた方の手をオブジェクトが記憶するためのプロパティ
	public EscapegameGrabber reservedHand
	{
		set
		{
			if (value is EscapegameGrabber)
			{
				this.reserved = value;
			}
		}

		get { return this.reserved; }
	}

	public override void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity)
	{
		
		if (isScalable)
		{
			

		}

		base.GrabEnd(linearVelocity, angularVelocity);

	}
	
	public void InitializeDistance(EscapegameGrabber right,EscapegameGrabber left)
	{
		scaleBuffer = this.transform.localScale;
		if(this.grabbedBy == right)
		{
			this.initDistance = Vector3.Distance(left.attachedGriptransform.position, 
												this.grabbedBy_4Escapegame.attachedGriptransform.position
												);
			this.offhand = right;
		}else if(this.grabbedBy == left)
		{
			this.initDistance = Vector3.Distance(right.transform.position,
												this.grabbedBy_4Escapegame.attachedGriptransform.position
												);
			this.offhand = left;

		}

	}

	public void ScaleEnable(bool scalable)
	{
		this.isScalable = scalable;
	}
	void Update()
	{
		
		//掴んでる物があり、かつもう片方の手もつかんでる時
//		if (grabbedBy_4Escapegame && this.offhand) {
			float triggerBuffer = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, this.offhand.offhand);
			float triggerBuffer2 = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, this.grabbedBy_4Escapegame.offhand);
			if (triggerBuffer <= this.offhand.grabEnd || triggerBuffer2 <= this.offhand.grabEnd)
			{
				Debug.Log("後からつかんだ方の手を放した");
				if(!grabbedBy_4Escapegame )
				{
					grabbedBy_4Escapegame = offhand;
					GrabEnd(Vector3.zero,Vector3.zero);
				}
				this.offhand = null;
				ScaleEnable(false);
					
			}
			
//		}

		if (isScalable)
		{
			
			if(grabbedBy_4Escapegame != this.offhand)
			{

				//ここに拡大縮小のロジックを書く
				float grabbingDistance = Vector3.Distance(offhand.transform.position,
																this.grabbedBy.transform.position);
				Debug.Log("Update時offhand = " + this.offhand.name);
				Debug.Log("Update時grabbedBy = " + grabbedBy.name);
				Debug.Log(grabbedBy.name + "と" + offhand.name + "の距離 " + grabbingDistance);
				Debug.Log("両手でつかんでる:"+ grabbingDistance);
				this.transform.position = (	offhand.attachedGriptransform.position 
											+ this.grabbedBy_4Escapegame.attachedGriptransform.position
											) / 2;
				Debug.Log("initDistance = " + this.initDistance);
				float scale = grabbingDistance / this.initDistance;
				Debug.Log("localscale=" + this.transform.localScale);
				this.transform.localScale = new Vector3(
					this.scaleBuffer.x * scale,
					this.scaleBuffer.y * scale,
					this.scaleBuffer.z * scale
				);
				Debug.Log("スケール："+this.transform.localScale);
			}

			
			
		}


	}
}
