﻿function ShowMessage(title, text, theme) {

    window.createNotification({
        closeOnClick: true,
        displayCloseButton: false,
        positionClass: 'nfc-bottom-right',
        showDuration: 4000,
        theme: theme !== '' ? theme : 'success'
    })({
        title: title !== '' ? title : 'Notification',
        message: decodeURI(text)
    })

}

function CopyToClipboard(text) {
    navigator.clipboard.writeText(text);
}
