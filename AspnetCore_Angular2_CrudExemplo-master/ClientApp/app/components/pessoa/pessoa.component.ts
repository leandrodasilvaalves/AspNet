import { Component, OnInit } from '@angular/core';
import { PessoaService } from '../../services/pessoa.service';
import { IPessoa } from '../../models/pessoa.interface';
import {
    FormGroup,
    FormControl,
    FormBuilder,
    Validators,
    ReactiveFormsModule
} from "@angular/forms";


@Component({
    selector: 'app-pessoa',
    templateUrl: './pessoa.component.html',
    styleUrls: ['./pessoa.component.css']
})
export class PessoaComponent implements OnInit {

    //Pessoa
    pessoas: IPessoa[] = [];
    pessoa: IPessoa = <IPessoa>{};

    //formulario
    formLabel: string;
    isEditMode: boolean =false;
    form: FormGroup;


    constructor(private pessoaService: PessoaService, private fb: FormBuilder) {
        this.form = fb.group({
            "nome": ["", Validators.required],
            "email": ["", Validators.required],
            "telefone": ["", Validators.required]
        });
        this.formLabel = "Adicionar Pessoa";
    }

    
    ngOnInit() {
        this.getPessoas();
    }

    private getPessoas() {
        this.pessoaService.getPessoas().subscribe(
            data => this.pessoas = data,
            error => alert(error),
            () => console.log(this.pessoas)
        );
    }



    onSubmit() {
        this.pessoa.nome = this.form.controls["nome"].value;
        this.pessoa.email = this.form.controls["email"].value;
        this.pessoa.telefone = this.form.controls["telefone"].value;

        if (this.isEditMode) {
            this.pessoaService.editPessoa(this.pessoa)
                .subscribe(response => {
                    this.getPessoas();
                    this.form.reset();
                });

        } else {
            this.pessoaService.addPessoa(this.pessoa).subscribe(response => {
                this.getPessoas();
                this.form.reset();
            });
        }
    }
    edit(pessoa: IPessoa) {
        this.formLabel = "Editar Pessoa";
        this.isEditMode = true;
        this.pessoa = pessoa;
        this.form.get("nome").setValue(pessoa.nome);
        this.form.get("email").setValue(pessoa.email);
        this.form.get("telefone").setValue(pessoa.telefone);
    };

    delete(pessoa: IPessoa) {
        if (confirm("Deseja excluir esta pessoa ?")) {
            this.pessoaService.deletePessoa(pessoa.id)
                .subscribe(response => {
                    this.getPessoas();
                    this.form.reset();
                });
        }
    };

    cancel() {
        this.formLabel = "Adicionar Pessoa";
        this.isEditMode = false;
        this.pessoa = <IPessoa>{};
        this.form.get("nome").setValue('');
        this.form.get("email").setValue('');
        this.form.get("telefone").setValue('');
    };
    
   

}
