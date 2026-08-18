26/08/18
- added ambience into the new modified musicambience script
- added reverb to all SFX (technically an effect)
- added a "drunkmolo" effect that when affected by drunk, makes all the sounds wobbly sounding. states are being set in the drunkeffect script.

26/08/17
- implemented target break events, and attached them to the DoSound script in the prefabs OnHitDestroy_CowTarget and _Target
- implemented target spawn events on each target prefab
- implemented paintball hit sound on the paintball prefab
- implemented sniper hit sound on weaponsystem script
- added a basic attenuation for positional sounds

26/08/15
- Created new DoSound script that allows for a generic sound event (any sound you assign within the inspector) to play on any Unity event, or when called by another object
- also added a variable to this DoSound script that will check if this is a "destroy object" sound, which essentially means that if this object is meant to play in the position of another object that is destroyed or otherwise doesn't have its own object (the sniper hit position) then this sound will be instantiated in its place and played. if this bool is not checked then it will do nothing 

26/08/13
- Implemented many weapon sounds into the project, as well as UI sounds in main menu and the game (they currently do not transfer over load times)
- Implemented weapon switch and weapon fire events into the WeaponSystem script
- music has an rtpc effect connected to the player speed where the trumpet and drums get louder when the player is moving