Project Nyx: 

Design Overview

1. Core Concept

Genre: 2D Top-Down Space RTS / Cosmic Horror / Automation / RPG. Style: High-fidelity Pixel Art with dynamic lighting (URP 2D). Perspective: Top-down view of a singular hero ship. Think Galaxy Genome, Vanguard Galaxy, Star Valor, Starcom: Unknown Space/Starcom Nexus



2. Narrative & Setting

The World: The universe has undergone "The Dimming" (name subject to change) Stars are dying, and space is filled with eldritch Horrors (name TBD)

The Protagonist: You are the captain of a ship (player gets to name it but will also have random names  if they don't want to ) , you start the game creating your captain and their starting history, aka (war hero, Mechanic, scholar, etc) these prior jobs will effect some of your starting skills and your starting ship.



while on the tutorial mission you discover some ancient looking metal that you bring aboard your ship just for it to glow and meld to your ship,


The Copilot (AI): Fused to your ship’s mainframe is HELIOS(working name subject to change), an ancient, fragmenting AI from the Golden Age. Helios is logical but glitchy and missing personality and memories  and learns to communicate by ingesting your ship's data. and cycles through a few AI personalities from the media files on the ship before settling on a sarcastic yet helpful personality (think a mix of HK-47 from KOTOR, Skippy from the expeditionary series of books, and Cortana from halo.) 





Act 1 
starts in the Sol system where your primary enemies are pirates, and/or governments of Earth (think  like how earth is split up in to major earth faction/goverments like how they are in the bobbiverse book series) we will have Corporate states and governments running things



with pirates and Independents the further out you go from earth. the player can pick and choose who to work with and gain faction loyalty with or can choose to do their own thing.



from there act one is mostly discovering the sol systems wonders, leveling getting money build up there own personal Faction/mercenary group/company/ station whom they can choose to work with or for all while building up allegiances and gaining "heros" (talented individuals that can run your faction while your off exploring, act as Bridge crew on your ship for bonuses to things you do and open up other options for missions (like if you are or you have a war hero on board you can get special ways to finish specific missions) or eventually captain ships to help automate your eventual factions spread through the star's



the AI can do some automatic tasks for you at a EXP and reward penalty but the more you repair of its AI matrix the less of a penalty it has and the more it can do (think like if the player wants to mine a bunch but doesn't want to do it manually you can set the AI to do it like its an idle clicker game) however the AI has a limited amount of time it can act without you before it needs "human input" which is a hard coded restriction by its creator's





While doing all of this you learn a tiny amount from the AI while it helps you in researching new tech to eventually develop a warp drive. you then go to test it as no ship has been able to breach the heliopause part of the supersystem. 



but upon activation of the drive you unknowingly rip a “hole” in the heliosphere which turns out to be a super advanced forcefield/clocking field hiding and protecting Sol from the wider galaxy.

And discover ancient monolith constructions in deep space that you eventually learn how to repair or activate and they open wormholes to fast travel great distinces.


Act 2

at first no aliens detect the breach but as you fly around exploring you meet some and learn not all are friendly but most are begrudgingly allied in a hodgepodge alliance of sorts fighting for their lives against the "corrupted ones" which are other alien species that you later find out have been absorbed by the Eldritch monsters and are used as vassals while the "elder gods" sleep 



During all of this you can continue to expand your faction and gain the trust of other species to either eventually join them or absorb them into a grand alliance you lead.



the more you do though the more you risk the elder ones waking up.



you continue to do this till you wake the first elder one and upon a mad dash to kill it before it can wake the others you learn that there are things built by the AI builders called "sentinals" that exist sleeping as well so you go off to try and learn what you can of them 



Act 3



In act 3 you still continue doing the faction stuff, setting up trade routes and fleets to combat the corrupted ones while you search for a way to stop the elder one. While doing all of this you learn that the oldest of the aliens you are in contact with know of where a sentinel is adrift at an unmarked dark star. and you learn that no one has ever been able to get inside it.



upon this you fetch the lead scientist of the oldest race and head to the sentinel while they are trying to figure it out a fleet of corrupted ones followed you and in a last ditch effort you dock with the sentinel when all of a sudden your AI links to it and then you get scanned and it reactivates saying a garbled alien language your AI can semi translate to something about "its an honor to serve Mother/father (depends your gender) and you being confused on your ship you watch as the sentinel powers up and the in combat with the corrupted fleet wipes them out just for the elder one to show up and they destroy each other ion the process. but not before the elder was able to send off the "wake up call"



Act 4.



in act 4 you race around the galaxy tring to find more sentinels and learn what the fuck is going on, you eventually learn that Humanity as we know it is not the first evolution of human’s and in fact the AI’s creators the one who made the warp gates but long ago the first humans being one of the first races in the galaxy attempting to find a way to make warp speed faster accidentally did something in which eldritch horrors started to pour out of a rip/tear/wormhole over the homeworld of the ancient humans devouring everything.

After thousands of years of them fighting the Eldritch horrors they realized the only way to stop them would be to implement a plan in which they created the sentinels, to spread and fight the eldritch old ones and self replicate to hopefully eradicate them from the galaxy, during this they developed a technology that allowed them to hold blank humans awaiting genetic code to basically make a clone of someone and then transfer a copy or the consciousness of the person in to the body effectively cheating death (kinda like the human cylons in battlestar galactica) and they set up failsafe worlds like Earth in which if they where to loose the war the minds of the best of the race could be downloaded in to back ups that where hidden (think shield worlds from halo but whole systems) and then they could plan how to rebuild.

However something went wrong and the minds never got downloaded to the bodies and the bodies were released with nothing but basic instincts (aka cavemen) and then all of human history later here you are a descendant of the creators and that's why the sentinels and the AI listens to you (to a point)

 
Act 5 final act

After the bombshell realization you realize that the elder ones have been cleansing, eating the galaxy for millions of years while the humans “slept” its been an endless reaping cycle over and over (think the wraith from stargate atlantis mixed with the reapers from mass effect but in the form of bioorganic eldritch horror’s) and you now have to fly around and play gardner finding and reactivating the sentinels you can find to then have some minor control over them before the eldritch horrors can fully wake up for the slumber waiting for the galaxy to be repopulated in order to put a stop to the reaping once and for all.


3. Gameplay Mechanics

A. The "Gardener of War" System (Unique Selling Point)

Unlike traditional RTS games, you do not build the sentinel units from a factory UI.

You can build your own forces but to kill the eldritch you need the sentinals.


Discovery: You explore the dark fog of war to find dormant, drifting hulks of ancient warships (Sentinels).

Rebooting: You spend energy/resources to "Reboot" these ships.

Logic: Once rebooted, they are not directly controllable. They follow a FlockingBehavior code, seeking eldritch horrors, patrolling specific beacons you place. They automatically engage threats.Coding implication: We will need a robust Finite State Machine (FSM) for the AI units (States: Dormant, Booting, Patrol, Engage).

B. Economy & Automation

Mining: You use a laser to fracture asteroids.

Drones: You deploy CollectorDrones that automatically pick up ore and bring it back to the ship.

Resource Loop: Ore $\rightarrow$ Refined Material $\rightarrow$ Energy (Fuel/Ammo).

C. The Enemy (corrupted ones)

Enemies are biological, swarm-based entities.


Coding implication: "Swarm" boid algorithm for enemy eldritch movement.

Eldritch horrors (the old ones)

Near impossible to kill without sentinals



4. Technical Architecture

To achieve this, we planned the following structure:



Engine: Unity 6 LTS.

Pipeline: Universal Render Pipeline (URP) with 2D Lighting.

Input: New Unity Input System (Touch support for Mobile, Keyboard/Mouse for PC).

Save System: JSON serialization for cross-platform save parity.
