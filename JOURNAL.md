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
