26/08/18
- added a dumb script to add score when the sentry is destroyed (there are probably an infinite amount of ways for this to be implemented better)
- modified the music script to include ambience since they start and stop at the same points anyway.
- added a new power-up (power-down?) drunk effect! it wobbles the screen and the audio (SEE AUDIO README) (additionally added shaders, a urp specific renderer, etc etc)
- changed speedup in the powerup script to drunk and implemented hookups there for drunk effect

26/08/17
- added blue collectible spawners that spawn a shotgun, sniper, grenade launcher, or a health pack continuously
- collectible spawner now spawns just the fire rate increase upgrade
- added more raycasthit cases to the sniper in the weaponsystem script
- added a health ui component
- reintroduced the target spawner, for now just spawns the targets facing the player for a (sort of) weeping angel effect anywhere in the spawn bounds (may change in the future, not a priority, its a FEATURE of the level :nodding:

26/08/13
-added multiple sounds to the wwise project (CHECK SOUNDREADME)
-changed the projectiles that the enemy shoots to be enemy paintballs due to a bug with having all the diff paintball logic on one paintball caused the player to shoot themselves many times when running in the direction they shot in. player paintballs now shoot collision based detection, and enemies now shoot raycast based detection

26/08/04
-added a music manager object with a music manager script. Get this, it manages all the music...
It also has callbacks that pulse the lights on the beat, and change the color on the bar

26/08/03
-added new spawner script for overall generic use. It will detect if an object of a certain layer is currently hitting a raycast and when there is NO object it will spawn a new one, currently implemented in the level as 4 sentry spawners surrounding the player.

26/07/29 PM
-added placeholder stuff in wwise project (empty sounds and hierarchies and set up some game syncs)
- XX added AKwiseEvents in new generic SoundAndDestory.cs, as well as active grenade, paintball, and weapon system. [THIS IS DEPRECATED SOUND AND DESTROY WAS NOT WORKING AS INTENDED NEW VERSION OF THIS IS THE OnDestroyHit/DoSound stuff] XX

26/07/29
-imported a modeled and rigged sentry turret (created by yours truly ;3) inspired by the tf2 level 1 turret
-Implemented a tracking system that detects when a player walks within range of it and when it sets it's crosshairs on the player begins to fire basic paintballs (might make it so that the rotation speed is faster than the player making it harder to avoid and force you to kill it)
-implemented health for both the player and sentry and added takedamage triggers to the paintball script
-on death, the sentry is destroyed, and on death the player is sent to the finish screen.

26/07/22
missed a readme pull from other PC ughhhhhhhhhhhhhh cant be bothered to remember specifically what was added
-mostly added new targets and implemented target classes

26/07/19
-added a weapon switch function to visually swap out weapons when the player picks up a collectible
-imported visuals for weapon

26/07/17
-added a testtone event to wwise, and implemented it into a generic fire event for the weapon system.