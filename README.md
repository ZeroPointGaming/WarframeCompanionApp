# WarframeCompanionApp
A Warframe companion app under development, integrates with multiple data apis on the web.

Our mission is to take all of the warframe websites (Warframe.Market, WarframeStats.us etc and put them all into on mega app which will contain all the information a player would need. Drop locations for items, drop chances, market prices, build guides, and more.

The long term end game goal is a total inventory management system with future ambitions to integrate with DE's player data so the app can tell the player what they are missing and where they need to go to get what they need.

The short term roadmap is to just get the program into an alpha release, build a website for it with its own restful api interfaces. Eventually users will be able to manually input inventory data to their programs.

##Available APIs
```c#
//Official Warframe API Data
namespace WarframeTracker.SerializationWrappers.WarframeAPI.Items.Warframes
namespace WarframeTracker.SerializationWrappers.WarframeAPI.WorldState

//Warframe.Market
namespace WarframeTracker.SerializationWrappers.WarframeMarket.ItemInfo
namespace WarframeTracker.SerializationWrappers.WarframeMarket.ItemOrders
namespace WarframeTracker.SerializationWrappers.WarframeMarket.GetAllItems
namespace WarframeTracker.SerializationWrappers.WarframeMarket.RivenGetAuctions

//WarframeStats.us
namespace WarframeTracker.SerializationWrappers.WarframeStats.Arbitration
namespace WarframeTracker.SerializationWrappers.WarframeStats.WorldSpace
namespace WarframeTracker.SerializationWrappers.WarframeStats.Alerts
namespace WarframeTracker.SerializationWrappers.WarframeStats.CambionCycle
namespace WarframeTracker.SerializationWrappers.WarframeStats.Cetus
namespace WarframeTracker.SerializationWrappers.WarframeStats.OrbVallis
namespace WarframeTracker.SerializationWrappers.WarframeStats.Baro
namespace WarframeTracker.SerializationWrappers.WarframeStats.Invasions
namespace WarframeTracker.SerializationWrappers.WarframeStats.Fissures
namespace WarframeTracker.SerializationWrappers.WarframeStats.Syndicate
namespace WarframeTracker.SerializationWrappers.WarframeStats.News
namespace WarframeTracker.SerializationWrappers.WarframeStats.Nightwave
namespace WarframeTracker.SerializationWrappers.WarframeStats.Sortie
namespace WarframeTracker.SerializationWrappers.WarframeStats.Earth

//OGGTechnologies
namespace WarframeTracker.SerializationWrappers.OGTech.ValutedItemData
```
