# Unity Interactable Objects Outliner System

A lightweight, interface-driven interaction system for Unity that triggers visual outlines and interaction events when an object is targeted by the player's crosshair. Designed for performance-conscious first-person and third-person games.

---

## 📜 Included Scripts

* IInteractable
* InteractionRaycaster.cs
* InteractableObject.cs

---

## ✨ Features

* **Interface-Driven Architecture:** Uses IInteractable, allowing any script to become "interactable" without complex inheritance.
* **Performance Optimized:** A single Raycast from the camera handles all detection, avoiding expensive distance checks on every object in the scene.
* **Decoupled Logic:** The Raycaster doesn't care *how* an object outlines; it simply triggers the OnHoverEnter and OnHoverExit events.
* **Layer Masking:** Optimized to only "see" objects on specific layers, preventing unnecessary physics calculations.
* **Clean Code:** Written with SOLID principles in mind—easy to read, easy to extend.

---

## 🧠 Design Notes

The system operates on a **Provider-Receiver** model. The InteractionRaycaster (Provider) acts as the player's "eyes," while any object implementing IInteractable (Receiver) handles its own visual state.



By using an Interface instead of a concrete class, you can have a Door script and a Healing Item script that behave completely differently but both react perfectly when the player looks at them. This keeps your codebase modular and scalable.

---

## 🧩 How To Use

1.  **Project Setup:**
    * Create a new **Layer** in Unity called Interactable.
    * Ensure your interactable 3D objects have a **Collider** component.
2.  **Player Setup:**
    * Attach the InteractionRaycaster.cs script to your **Main Camera**.
    * In the Inspector, set the Interactable Layer to your newly created Interactable layer.
3.  **Object Setup:**
    * Attach the InteractableObject.cs script to your prop.
    * Add your preferred **Outline** component (or shader script) to the same object.
    * Link the Outline component to the Outline field in the InteractableObject inspector.
4.  **Run:**
    * Move your crosshair over the object. The OnHoverEnter() method will fire, enabling the outline.

---

## 🚀 Possible Extensions

* **UI Integration:** Fire a C# Action when hovering to show "Press E to Open" on the player's HUD.
* **Distance Scaling:** Modify the interactRange dynamically based on player stats or item size.
* **Hold-to-Interact:** Add a timer to the Update loop in the Raycaster to support "charging" an interaction (e.g., searching a crate).
* **Visual Polish:** Integrate with the Unity Volume system to add a glow effect to the entire screen when looking at high-value targets.

---

## 🛠 Unity Version

Tested in Unity6+ (should also work without problems in the newer versions).

---

## 📜 License

MIT
