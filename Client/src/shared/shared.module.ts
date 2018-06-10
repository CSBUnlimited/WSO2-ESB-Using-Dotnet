import { AuthService } from './services/authentication/auth.service';
import { ApiService } from './services/api.service';
import { CommonModule } from '@angular/common';
import { NgModule, ModuleWithProviders } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { HttpClientModule } from '@angular/common/http';
import { ErrorHandler } from '@angular/core';

import { PrimeNgModule } from './prime-ng.module';;
import { MessageService } from 'primeng/components/common/messageservice';
import { MessageHandlingService, FastFoodOnlineService } from './services';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        HttpModule,
        PrimeNgModule,
        HttpClientModule
    ],
    exports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        HttpModule,
        PrimeNgModule,
        HttpClientModule
    ],
    declarations: [
        
    ],
})
export class SharedModule {
    static forRoot(): ModuleWithProviders {
        return {
            ngModule: SharedModule,
            providers: [
                AuthService,
                MessageService,
                MessageHandlingService,
                ApiService,
                FastFoodOnlineService
            ]
        };
    }
}
