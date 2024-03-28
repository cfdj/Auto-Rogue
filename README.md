A Light inn management game built in Unity. Currently in development

Current features:
Character stats
Shop system
Items for upgrading stats which can be "tripled"
Auto-battle style "adventures" where players progress against encounters of enemies.

Currently development focus:
Weapon Draggables, given as a reward for quests and equipable to characters

Primary apporach is the scriptable object-displayer pattern, for example
Stat Items exist as scriptable objects, are held in the shop's Stock, and displayed by ItemDisplays, which can be dragged to buy/use on characters.
