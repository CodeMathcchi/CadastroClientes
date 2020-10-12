import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { Cliente } from '../models/cliente';

@Component({
  selector: 'app-clientes',
  templateUrl: './clientes.component.html',
  styleUrls: ['./clientes.component.css']
})
export class ClientesComponent implements OnInit {

  public clienteForm: FormGroup;

  titulo = "Clientes"; 

  public clienteSelecionado: Cliente;

  clientes = [
    {
      id : 1,
      nome : "Patrick",
      dataNascimento : "27/12/1999",
      sexo : "M",
      rua : 'Rua Pioneiro Herculano Ferreira',
      numero : '556',
      bairro : 'Conj. Hab. Sanenge III'
    },
    {
      id : 2,
      nome : "Matheus",
      dataNascimento : "14/12/1995",
      sexo : "M",
      rua : 'Avenida Londrina',
      numero : '1598',
      bairro : 'Conjunto Aeroporto'
    }
  ];

  modalRef: BsModalRef;
 
  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }

  constructor(private fb: FormBuilder, private modalService: BsModalService) {
    this.criarForm();
  }

  ngOnInit(): void {
  }

  selecionarCliente(cliente: Cliente) {
    this.clienteSelecionado = cliente;
    this.clienteForm.patchValue(cliente);
  }

  public voltar(){
    this.clienteSelecionado = null;
  }

  criarForm(){
    this.clienteForm = this.fb.group({
      nome : ['', Validators.required],
      dataNascimento : ['', Validators.required],
      sexo : ['', Validators.required],
      rua : [''],
      numero : [''],
      bairro : ['']
    });
  }

  clienteSubmit(){
    console.log(this.clienteForm.value)
  }
}
