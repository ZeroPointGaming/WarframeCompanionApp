# WarframeCompanionApp
A Warframe companion app under development, integrates with multiple data apis on the web.

Our mission is to take all of the warframe websites (Warframe.Market, WarframeStats.us etc and put them all into on mega app which will contain all the information a player would need. Drop locations for items, drop chances, market prices, build guides, and more.

The long term end game goal is a total inventory management system with future ambitions to integrate with DE's player data so the app can tell the player what they are missing and where they need to go to get what they need.

The short term roadmap is to just get the program into an alpha release, build a website for it with its own restful api interfaces. Eventually users will be able to manually input inventory data to their programs.

Our app is built on the .NET 5.0 Framework using MetroFramework for UI. 

Usage: Our app starts off with a list of all the warframes, currently the warframe tab is the only one that has developed functionality, to use it simply click on the warframe you want to see information about, and you can right click to find options to download available warframe.market orders for the prime sets and parts.

Screenshot of current running version 
![Alpha Screenshot](https://i.imgur.com/QAeKw1N.png)

## APIs we use
```c#
//Official Warframe API Data
namespace WarframeTracker.WarframeAPI.Items {}

//Warframe.Market
namespace WarframeTracker.WarframeMarket.ItemInfo {}
namespace WarframeTracker.WarframeMarket.ItemOrders {}
namespace WarframeTracker.WarframeMarket.GetAllItems {}
namespace WarframeTracker.WarframeMarket.RivenGetAuctions {}

//WarframeStats.us
namespace WarframeTracker.WarframeStats.WorldSpace {}

//OGGTechnologies
namespace WarframeTracker.OGTech.ValutedItemData {}
```
