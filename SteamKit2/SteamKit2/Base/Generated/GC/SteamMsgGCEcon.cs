//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
#pragma warning disable 1591

// Generated from: econ_gcmessages.proto
// Note: requires additional types generated from: steammessages.proto
namespace SteamKit2.GC.Internal
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"CMsgApplyAutograph")]
  public partial class CMsgApplyAutograph : global::ProtoBuf.IExtensible
  {
    public CMsgApplyAutograph() {}
    

    private ulong _autograph_item_id = default(ulong);
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"autograph_item_id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(ulong))]
    public ulong autograph_item_id
    {
      get { return _autograph_item_id; }
      set { _autograph_item_id = value; }
    }

    private ulong _item_item_id = default(ulong);
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"item_item_id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(ulong))]
    public ulong item_item_id
    {
      get { return _item_item_id; }
      set { _item_item_id = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
    [global::ProtoBuf.ProtoContract(Name=@"EGCItemMsg")]
    public enum EGCItemMsg
    {
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCBase", Value=1000)]
      k_EMsgGCBase = 1000,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCSetItemPosition", Value=1001)]
      k_EMsgGCSetItemPosition = 1001,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCCraft", Value=1002)]
      k_EMsgGCCraft = 1002,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCCraftResponse", Value=1003)]
      k_EMsgGCCraftResponse = 1003,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCDelete", Value=1004)]
      k_EMsgGCDelete = 1004,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCVerifyCacheSubscription", Value=1005)]
      k_EMsgGCVerifyCacheSubscription = 1005,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCNameItem", Value=1006)]
      k_EMsgGCNameItem = 1006,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCUnlockCrate", Value=1007)]
      k_EMsgGCUnlockCrate = 1007,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCUnlockCrateResponse", Value=1008)]
      k_EMsgGCUnlockCrateResponse = 1008,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCPaintItem", Value=1009)]
      k_EMsgGCPaintItem = 1009,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCPaintItemResponse", Value=1010)]
      k_EMsgGCPaintItemResponse = 1010,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCGoldenWrenchBroadcast", Value=1011)]
      k_EMsgGCGoldenWrenchBroadcast = 1011,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCMOTDRequest", Value=1012)]
      k_EMsgGCMOTDRequest = 1012,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCMOTDRequestResponse", Value=1013)]
      k_EMsgGCMOTDRequestResponse = 1013,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCAddItemToSocket_DEPRECATED", Value=1014)]
      k_EMsgGCAddItemToSocket_DEPRECATED = 1014,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCAddItemToSocketResponse_DEPRECATED", Value=1015)]
      k_EMsgGCAddItemToSocketResponse_DEPRECATED = 1015,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCAddSocketToBaseItem_DEPRECATED", Value=1016)]
      k_EMsgGCAddSocketToBaseItem_DEPRECATED = 1016,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCAddSocketToItem_DEPRECATED", Value=1017)]
      k_EMsgGCAddSocketToItem_DEPRECATED = 1017,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCAddSocketToItemResponse_DEPRECATED", Value=1018)]
      k_EMsgGCAddSocketToItemResponse_DEPRECATED = 1018,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCNameBaseItem", Value=1019)]
      k_EMsgGCNameBaseItem = 1019,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCNameBaseItemResponse", Value=1020)]
      k_EMsgGCNameBaseItemResponse = 1020,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCRemoveSocketItem_DEPRECATED", Value=1021)]
      k_EMsgGCRemoveSocketItem_DEPRECATED = 1021,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCRemoveSocketItemResponse_DEPRECATED", Value=1022)]
      k_EMsgGCRemoveSocketItemResponse_DEPRECATED = 1022,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCCustomizeItemTexture", Value=1023)]
      k_EMsgGCCustomizeItemTexture = 1023,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCCustomizeItemTextureResponse", Value=1024)]
      k_EMsgGCCustomizeItemTextureResponse = 1024,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCUseItemRequest", Value=1025)]
      k_EMsgGCUseItemRequest = 1025,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCUseItemResponse", Value=1026)]
      k_EMsgGCUseItemResponse = 1026,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCGiftedItems", Value=1027)]
      k_EMsgGCGiftedItems = 1027,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCRemoveItemName", Value=1030)]
      k_EMsgGCRemoveItemName = 1030,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCRemoveItemPaint", Value=1031)]
      k_EMsgGCRemoveItemPaint = 1031,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCGiftWrapItem", Value=1032)]
      k_EMsgGCGiftWrapItem = 1032,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCGiftWrapItemResponse", Value=1033)]
      k_EMsgGCGiftWrapItemResponse = 1033,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCDeliverGift", Value=1034)]
      k_EMsgGCDeliverGift = 1034,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCDeliverGiftResponseGiver", Value=1035)]
      k_EMsgGCDeliverGiftResponseGiver = 1035,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCDeliverGiftResponseReceiver", Value=1036)]
      k_EMsgGCDeliverGiftResponseReceiver = 1036,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCUnwrapGiftRequest", Value=1037)]
      k_EMsgGCUnwrapGiftRequest = 1037,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCUnwrapGiftResponse", Value=1038)]
      k_EMsgGCUnwrapGiftResponse = 1038,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCSetItemStyle", Value=1039)]
      k_EMsgGCSetItemStyle = 1039,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCUsedClaimCodeItem", Value=1040)]
      k_EMsgGCUsedClaimCodeItem = 1040,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCSortItems", Value=1041)]
      k_EMsgGCSortItems = 1041,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGC_RevolvingLootList_DEPRECATED", Value=1042)]
      k_EMsgGC_RevolvingLootList_DEPRECATED = 1042,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCLookupAccount", Value=1043)]
      k_EMsgGCLookupAccount = 1043,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCLookupAccountResponse", Value=1044)]
      k_EMsgGCLookupAccountResponse = 1044,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCLookupAccountName", Value=1045)]
      k_EMsgGCLookupAccountName = 1045,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCLookupAccountNameResponse", Value=1046)]
      k_EMsgGCLookupAccountNameResponse = 1046,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCUpdateItemSchema", Value=1049)]
      k_EMsgGCUpdateItemSchema = 1049,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCRemoveCustomTexture", Value=1051)]
      k_EMsgGCRemoveCustomTexture = 1051,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCRemoveCustomTextureResponse", Value=1052)]
      k_EMsgGCRemoveCustomTextureResponse = 1052,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCRemoveMakersMark", Value=1053)]
      k_EMsgGCRemoveMakersMark = 1053,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCRemoveMakersMarkResponse", Value=1054)]
      k_EMsgGCRemoveMakersMarkResponse = 1054,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCRemoveUniqueCraftIndex", Value=1055)]
      k_EMsgGCRemoveUniqueCraftIndex = 1055,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCRemoveUniqueCraftIndexResponse", Value=1056)]
      k_EMsgGCRemoveUniqueCraftIndexResponse = 1056,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCSaxxyBroadcast", Value=1057)]
      k_EMsgGCSaxxyBroadcast = 1057,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCBackpackSortFinished", Value=1058)]
      k_EMsgGCBackpackSortFinished = 1058,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCAdjustItemEquippedState", Value=1059)]
      k_EMsgGCAdjustItemEquippedState = 1059,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCCollectItem", Value=1061)]
      k_EMsgGCCollectItem = 1061,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCItemAcknowledged", Value=1062)]
      k_EMsgGCItemAcknowledged = 1062,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCPresets_SelectPresetForClass", Value=1063)]
      k_EMsgGCPresets_SelectPresetForClass = 1063,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCPresets_SetItemPosition", Value=1064)]
      k_EMsgGCPresets_SetItemPosition = 1064,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGC_ReportAbuse", Value=1065)]
      k_EMsgGC_ReportAbuse = 1065,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGC_ReportAbuseResponse", Value=1066)]
      k_EMsgGC_ReportAbuseResponse = 1066,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCPresets_SelectPresetForClassReply", Value=1067)]
      k_EMsgGCPresets_SelectPresetForClassReply = 1067,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCNameItemNotification", Value=1068)]
      k_EMsgGCNameItemNotification = 1068,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCApplyConsumableEffects", Value=1069)]
      k_EMsgGCApplyConsumableEffects = 1069,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCConsumableExhausted", Value=1070)]
      k_EMsgGCConsumableExhausted = 1070,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCShowItemsPickedUp", Value=1071)]
      k_EMsgGCShowItemsPickedUp = 1071,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCClientDisplayNotification", Value=1072)]
      k_EMsgGCClientDisplayNotification = 1072,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCApplyStrangePart", Value=1073)]
      k_EMsgGCApplyStrangePart = 1073,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGC_IncrementKillCountAttribute", Value=1074)]
      k_EMsgGC_IncrementKillCountAttribute = 1074,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGC_IncrementKillCountResponse", Value=1075)]
      k_EMsgGC_IncrementKillCountResponse = 1075,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCApplyPennantUpgrade", Value=1076)]
      k_EMsgGCApplyPennantUpgrade = 1076,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCSetItemPositions", Value=1077)]
      k_EMsgGCSetItemPositions = 1077,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCApplyEggEssence", Value=1078)]
      k_EMsgGCApplyEggEssence = 1078,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCNameEggEssenceResponse", Value=1079)]
      k_EMsgGCNameEggEssenceResponse = 1079,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCUnlockItemStyle", Value=1080)]
      k_EMsgGCUnlockItemStyle = 1080,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCUnlockItemStyleResponse", Value=1081)]
      k_EMsgGCUnlockItemStyleResponse = 1081,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCTradingBase", Value=1500)]
      k_EMsgGCTradingBase = 1500,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCTrading_InitiateTradeRequest", Value=1501)]
      k_EMsgGCTrading_InitiateTradeRequest = 1501,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCTrading_InitiateTradeResponse", Value=1502)]
      k_EMsgGCTrading_InitiateTradeResponse = 1502,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCTrading_StartSession", Value=1503)]
      k_EMsgGCTrading_StartSession = 1503,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCTrading_SetItem", Value=1504)]
      k_EMsgGCTrading_SetItem = 1504,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCTrading_RemoveItem", Value=1505)]
      k_EMsgGCTrading_RemoveItem = 1505,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCTrading_UpdateTradeInfo", Value=1506)]
      k_EMsgGCTrading_UpdateTradeInfo = 1506,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCTrading_SetReadiness", Value=1507)]
      k_EMsgGCTrading_SetReadiness = 1507,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCTrading_ReadinessResponse", Value=1508)]
      k_EMsgGCTrading_ReadinessResponse = 1508,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCTrading_SessionClosed", Value=1509)]
      k_EMsgGCTrading_SessionClosed = 1509,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCTrading_CancelSession", Value=1510)]
      k_EMsgGCTrading_CancelSession = 1510,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCTrading_TradeChatMsg", Value=1511)]
      k_EMsgGCTrading_TradeChatMsg = 1511,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCTrading_ConfirmOffer", Value=1512)]
      k_EMsgGCTrading_ConfirmOffer = 1512,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCTrading_TradeTypingChatMsg", Value=1513)]
      k_EMsgGCTrading_TradeTypingChatMsg = 1513,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCServerBrowser_FavoriteServer", Value=1601)]
      k_EMsgGCServerBrowser_FavoriteServer = 1601,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCServerBrowser_BlacklistServer", Value=1602)]
      k_EMsgGCServerBrowser_BlacklistServer = 1602,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCServerRentalsBase", Value=1700)]
      k_EMsgGCServerRentalsBase = 1700,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCItemPreviewCheckStatus", Value=1701)]
      k_EMsgGCItemPreviewCheckStatus = 1701,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCItemPreviewStatusResponse", Value=1702)]
      k_EMsgGCItemPreviewStatusResponse = 1702,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCItemPreviewRequest", Value=1703)]
      k_EMsgGCItemPreviewRequest = 1703,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCItemPreviewRequestResponse", Value=1704)]
      k_EMsgGCItemPreviewRequestResponse = 1704,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCItemPreviewExpire", Value=1705)]
      k_EMsgGCItemPreviewExpire = 1705,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCItemPreviewExpireNotification", Value=1706)]
      k_EMsgGCItemPreviewExpireNotification = 1706,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCItemPreviewItemBoughtNotification", Value=1707)]
      k_EMsgGCItemPreviewItemBoughtNotification = 1707,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCDev_NewItemRequest", Value=2001)]
      k_EMsgGCDev_NewItemRequest = 2001,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCDev_NewItemRequestResponse", Value=2002)]
      k_EMsgGCDev_NewItemRequestResponse = 2002,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCStoreGetUserData", Value=2500)]
      k_EMsgGCStoreGetUserData = 2500,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCStoreGetUserDataResponse", Value=2501)]
      k_EMsgGCStoreGetUserDataResponse = 2501,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCStorePurchaseInit_DEPRECATED", Value=2502)]
      k_EMsgGCStorePurchaseInit_DEPRECATED = 2502,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCStorePurchaseInitResponse_DEPRECATED", Value=2503)]
      k_EMsgGCStorePurchaseInitResponse_DEPRECATED = 2503,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCStorePurchaseFinalize", Value=2504)]
      k_EMsgGCStorePurchaseFinalize = 2504,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCStorePurchaseFinalizeResponse", Value=2505)]
      k_EMsgGCStorePurchaseFinalizeResponse = 2505,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCStorePurchaseCancel", Value=2506)]
      k_EMsgGCStorePurchaseCancel = 2506,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCStorePurchaseCancelResponse", Value=2507)]
      k_EMsgGCStorePurchaseCancelResponse = 2507,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCStorePurchaseQueryTxn", Value=2508)]
      k_EMsgGCStorePurchaseQueryTxn = 2508,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCStorePurchaseQueryTxnResponse", Value=2509)]
      k_EMsgGCStorePurchaseQueryTxnResponse = 2509,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCStorePurchaseInit", Value=2510)]
      k_EMsgGCStorePurchaseInit = 2510,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCStorePurchaseInitResponse", Value=2511)]
      k_EMsgGCStorePurchaseInitResponse = 2511,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCBannedWordListRequest", Value=2512)]
      k_EMsgGCBannedWordListRequest = 2512,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCBannedWordListResponse", Value=2513)]
      k_EMsgGCBannedWordListResponse = 2513,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCToGCBannedWordListBroadcast", Value=2514)]
      k_EMsgGCToGCBannedWordListBroadcast = 2514,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCToGCBannedWordListUpdated", Value=2515)]
      k_EMsgGCToGCBannedWordListUpdated = 2515,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCToGCDirtySDOCache", Value=2516)]
      k_EMsgGCToGCDirtySDOCache = 2516,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCToGCDirtyMultipleSDOCache", Value=2517)]
      k_EMsgGCToGCDirtyMultipleSDOCache = 2517,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCToGCUpdateSQLKeyValue", Value=2518)]
      k_EMsgGCToGCUpdateSQLKeyValue = 2518,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCToGCIsTrustedServer", Value=2519)]
      k_EMsgGCToGCIsTrustedServer = 2519,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCToGCIsTrustedServerResponse", Value=2520)]
      k_EMsgGCToGCIsTrustedServerResponse = 2520,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCToGCBroadcastConsoleCommand", Value=2521)]
      k_EMsgGCToGCBroadcastConsoleCommand = 2521,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCServerVersionUpdated", Value=2522)]
      k_EMsgGCServerVersionUpdated = 2522,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCApplyAutograph", Value=2523)]
      k_EMsgGCApplyAutograph = 2523,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCToGCWebAPIAccountChanged", Value=2524)]
      k_EMsgGCToGCWebAPIAccountChanged = 2524,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCRequestAnnouncements", Value=2525)]
      k_EMsgGCRequestAnnouncements = 2525,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCRequestAnnouncementsResponse", Value=2526)]
      k_EMsgGCRequestAnnouncementsResponse = 2526,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCRequestPassportItemGrant", Value=2527)]
      k_EMsgGCRequestPassportItemGrant = 2527,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EMsgGCClientVersionUpdated", Value=2528)]
      k_EMsgGCClientVersionUpdated = 2528
    }
  
    [global::ProtoBuf.ProtoContract(Name=@"EGCMsgResponse")]
    public enum EGCMsgResponse
    {
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EGCMsgResponseOK", Value=0)]
      k_EGCMsgResponseOK = 0,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EGCMsgResponseDenied", Value=1)]
      k_EGCMsgResponseDenied = 1,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EGCMsgResponseServerError", Value=2)]
      k_EGCMsgResponseServerError = 2,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EGCMsgResponseTimeout", Value=3)]
      k_EGCMsgResponseTimeout = 3,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EGCMsgResponseInvalid", Value=4)]
      k_EGCMsgResponseInvalid = 4,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EGCMsgResponseNoMatch", Value=5)]
      k_EGCMsgResponseNoMatch = 5,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EGCMsgResponseUnknownError", Value=6)]
      k_EGCMsgResponseUnknownError = 6,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EGCMsgResponseNotLoggedOn", Value=7)]
      k_EGCMsgResponseNotLoggedOn = 7,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_EGCMsgFailedToCreate", Value=8)]
      k_EGCMsgFailedToCreate = 8
    }
  
    [global::ProtoBuf.ProtoContract(Name=@"EUnlockStyle")]
    public enum EUnlockStyle
    {
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_UnlockStyle_Succeeded", Value=0)]
      k_UnlockStyle_Succeeded = 0,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_UnlockStyle_Failed_PreReq", Value=1)]
      k_UnlockStyle_Failed_PreReq = 1,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_UnlockStyle_Failed_CantAfford", Value=2)]
      k_UnlockStyle_Failed_CantAfford = 2,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_UnlockStyle_Failed_CantCommit", Value=3)]
      k_UnlockStyle_Failed_CantCommit = 3,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_UnlockStyle_Failed_CantLockCache", Value=4)]
      k_UnlockStyle_Failed_CantLockCache = 4,
            
      [global::ProtoBuf.ProtoEnum(Name=@"k_UnlockStyle_Failed_CantAffordAttrib", Value=5)]
      k_UnlockStyle_Failed_CantAffordAttrib = 5
    }
  
}
#pragma warning restore 1591
