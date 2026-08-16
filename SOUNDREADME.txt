26/08/15
- Created new DoSound script that allows for a generic sound event (any sound you assign within the inspector) to play on any Unity event, or when called by another object
- also added a variable to this DoSound script that will check if this is a "destroy object" sound, which essentially means that if this object is meant to play in the position of another object that is destroyed or otherwise doesn't have its own object (the sniper hit position) then this sound will be instantiated in its place and played. if this bool is not checked then it will do nothing 

26/08/13
- Implemented many weapon sounds into the project, as well as UI sounds
- Implemented weapon switch and weapon fire events into the WeaponSystem script