# Snuzzle_Game
A small video game about solving puzzles as a snake!

Welcome to the Snuzzle repo! Continue reading to get instructions for downloading and playing the game, as well as making your own levels to share with friends!

TLDR:
- Windows might think the .exe file is a virus. If you trust me, you can open it anyway.
- Skip to (3) for Controls. If you have played other games before, they should be familiar.
- The goal is to solve the levels. You learn as you go. More at (2).
- If you want to make your own level or play a friend's level, check out (4) and (5).
- Close the game with "Esc" or "Alt + F4"

**0. How to close the game:**<br><br>Press "**Esc**" or **"Alt + F4"** at any time to close the game.
This only fails if a textbox is currently selected (Esc no longer works) or the game freezes (in which case Alt + F4 causes a prompt asking “Do you want to close the program because it is not responding?”. You can click "yes")
In case everything else fails, you should always be able to "**Alt + Tab**" to a different Window, such as Task Manager.

**1. How to open the game:**<br><br>In this repo there is a file titled "Snuzzle_Game.exe". If you are on windows, you can download it and then open it to run it. 
There are a few reasons this may malfunction:
- **Windows might think this file might be a virus**. As a general rule, **DO NOT OPEN “.EXE” FILES YOU DO NOT TRUST**. But if you trust me, AND you trust that this file has not been tampered with by someone else, you can click "Options" and "Open Anyway". If not, I totally understand and hope to show you the game in person someday. (If you have coding experience, you can also download the sourcecode and take a look to convince yourself there is nothing nefarious before running it.)
- You are not running Windows
- **Or something else happens** that I haven't discovered yet. Please reach out if this happens!

Things to note: When you open the game, a colorful screen will appear alongside a black console window (this one may be covered by the colorful screen). The console window is useful for the level editor and can be ignored for now. Try using “Alt + Tab” to switch between different windows, to verify that both are present. 

**2. How to win the game:**<br><br>The goal of the game is to **complete all the levels**.
You complete a level by **covering all of the white dotted "Victory Tiles"**, turning them into yellow full-bordered Victory Tiles.<br>If you are a personal friend of mine and you can't figure it out, gladly call me and I'll try to explain it better :P

**3. Controls:**
- Use "**Esc**" or "**Alt + F4**" to close the game

- Use your mouse to click on levels and other buttons

- Use **W, A, S, D** or **Up, Left, Down, Right (Arrowkey)** to move once inside a level

- Use "**Backspace**" to **UNDO** a move **(!!!!)** You may need to do this, as it is possible to get stuck!

- Use "**B**" to back out of a level (without beating it).

Whenever you beat a level, the next level becomes highlighted. It is recommended to beat the levels in order, as you learn valuable lessons along the way, however a level being dark does not prevent you from entering it. If you want to, skip ahead!

Advice: Play with sound on, as it can give you feedback as to whether the move you're trying to make is impossible or not.
- You can **Mute/Unmute** the audio with “**M**” 

**4. Level Editor:**<br><br>Click on "Custom Level", then enter a Width and a Height and press "Build" to enter the Level Editor. Here, you can experiment and make your own level, which you can then share with others. Here's how to use it:
- **Click** on the squares to cycle through different possible tiles
- Press "**V**" to switch to "Victory Tile" mode (the ones you have to cover to win)
- Try out your Level by **Moving** (See normal controls).
Once you’re satisfied with the result, press "**ENTER**" to output the LEVEL CODE to the **black console window**. This is most likely hidden by the game screen.
In order to access it, you must "Alt + Tab" to it (or "Windowskey" + Click on the console window). Once there, you can copy the code and then paste it anywhere to save it, or even share it with friends! To play a level you have the code for, you must:

**5. Import Level:**<br><br>**Click** “Custom Level”, then **enter a level code** (which you can generate yourself with the Level Editor or get from a friend who made a level with the Level Editor) and click “**Import**”
(The structure for a level code is as follows: 6 digits, then a series of letters (and numbers), then a series of “v”s and “.”s, and then possibly 3 more digits. If it does not follow this pattern or otherwise encodes for an unbuildable level, the textbox will tell you the level code is invalid. If this is the case, send me the level code and I’ll check what the issue is. )

**6. Game Mechanics**<br><br>I do not intend to provide a full write-up about all the distinct tiles and what they do (hopefully that becomes clear enough while playing the game), however if there is such a need I can add it later.
If you have any suggestions for interesting tiles or game mechanics, please let me know! (I'll keep a tally of past ideas and suggestions below):
- Self-Moving blocks
- Doors with buttons
- Making the snake body movable
- Portals
- Patrick's Parabox ripoff ideas (awesome game btw)
