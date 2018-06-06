import { MessageService } from 'primeng/components/common/messageservice';
import { Injectable } from '@angular/core';
import { Message } from 'primeng/components/common/message';

@Injectable()
export class MessageHandlingService 
{

    constructor(private msgService: MessageService) { }

    public handleErrorMessage(errorMsg: string, title: string = 'Error') : void
    {
        let msg: Message = { severity: 'error', summary: title, detail: errorMsg };
        this.publishMessage(msg);
    }

    public handleSuccessMessage(successMsg: string, title: string = 'Success') : void 
    {
        let msg: Message = { severity: 'success', summary: title, detail: successMsg };
        this.publishMessage(msg);
    }

    public handleNotificationMessage(notifyMsg: string, title: string = 'Notification') : void 
    {
        let msg: Message = { severity: 'info', summary: title, detail: notifyMsg };
        this.publishMessage(msg);
    }

    private publishMessage(msg: Message): void 
    {
        this.msgService.add(msg);
    }

}