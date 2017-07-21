﻿/* *************************************************
*  Created:  7/20/2017, 2:04:16 PM
*  File:     AI_Base.cs
*  Author:   Benjamin
*  Purpose:  []
****************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace SB {

	[RequireComponent(typeof(NavMeshAgent),typeof(UnitProperty))]
	public class AI_Base : PooledObject {

		[System.NonSerialized]
		public UnitProperty property;
		// Use this for initialization
		protected NavMeshAgent agent;
		private Animator animator;
		Vector3 moveDirection = Vector3.zero;

		void Start () {
			InitComponet();
		}
		protected void InitComponet() {
			property = GetComponent<UnitProperty>();
			animator = GetComponent<Animator>();
			agent = GetComponent<NavMeshAgent>();
		}

		protected bool IsStoped {
			get { return agent.isStopped || !agent.hasPath;}
		}
		// Update is called once per frame
		void Update () {
			
		}
		void FixedUpdate () {
			if(animator)
				animator.SetFloat("forward",agent.velocity.magnitude);
		
		}
		
		void OnLevelWasLoaded () {
			ReturnToPool();
		}	
	}
}