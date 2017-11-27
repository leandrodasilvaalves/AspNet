import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { sharedConfig } from './app.module.shared';
import { ReactiveFormsModule } from '@angular/forms';

import { PessoaService } from './services/pessoa.service';


@NgModule({
    bootstrap: sharedConfig.bootstrap,
    declarations: sharedConfig.declarations,
    imports: [
        BrowserModule,
        FormsModule,
        HttpModule,
        ReactiveFormsModule,
        ...sharedConfig.imports
    ],
    providers: [
        PessoaService,
        { provide: 'ORIGIN_URL', useValue: location.origin }
    ]
})
export class AppModule {
}
