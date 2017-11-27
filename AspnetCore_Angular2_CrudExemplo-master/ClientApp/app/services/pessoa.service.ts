import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map'
import { Observable } from 'rxjs/Observable';
import { IPessoa } from '../models/pessoa.interface';

@Injectable()
export class PessoaService {
    constructor(private http: Http) { }

    //get
    getPessoas() {
        return this.http.get("api/pessoas").map(data => <IPessoa[]>data.json());
    }

    //post
    addPessoa(pessoa: IPessoa) {
        return this.http.post("api/pessoas", pessoa);
    }

    //put - api/pessoas/1
    editPessoa(pessoa: IPessoa) {
        return this.http.put(`api/pessoas/${pessoa.id}`, pessoa);
    }

    //delete - api/pessoas/1
    deletePessoa(PessoaId: number) {
        return this.http.delete(`api/pessoas/${PessoaId}`);
    }
}