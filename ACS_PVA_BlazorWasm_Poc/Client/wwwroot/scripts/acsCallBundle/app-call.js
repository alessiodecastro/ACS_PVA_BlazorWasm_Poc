import './callComposite.js';


export function loadCallComposite(userId, token, element) {
    return callComposite.loadCallComposite(
        {
            locator: { groupId: "dbef0e8b-7e79-4c00-93d4-5f2c3ac1cc8b" }, // Provide any GUID to join a group
            displayName: "Alex",
            userId: { communicationUserId: userId }, // Object { communicationUserId: string }
            token: token,
        },
        element
    );
}

