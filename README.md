# Game of life. C# console application!
### Game of life. C# console application
Game of life without array representation, based on List, Dictionary and HashSet.
Console application for windows and .NET core.

### Application was briefly described in blog post:
[August 25, 2018](https://jlamch.blogspot.com/2018/08/game-of-life-c-console-application.html "permanent link")

Game of life is a zero-player game as we can read in  [Wikipedia](https://en.wikipedia.org/wiki/Conway%27s_Game_of_Life)  
It's quite amazing that basing on simple three rules there can be life simulation created. This gives imagination a jug what other rules crates life and what is a definition of life.  
Yeah it's a philosophical discussion but it's also a programmatic one.  
  
Most implementations that I found in west of internet are the ones based on two dimensional tables (in C# arrays). But it start me thinking, this is the simple solution but it's restricted with some space - and it's consuming all the space. So life and it's absence consumes space. Well space is cheap. But I don't like limitations,  
It was always strange for me that in computer world silence stored in computer also consumes a space. It's kinda illogical to consume space for life absence or silence.  
  
That’s why I wanted to implement the second available way to implement the problem.  
Wikipedia says:  
_"Alternatively, the programmer may abandon the notion of representing the Life field with a 2-dimensional array, and use a different data structure, such as a vector of coordinate pairs representing live cells."_  
And of course I fell into a trap. The easiest collection - List put me in multiple searches of neighbors. This is my V1 implementation.  
So I also implemented next version with Dictionary V2 and ended with HashSet V3 implementation (finding a lot of bugs on the way). Finally I've created a solution containing all three implementation run from console application (windows and .net core).   
  
Well maybe I fill find some more possibilities in the future, because it is great fun to create alternative implementation. Also it's good way to learn new things in known language and learn new language.  
  
But back to the game. I decided to store only life cells. So those are the rules to apply:  
**For a space that is alive:**  
**Each cell with one or no neighbors dies, as if by solitude.**  
**Each cell with four or more neighbors dies, as if by overpopulation.**  
**Each cell with two or three neighbors survives.**  
**For a space that is 'empty' or just doesn't exist:**  
**Each cell with three neighbors becomes populated.**  
  
First the life cell.  
I didn't want to use Point, it's just coordinates so I created class with X,Y fields and that’s it.  
  
Having a cell now we need to implement cell related rules. This is CellOperations class.  
[V1 CellOperations](https://github.com/jlamch/GameOfLife/blob/master/src/JL.GameOfLife.Core/V1/CellOperations.cs) [V2 CellOperations](https://github.com/jlamch/GameOfLife/blob/master/src/JL.GameOfLife.Core/V2/CellOperations.cs) [V3 CellOperations](https://github.com/jlamch/GameOfLife/blob/master/src/JL.GameOfLife.Core/V1/CellOperations.cs)  
- check if cell can survive:  KeepAlive  
- find neighbors:  FindNeighbors  
- reproduce. First calculate all potential coordinates for new life and then create new life:  PotentialReproducers, ReproduceAll  
The last part is probably very not efficient. It can’t be helped right now ??  
  
Now glue it together in GameSimulation class, and to be more specific in SimulateGeneration method.  
[V1 GameSimulation](https://github.com/jlamch/GameOfLife/blob/master/src/JL.GameOfLife.Core/V1/GameSimulation.cs) [V2 GameSimulation](https://github.com/jlamch/GameOfLife/blob/master/src/JL.GameOfLife.Core/V2/GameSimulation.cs) [V3 GameSimulation](https://github.com/jlamch/GameOfLife/blob/master/src/JL.GameOfLife.Core/V3/GameSimulation.cs)  
  
This should be enough to generate life. Almost whole functionality is implemented.  
Now we need just starting input.  
And again in Wikipedia there is a lot of information about patterns. I implemented few. There are still patterns and oscillators and patterns that can produce other life. My favorite is Acorn. that produce a lot of still life or oscillators after more then 5000 generations. And it's just nice to watch.  

[![](https://3.bp.blogspot.com/-6DXzMKpwJ-s/W4HOCC3mVNI/AAAAAAAAOBc/F_rVVjDxQVI43jI569Q34xr67ogHJJpSQCLcBGAs/s320/146px-Game_of_life_acorn.svg.png)](https://3.bp.blogspot.com/-6DXzMKpwJ-s/W4HOCC3mVNI/AAAAAAAAOBc/F_rVVjDxQVI43jI569Q34xr67ogHJJpSQCLcBGAs/s1600/146px-Game_of_life_acorn.svg.png)

  
this is one of many generations  

[![](https://1.bp.blogspot.com/-VzBN3d9geWI/W4HOkZLiDhI/AAAAAAAAOBk/l6O_msKuGVIKV0rRynGhYTbBAsxvkIWJQCLcBGAs/s640/Screen%2BShot%2B2018-08-25%2Bat%2B19.13.27.png)](https://1.bp.blogspot.com/-VzBN3d9geWI/W4HOkZLiDhI/AAAAAAAAOBk/l6O_msKuGVIKV0rRynGhYTbBAsxvkIWJQCLcBGAs/s1600/Screen%2BShot%2B2018-08-25%2Bat%2B19.13.27.png)

  
  
I was trying create implementation that will be very flexible and with separation of concerns in mind. But still I've included canvas size to ILifePattern with is very bad idea. Especially that I wanted just the logic implementation, that is separated from displaying, and I've mixed it. This is something to be improved.  
  
As for displaying I created console application to be easy to run everywhere (that’s why also .net core console application). Console application display only string. My optimization display whole row at a time. As I wanted to separate the problems I created project ConsoleDisplay.  
  
Ok this was just a quick walkthrough by the application and implementation.  
**The more important is what I found out in process.**  
  

1.  Display and generating, storing live are two different problems, but needs to be implemented with the second in mind. Choosing generation and storing algorithms must depend of display requirements.  
    In case of console application it's better to have two dimensional array.  
    I was creating my coordinate vector with only changing color of predefined controls (that’s why method SimulateGeneration returns newLife and deadOnes lists)
2.  Lists are no good for implementing Game of Life. Searching neighbors is very costly and above 3K live cells even on good computer game is significantly slowing down.
3.  Dictionary is the same kind of structure as HashSet but with key and value and in this case we need only key. It's good to know available structures in language of your choose.
4.  Game of life is great way to learn. And I will continue to implement more usages of this pattern.
5.  I'm obsessed with composition and sometimes I find myself in a corner.

  
  
Unfortunately to see the results you need to run the application.
