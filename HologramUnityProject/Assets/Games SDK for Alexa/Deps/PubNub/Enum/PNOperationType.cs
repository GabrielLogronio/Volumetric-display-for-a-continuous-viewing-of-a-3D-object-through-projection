#pragma warning disable 0219
#pragma warning disable 0168
#pragma warning disable 0618
#pragma warning disable 0649
#pragma warning disable 0067
#pragma warning disable 0414

#pragma warning disable 0067
#pragma warning disable 0414

﻿using System;

namespace PubNubAPI
{
    public enum PNOperationType 
    {
        PNSubscribeOperation,
        PNPresenceOperation,
        PNUnsubscribeOperation,
        PNPresenceUnsubscribeOperation,
        PNPublishOperation,
        PNFireOperation,
        PNLeaveOperation,
        PNHistoryOperation,
        PNDeleteMessagesOperation,
        PNFetchMessagesOperation,
        PNMessageCountsOperation,
        PNWhereNowOperation,
        PNHeartbeatOperation,
        PNPresenceHeartbeatOperation,
        PNSetStateOperation,
        PNGetStateOperation,
        PNAddChannelsToGroupOperation,
        PNRemoveChannelsFromGroupOperation,
        PNChannelGroupsOperation,
        PNRemoveGroupOperation,
        PNChannelsForGroupOperation,
        PNPushNotificationEnabledChannelsOperation,
        PNAddPushNotificationsOnChannelsOperation,
        PNRemovePushNotificationsFromChannelsOperation,
        PNRemoveAllPushNotificationsOperation,
        PNTimeOperation,
        PNHereNowOperation,
        PNSignalOperation,
        PNGetMessageActionsOperation,
        PNAddMessageActionsOperation,
        PNRemoveMessageActionsOperation,
    	PNHistoryWithActionsOperation,		
	    PNCreateUserOperation,		
	    PNGetUsersOperation,		
	    PNGetUserOperation,		
        PNUpdateUserOperation,		
	    PNDeleteUserOperation,
	    PNGetSpaceOperation,
        PNGetSpacesOperation,		
	    PNCreateSpaceOperation,		
	    PNDeleteSpaceOperation,		
	    PNUpdateSpaceOperation,		
	    PNGetMembershipsOperation,		
	    PNGetMembersOperation,		
	    PNManageMembershipsOperation,		
	    PNManageMembersOperation,
    }

}

