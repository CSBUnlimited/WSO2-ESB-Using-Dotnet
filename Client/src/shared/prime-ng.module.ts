import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import {
    InputTextModule, ButtonModule, DataTableModule, AccordionModule, SidebarModule, MenuModule, MenuItem, ConfirmDialogModule, ConfirmationService, 
    CalendarModule, DialogModule, DropdownModule, CheckboxModule, RadioButtonModule, TabViewModule, MessagesModule, GrowlModule, InputSwitchModule, 
    FileUploadModule, InputTextareaModule, PanelMenuModule, AutoCompleteModule, ProgressBarModule, MultiSelectModule, InputMaskModule, CardModule, 
    ScrollPanelModule, TreeModule, TreeTableModule, LightboxModule, KeyFilterModule
  } from 'primeng/primeng';

  import { TableModule } from 'primeng/table';

  @NgModule({
    imports: [ CommonModule ],
    exports: [
        InputTextModule, 
        ButtonModule, 
        DataTableModule, 
        AccordionModule, 
        SidebarModule, 
        MenuModule, 
        ConfirmDialogModule, 
        CalendarModule,     
        DialogModule, 
        DropdownModule, 
        CheckboxModule, 
        RadioButtonModule, 
        TabViewModule,  
        MessagesModule, 
        GrowlModule, 
        InputSwitchModule, 
        FileUploadModule, 
        InputTextareaModule,
        PanelMenuModule,
        AutoCompleteModule,
        ProgressBarModule,
        MultiSelectModule,
        InputMaskModule,
        CardModule,
        ScrollPanelModule,        
        TableModule,
        TreeModule,
        TreeTableModule,
        LightboxModule,
        KeyFilterModule
    ],
    providers: [ConfirmationService]
})
export class PrimeNgModule { }

