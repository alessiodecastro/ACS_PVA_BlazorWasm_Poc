import './callComposite.js';


export function loadCallComposite(userId, token, callId, actorName, element) {
    return callComposite.loadCallComposite(
        {
            locator: { groupId: callId }, // The GUID identifier to join a group call
            displayName: actorName,
            userId: { communicationUserId: userId },
            token: token,
        },
        element
    );
}
