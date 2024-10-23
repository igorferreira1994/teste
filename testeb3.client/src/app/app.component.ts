import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { TituloModel } from './titulo.model';
import { TituloParametrosModel } from './tituloParametros.model';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  public titulo: TituloModel = new TituloModel(); 
  public listatituloParametros: TituloParametrosModel[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit() {   
    this.getTituloParametros();
  }  

  calcular() {     
    this.postGravarTitulo();
    
  }

  atualizar() {    
    this.getTituloParametros();
  }

  postGravarTitulo() {
    let novoCalculo = new TituloModel();
    novoCalculo.valor = this.titulo.valor;
    novoCalculo.prazo = this.titulo.prazo; 

    this.http.post<TituloModel>('https://localhost:7023/Titulo/Titulo', novoCalculo).subscribe(
      (result) => {       
        this.listatituloParametros[0].totalBruto = result.totalBruto;
        this.listatituloParametros[0].totalLiquido = result.totalLiquido;
      },
      (error) => {
        console.error(error);
      }
    );
  }   


  getTituloParametros() {
    this.http.get<TituloParametrosModel>('https://localhost:7023/Titulo/ParametrosTitulo').subscribe(
      (result) => {        
        this.listatituloParametros.push(result);        
      },
      (error) => {
        console.error(error);
      }
    );
  }

  title = 'Teste B3';
}
