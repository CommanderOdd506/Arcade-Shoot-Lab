Arcade Shooter

Video: https://www.youtube.com/watch?v=jnfMpcFrHpQ

Controls
A / D or Arrow Keys: move
Space: shoot

Object Pool

The bullets use an object pool. At the start, the game makes 30 bullets and turns them off. When the player shoots, the game turns on the next bullet instead of making a new one. When a bullet hits a target or runs out of time, it turns off so it can be used again.

Builder

The targets use the builder pattern. The builder sets a target's sprite, size, speed, and points one step at a time, then builds it. The director has three premade target types:

Small Fast: small, fast, 50 points
Medium: medium size and speed, 20 points
Big Slow: big, slow, 10 points

Observer

The score uses the observer pattern. When a target gets hit, it sends out an event with its point value. The score counter listens for that event and adds the points. The director also listens so it knows when to spawn a new target.