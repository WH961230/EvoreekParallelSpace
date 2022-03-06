//----------------------------------------------
//      UnitZ : FPS Sandbox Starter Kit
//    Copyright © Hardworker studio 2015
// by Rachan Neamprasert www.hardworkerstudio.com
//----------------------------------------------

using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class DamageBase : NetworkBehaviour {
	[SyncVar]
	public int OwnerID;
	[SyncVar]
	public byte OwnerTeam;

}
