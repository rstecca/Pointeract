# Pointeract

Minimalistic interaction toolkit.  
Provides a directional, **gaze style pointer** in 3D with events and **teleport** capabilities, useful in VR, plus other tools related to the purpose.
**Google Cardboard SDK specific version.**

Pointeract is **not** designed to work with Unity's UGUI elements. The inteactivity is designed solely around 3D objects.

## Installation

This package must be installed via Unity Package Manager.

- Open Package Manager
- Click `+` to add a package.
- If you intend to modify the package content (code, assembly definitions, prefabs, ...) clone the repo and choose "Add package from disk...", otherwise (recommended) choose "Add package from git url..." and paste the following: "git@github.com:rstecca/Pointeract.git" or "https://github.com/rstecca/Pointeract.git"

## How it works

The DirectionalPointer class does all the work:
- Raycasts the scene to find colliders that own a component that implements one of the available interfaces: IPointable, IInteractable, ITeleportAnchor
- When one is found, OnPointerEnter, OnPointerStay, OnPointerExit, OnInteract, OnTeleportIn, OnTeleportOut events can be triggered.
- Such events are exposed in the available implementations: PointableEvents and TeleportAnchor.

## Quick Start

- Attach the DirectionalPointer component to an object. This is usually the camera but it can be an object that is driven by a controller or mouse.
- Create a 3D game object making sure it has a collider.
- Add a PointableEvents component.
- Populate the PointableEvents' events in the inspector.

For teleporting:
- Add a Teleporter component to an object. This is usually the parent of the camera object.
- Create a 3D game object making sure it has a collider.
- Add a TeleportAnchor component.
- Populate the TeleportAnchor's events sin the inspector.

## Create your own interactivity

PointableEvents is the more generic implementation that can be used straight away but you can create your own customized behaviours.
Take the script PointeractTester as an example. All you have to do is to implement one of the interfaces IInteractable or IPointable, or both. These will require you to write your own methods for the corresponding events.

The same goes for teleporting. You have the ready made, generic TeleportAnchor that implements ITeleportAnchor by exposing the events to Unity's Inspector but you can create your own class that implements the ITeleportAnchor interface.

## Adapt to other SDKs

The current version is meant to be used on the top of the new [Cardboard SDK](https://developers.google.com/cardboard/reference) [tested with com.google.xr.cardboard v1.8.0].
The only things that make Pointeract specific to Cardboard SDK are:
- A call in DirectionalPointer to get if the cardboard trigger was activated.
- The assembly definitions file in the package folder which link against Google.XR.Cardboard and Google.XR.Cardboard.Editor.
So Pointeract can be decoupled from Google.XR with a few relatively easy steps.

For example you might want to get rid of `Google.XR.Cardboard.Api.IsTriggerPressed` and replace it with something that checks if the Input.touches[0] exists and is in Begun phase.