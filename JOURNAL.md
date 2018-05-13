# Developer Journal
This is where I will be documenting my process.

## 27.Feb 2018 - 20:45
So about a year ago, I started looking at [Unity](https://unity3d.com/). I started and aborted a couple of projects before I finally felt I had a flow going. 
I was making a "roguelike" sidescrolling 2.5D shooter for android iOS! This is not it.

Last week, I bought a [Udemy course](https://www.udemy.com/the-ultimate-guide-to-game-development-with-unity) after getting an ad on facebook for it, and after going through the course,
 finally picked up the roguelike project after a couple of months not looking at it. After a couple of nights a few afternoons of coding, I was working on adding some post processing effects to make the game look better, when suddenly I broke something. 
 The rendering looked like crap and I couldn't figure out why, but hey, that's what version control is for! I quickly did a `git checkout .` thinking "crap, I'm gonna loose a couple of days worth of work, but at least I can continue working!

 So I reverted all my changes to the previously checked in version. That version's commit message? `initial commit`... 

 So here we are! I'm making a new game! And this will be my journal documenting my work!

 The gist of it is this: I'm going to make a Sci-fi 4X space shooter, built around a 2.5D space shooter, combined with looting and crafting.
 My current "hot" gameplay mechanics, are:
 - Resource gathering like it was done in [Starwars Galaxies](https://en.wikipedia.org/wiki/Star_Wars_Galaxies)
 - Player Craftable items combined with an auction house, also like in Starwars Galaxies.
 - Upgradable and modifyable ships with slots for weapons, armoer, etc.

 In short, I want people to go out and hunt for high quality resources, enabling them to craft items for themselves and to sell on an open auction house.

 At the time of writing, I have a half playable 2.5D view that lets you mine a few asteroid. It's a long way to go. I'll keep track of things on [Trello](https://trello.com/b/aSKnTj8r/roguespace).


 ## 27.Feb 2018 - 21:39
 Did some minor improvements tonight. 
 Finally fixed a bug that had been bothering me by throwing out my self made raycasting click handling, and instead use the event system interfaces like I should have from the beginning. [This video](https://www.youtube.com/watch?v=EVZiv7DLU6E) explains it.
 I also added a new scene - the "Home screen", and made it so you could launch the game scene from this. 

 Next time, I think I will have a look at either adding a simple inventory system or taking a crack at making my first enemies! I'm really wondering how I can make an AI that can navigate around asteroids and other obstacles.


 ## 28.Feb 2018 - 20:40
 Just spent about 1 hour googling for good solutions for pathfinding in a 2.5D game. Not sure how I will solve this...

 ## 8.Mar 2018 - 20:27
 I decided I would just stick a pin in making an actual AI for my first enemies and just make a very simple "always follow, always shoot" behaviour to just get something up and running. 
 It actually turned out ok - I'm now able to place some really rudementary enemies on the map, which enables me to start looking at player damage, loot, and other stuff.

 I found [CG Trader](https://www.cgtrader.com/) to be a really nice source for som free 3D models for my enemies. 

 ## 10.Mar 2018 - 14:10
 I've spent the last couple of hours making my enemies better in a couple of ways:
 1. I created a texture for them. I had to teach myself how to do [UV-mapping in Blender](https://www.youtube.com/watch?v=f2-FfB9kRmE) for this - that was fun!
 2. I made the enemies follow and shoot, only if the player is in range. I did this by making a "view range"-widget to try to generalize this behaviour.
 3. Added an engine particle effect

 I also started looking at how to end a level by making a wormhole that makes you go back to the main menu. Next step will be to have the level state update the gamestate so that any loot you get in a level is only transferred to inventory if you exit the level alive. Oh, and I need to implement player damage :)


 ## 10.Mar 2018 - 23:50
 OK! A pretty productive evening - I got guns up for both enemies and player. Made the wormhole exit and made the level end if player receive lethal damage.
 I made the player gun by adding a "Gun" gameobject and putting all the scripts for the gun as components for that game object. I really like how this will enable me to switch off and switch between guns really easliy. 
 I`m finding this way of modularizing the player and/or other prefabs to be really useful - ie. rather than having big switches of code in a single "player" class, have a master class for the player that switches on/off other game objects that each have their own code.

 ## 11.Mar 2018 - 22:56
 Finally! I managed to fix the minimap that has been bugged for quite a while! I have been using a render texture + raw image to make a UI-element with the minimap, but for some reason it didn|t work on my phone.
 I first fixed it by rendering on a 3D object (quad) anchored to my main cam, but then figured out that you could do this even easier by just setting the viewport rect for the camera. Then, about 2 minutes later, I think I found out [why it was failing originally](https://answers.unity.com/questions/1234144/rawimage-with-rendertexture-texture-not-working-on.html). I
 I might go back to my original approach later, now that I know how to fix it, but for now, I'm sticking with a simple camera with a custom viewport.

 I now have:
 - Movement controls
 - Weapon controls
 - Mining of asteroids
 - Enemies with a VERY simple AI
 - Player and enemy deaths
 - A Main Menu

Top priorities for the next features are:
- An inventory system
- Loot drop from enemies
- Toolbar for weapon switching in game

## 18.Mar 2018 - 22:25
I added a bunch of stuff today! I made an inventory system, and made it so you only keep loot if you survive the level. I also did a bunch of work on resources:
- Added several types of resources (not just "ore")
- Rewrote mining to be just "damage-to-asteroid"-based, which simplifies things a whole lot.

Enemies now also drop loot, drawn from a level specific loot table.
I also changed the looks of the joysticks - they look a lot better now.

Finally, I added an icon to the game, so it won't just show a unity logo any more.

Next steps:
- Ship upgrades
- Take a look at the map playability and at the very least make the map have an objective. Some possible options:
-- Kill all enemies
-- Kill a specific enemy
-- Loot a specific item
-- Reach a certain destination

Most of the objectives above should have some sort of visual objective pointer - looking forward to implementing that.

## 15.Apr 2018 - 22:50
I keep forgetting to write my journal! Oh well. 
Today I have done several things, all in the interest of working towards a simple crafting model.
I have:
- Changed the look of the minimap (ok that was just for fun)
- Added a "ship customization" scene, where you will be able to choose which weapons/items to equip your ship with.
- Rewritten some internal code related to guns, working towards making them more suited as equippable inventory items.
- Spent way too much time trying to get reflections to work, only to find out what I was looking for (planar reflections) isn't really included in Unity, you have to buy it from Asset Store :(

At the end of the night, I have:
- Logic that makes it possible to switch which gun you start the game with.
- A "ship customization" screen that does nothing.
- The start of an inventory vizualisation of guns.

I need to figure out how to best make guns BOTH inventory items and actual game objects. Maybe make a parent object for the item, with UI-stuff and gameplay objects as separate children, with the key values as values on the root parent?

## 22.Apr 2018 - 23:53
Not too much work done today, but I did get a bit further on the ship customization. I have now made it possible to equip weapons from the inventory. I want equipping of items to be done from a different screen, but that can be done later. 
I ended up making a UI element that can wrap an item instead of making the parent-child structure mentioned in the previous post. I think this is better. It means all items need a name, an icon, a description, etc, but it other than the icon, nothing UI-specific. I probably want the icon for display in game mode anyway, so I think it works out.
Next step: have the boss drop a weapon and make the inventory list that new weapon. To do so I have to:
- Fix it so UI-elements for weapons are dynamically created when loading the inventory screen.
- Make a loot box gameobject that can contain items.

This should be fun!

## 30.Apr 2018 - 21:11
Tonight I did the two things I decided to do last time: I made the boss drop loot, and I made the loot show up in the inventory. The loot box is just a cube with a debug texture on it for now.
Possible next steps (haven't decided yet):
- Make the crafting screen
- Make a beam weapon (really looking forward to that one!)

Just had an idea about resources for items... I think i will let the resources only have a "quality" rating, and then ingots or whatever you make from the raw materials will have "hardness","conductivity", etc.

## 1.May 2018 - 23:05
I ended up just playing around with looks of things today. Added some fonts, changed the look of the main menu. I also tested using cell/toon shading for the models and I kind of like it. It might also make it a bit easier to create models/textures for me. We will see...

## 3.May 2018 - 20:40
Last night and today I've been working on a crafting system. I don't really like the look of it and there's a bunch of bugs and only one recipe (Iron ingots), but the functionality is there. Quite happy about that!
I think the next stuff to be done is:
- Add a blueprint for the heavy blaster
-- This is going to force me to look at item properties (Hardness, Conductivity, etc) some more and probably rewrite some of the stuff I did with the "basic" crafting I just finished.
- Make the boss drop an exotic ingot and make that part of the blueprint?

I feel that once the crafting system is somewhat in place, I can maybe start looking at some more "actual" gameplay again. I want to make a couple of more maps, and make them a bit more interesting. My biggest concern right now is: Can I make this game actual fun to play?
I think there are a couple of quite important points I need to make this work:
- An overall sense of direction
-- A better feel of where to go on the map. The boundless map that I have now doesn't really cut it... Or should I make a boundless map, and make enemies/resources spawn at random (expect specific bosses)? Hmmm... I might look into that some more. A "map spawner" logic might be fun to make...
-- Clearer objectives, either imposed (quests, completion criteria, etc.) or user controller (I need 10 more exotic ore). The last part might be fun if a user could see what KIND of stuff appears in a map, but the map isn't the same all the time (like mentioned above. hmmm... I'm liking that idea better and better)
- Something to keep players playing. Crafting and quests might be enough to start.
- Better gameplay feel
-- The controls need improvement
-- UI is somewhat cluttered
-- What is a good zoom-level?

## 6.May 2018 - 22:15
Added the endless map and a spawning system for it tonight and I couldn't be happier with it! 
I ended up implementing a really simple grid based system: 
- Slice the map into grid
- Whenever player enters a grid cell where no spawn has been made eralier, spawn a random "spawn group" in that cell and any surrounding cells that are also missing spawns.

The "spawn groups" are jsut prefabs of areas with enemies, resources, etc. Which means I can customize them how much I want. 
I will probably make asteroid fields, etc be highly random, while boss encounters and the like will probably be more scripted/static.
This endelss map thing means a player can basically "grind" forever, in search of whatever she needs.

Very happy with this, as it also means I can delay doing a lot of level design work, and instead just design new spawn groups whenever I feel like it, or get an idea.

Oh, and I also hooked the game up to [Googles Firebase](https://firebase.google.com/) and started looking at persisting player state to the cloud.

I think my next task now should be to fix some tech debt so I can finish the Firebase linking.

I also had an idea to make the waypoint-arrows be placed inside the minimap instead of around the screen. Will make a Trello card for that.

## 13.May 2018 - 23:55
I'm not happy... I finally managed to make saving to/loading from firebase work, but the code looks like shit... 
What I ended up doing was:
- Create an "Item library" that contains all items that could ever be put in an inventory.
- Force all such items to have an item key, along with certain properties that can vary between instances of the items and an id for the specific items.
- Serialize to/from json by implementing ToJson/FromJson methods on each type of item.

It works, but I end up having really hard to read code, and with lots of boiler plate for each new item I create. I don`t like it, but it works, and maybe I will see a better solution later.

On the plus side, while skimming through [/r/gamedev/](https://www.reddit.com/r/gamedev/) I found this great site that has a bunch of cool music well suited for games, that you can (mostly) use for free! Check out [Fugue](https://icons8.com/music/)!

Oh, and I ended up swithing to cell shading using [Toony Colors Pro 2](https://assetstore.unity.com/packages/vfx/shaders/toony-colors-pro-2-8105) for my graphics, and a lighter background. I kinda like it for now. We will see :)
