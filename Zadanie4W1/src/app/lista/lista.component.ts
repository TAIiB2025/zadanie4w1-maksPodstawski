import { Component, inject } from '@angular/core';
import { ListaService } from '../lista.service';
import { Observable } from 'rxjs';
import { Ksiazka } from '../../models/ksiazka';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-lista',
  imports: [CommonModule, RouterLink, FormsModule],
  templateUrl: './lista.component.html',
  styleUrl: './lista.component.css'
})
export class ListaComponent {
  private readonly listaService = inject(ListaService);
  public dane$: Observable<Ksiazka[]>;
  public fraza: string = '';

  constructor() {
    this.dane$ = this.listaService.get();
  }

  onSearch(): void {
    if (this.fraza.trim()) {
      this.dane$ = this.listaService.searchByTitle(this.fraza);
    } else {
      this.dane$ = this.listaService.get();
    }
  }
}
