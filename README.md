<p align="center">
	<a href="https://github.com/heligayakwad/IOT1026-Project/actions/workflows/ci.yml">
    <img src="https://github.com/heligayakwad/IOT1026-Project/actions/workflows/ci.yml/badge.svg"/>
    </a>
	<a href="https://github.com/heligayakwad/IOT1026-Project/actions/workflows/formatting.yml">
    <img src="https://github.com/heligayakwad/IOT1026-Project/actions/workflows/formatting.yml/badge.svg"/>
	<br/>
    <a href="https://codecov.io/gh/heligayakwad/IOT1026-Project" > 
    <img src="https://codecov.io/gh/heligayakwad/IOT1026-Project/branch/main/graph/badge.svg?token=JS0857X5JD"/> 
	<img title="MIT License" alt="license" src="https://img.shields.io/badge/license-MIT-informational?style=flat-square">	
    </a>
</p>

# IOT1026-Project
Write a description of your `Room` and `Monster` class here.
The IActivatable interface has been added to the new code, which also modifies the Monster class. The adjustments are listed below:

Many other types of monsters still use the Monster class as an abstract base class throughout the game. It now implements the IActivatable interface by giving an Activate function implementation. The abstract methods for assaulting the hero (Attack), transferring the monster to a different room (MoveToRoom), and determining whether the monster is in the hero's attacking arc (IsWithinAttackRange) are all available in the Monster class. Additionally, it contains abstract methods for displaying sensory data about the monster (DisplaySense), presenting the monster's present state, and displaying sensory data about the monster.

The IActivatable interface represents a system for turning on game elements. It merely declares the function Activate, which takes a Hero and a GameMap as inputs.



[Assignment Instructions](docs/instructions.md)  
[How to start coding](docs/how-to-use.md)  
[How to update status badges](docs/how-to-update-badges.md)
