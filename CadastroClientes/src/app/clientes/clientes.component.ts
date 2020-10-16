import { DatePipe } from '@angular/common';
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
  public cepModel: string;
  public dataModel: string;
  public msgErro: string;

  public clienteSelecionado: Cliente;
  public clienteEmEdicao: Cliente;
  public clientes : Cliente[];
  public endereco: object;

  modalRef: BsModalRef;
  
  constructor(private fb: FormBuilder, 
              private modalService: BsModalService, 
              private clienteService: ClienteService,
              private datePipe: DatePipe) {
    this.criarForm();
  }
  
  ngOnInit(): void {
    this.carregarClientes();
  }

  public criarForm(): void {
    this.clienteForm = this.fb.group({
      clienteId: [0],
      nome : ['', Validators.required],
      dataNascimento : ['', Validators.required],
      sexo : ['', Validators.required],
      cep: [''],
      logradouro : [''],
      numero : [''],
      complemento: [''],
      bairro : [''],
      uf: [''],
      localidade: ['']
    });
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
    this.dataModel = this.formatarData(cliente);
    this.cepModel = cliente.cep;
    this.clienteSelecionado = cliente;
    this.clienteForm.patchValue(cliente);
    this.clienteForm.disable();
  }

  public openModal(template: TemplateRef<any>): void {
    this.criarForm();
    this.modalRef = this.modalService.show(template);
  }

  public closeModal(): void{
    this.modalRef.hide();
    this.clienteEmEdicao = null;
  }

  public editarCliente(cliente: Cliente): void{
    this.clienteEmEdicao = cliente;
    this.clienteSelecionado = cliente;
    this.dataModel = this.formatarData(cliente);
    this.cepModel = cliente.cep;
    this.clienteForm.enable();
    this.clienteForm.patchValue(cliente);
  }

  public buscarEndereco(cep: string): void{
    this.clienteService.getEndereco(cep).subscribe(
      (response: any) => {
        this.clienteForm.patchValue(response);
      },
      (erro: any) => {
        console.log(erro);
      }
    )
  }

  public voltar(): void {
    this.clienteSelecionado = null;
    this.clienteEmEdicao = null;
    this.atualizarNgModel(this.clienteSelecionado);
    this.criarForm();
    this.clienteForm.disable();
  }

  public cancelar(): void{
    this.clienteEmEdicao = null;
    this.clienteForm.disable();
    this.closeModal();
  }

  salvarCliente(): void{
    var cliente = this.clienteForm.value;
    this.clienteService.put(cliente.clienteId, cliente).subscribe(
      (cliente: Cliente) => {
        this.carregarClientes();
        this.clienteEmEdicao = null;
      },
      (erro: any) => {
        console.log(erro);
      }
      );
      this.clienteForm.disable();
  }

  salvarNovoCliente(): void{
    var cliente = this.clienteForm.value;
    this.clienteService.post(cliente).subscribe(
      (cliente: Cliente) => {
        this.carregarClientes();
        this.closeModal();
        this.cepModel = null;
      },
      (erro: any) => {
        console.log(erro);
      }
    );
  }

  removerCliente(clienteId: number): void{
    this.clienteService.delete(clienteId).subscribe(
      (response: any) => {
        this.carregarClientes();
      },
      (erro: any) => {
        console.log(erro);
      }
    );
    this.voltar();
  }

  private formatarData(cliente: Cliente): string {
    return this.datePipe.transform(cliente.dataNascimento, "yyyy-MM-dd");
  }

  atualizarNgModel(cliente: Cliente) {
    this.cepModel = null;
    this.dataModel = null;
    this.msgErro = null;
  }

}
