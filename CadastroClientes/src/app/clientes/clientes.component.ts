import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { Cliente } from '../models/cliente';
import { ClienteService } from './cliente.service';

@Component({
  selector: 'app-clientes',
  templateUrl: './clientes.component.html',
  styleUrls: ['./clientes.component.css']
})
export class ClientesComponent implements OnInit {

  public clienteForm: FormGroup;

  titulo = 'Clientes';

  public clienteSelecionado: Cliente;
  public clienteEmEdicao: Cliente;
  public clientes : Cliente[];
  public endereco: object;

  modalRef: BsModalRef;
  
  constructor(private fb: FormBuilder, 
              private modalService: BsModalService, 
              private clienteService: ClienteService) {
    this.criarForm();
  }
  
  openModal(template: TemplateRef<any>): void {
    this.criarForm();
    this.modalRef = this.modalService.show(template);
  }

  closeModal(): void{
    this.modalRef.hide();
    this.clienteEmEdicao = null;
  }

  editarCliente(cliente: Cliente): void{
    this.clienteEmEdicao = cliente;
    this.clienteSelecionado = cliente;
    this.clienteForm.patchValue(cliente);
  }

  ngOnInit(): void {
    this.carregarClientes();
  }

  public carregarClientes(): void{
    this.clienteService.getAll().subscribe(
      (clientes: Cliente[]) => {
        this.clientes = clientes;
        console.log(this.clientes);
      },
      (erro: any) => {
        console.error(erro);
      }
    );
  }

  selecionarCliente(cliente: Cliente): void {
    this.clienteSelecionado = cliente;
    console.log(cliente);
    this.clienteForm.patchValue(cliente);
  }

  public voltar(): void {
    this.clienteSelecionado = null;
    if (this.clienteEmEdicao){
      this.clienteEmEdicao = null;
    }
  }
  public cancelar(): void{
    this.clienteEmEdicao = null;
    this.closeModal();
  }

  criarForm(): void {
    this.clienteForm = this.fb.group({
      clienteId: [0],
      nome : ['', Validators.required],
      dataNascimento : ['', Validators.required],
      sexo : ['', Validators.required],
      cep: [''],
      rua : [''],
      numero : [''],
      complemento: [''],
      bairro : [''],
      estado: [''],
      cidade: ['']
    });
  }

  salvarCliente(): void{
    var cliente = this.clienteForm.value;
    this.clienteService.put(cliente.clienteId, cliente).subscribe(
      (cliente: Cliente) => {
        console.log(cliente);
        this.carregarClientes();
        this.clienteEmEdicao = null;
      },
      (erro: any) => {
        console.log(erro);
      }
    );
  }

  salvarNovoCliente(): void{
    var cliente = this.clienteForm.value;
    console.log(cliente);
    this.clienteService.post(cliente).subscribe(
      (cliente: Cliente) => {
        console.log(cliente);
        this.carregarClientes();
        this.closeModal();
      },
      (erro: any) => {
        console.log(erro);
      }
    );
  }

  removerCliente(clienteId: number): void{
    this.clienteService.delete(clienteId).subscribe(
      (response: any) => {
        console.log(response);
        this.carregarClientes();
      },
      (erro: any) => {
        console.log(erro);
      }
    );
  }

  buscarEndereco(cep: string){
    this.clienteService.getEndereco(cep).subscribe(
      (response: any) => {
        this.clienteSelecionado.rua = response.logradouro;
        this.clienteSelecionado.bairro = response.bairro;
        this.clienteSelecionado.cidade = response.localidade;
        this.clienteSelecionado.estado = response.uf; 
      },
      (erro: any) => {
        console.log(erro);
      }
    )
  }
}
