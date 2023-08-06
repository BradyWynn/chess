# How to get your bot's elo (2 different tiers of Elo)
Why 2 Tiers ? It's because Tier 1 will at one point be beaten 100% of times, so to get an elo for the better engines, we need a stronger base.

Tier 1 Elo would be  against basic Negamax

While Tier 2 would be against an advanced Negamax with a bunch of upgrades (see the actual link of the Tier 2 bot for the details)

- Step 1. Replace EvilBot with NegamaxBot
  - For Tier 1 : Copy [this bot's code](https://github.com/Tumpa-Prizrak/MyBot-Chess-Challenge/blob/main/Chess-Challenge/guides/NegamaxBot.cs) and paste it to src/Evil Bot/EvilBot.cs
  - For Tier 2 : Copy [this bot's code](https://github.com/JacquesRW/Chess-Challenge/blob/main/Chess-Challenge/src/My%20Bot/MyBot.cs) and paste it to src/Evil Bot/EvilBot.cs
  - Replace class name from `NegamaxBot` to `EvilBot`

- Step 2. Test your bot
  - Start a game against EvilBot and wait until 1000 games ended
  - ![image](https://i.ibb.co/vzrNHZd/image.png)
  - ![image](https://i.ibb.co/sRRY5F3/image.png)

- Step 3. Calcucate your bot's elo
  - Go to [this site](https://3dkingdoms.com/chess/elo.htm) and insert your data and press first "Calculate Elo" button. Then get "Elo difference"
![image](https://i.ibb.co/SxMjTV3/image.png)
  - **For Tier 1: Unknown. Will be avalible soon.**
  - **For Tier 2: Add elo difference to 1950 (NegamaxBot's elo) and that will be your bot's elo!**

