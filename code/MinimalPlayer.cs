﻿using Sandbox;

partial class MinimalPlayer : Player {
	public override void Respawn() {
		SetModel("models/citizen/citizen.vmdl");

		Controller = new WalkController();

		Animator = new StandardPlayerAnimator();

		Camera = new ThirdPersonCamera();

		EnableAllCollisions = true;
		EnableDrawing = true;
		EnableHideInFirstPerson = true;
		EnableShadowInFirstPerson = true;

		base.Respawn();
	}

	public override void Simulate(Client client)
	{
		base.Simulate(client);

		SimulateActiveChild(client, ActiveChild);

		if (IsServer && Input.Pressed(InputButton.Attack1)) {
			var ragdoll = new ModelEntity();
			ragdoll.SetModel( "models/citizen/citizen.vmdl" );
			ragdoll.Position = EyePos + EyeRot.Forward * 40;
			ragdoll.Rotation = Rotation.LookAt(Vector3.Random.Normal);
			ragdoll.SetupPhysicsFromModel(PhysicsMotionType.Dynamic, false);
			ragdoll.PhysicsGroup.Velocity = EyeRot.Forward * 1000;
		}
	}

	public override void OnKilled() {
		base.OnKilled();

		EnableDrawing = false;
	}
}
