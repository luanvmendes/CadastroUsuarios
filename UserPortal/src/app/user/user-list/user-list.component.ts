import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Escolaridade } from 'src/app/models/userDto';
import { UserDialogComponent } from '../user-dialog/user-dialog.component';
import { UserFormComponent } from '../user-form/user-form.component';
import { UserService } from '../user.service';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.scss']
})
export class UserListComponent implements OnInit {
  displayedColumns: string[] = ['Nome', 'Sobrenome', 'DataNascimento', 'Email', 'Escolaridade', 'actions'];
  dataSource: any[] = [];
  escolaridade: string = '';

  constructor(
    private service: UserService,
    private dialog: MatDialog
  ) { }

  ngOnInit(): void {
    this.loadData();
  }

  adicionar() {
    this.dialog.open(UserFormComponent, {
      width: '550px',
      data: null
    }).afterClosed().subscribe(resp => {
      if (resp)
        this.loadData()
    });
  }

  editar(id: number) {
    this.service.getById(id).subscribe(user => {
      this.dialog.open(UserFormComponent, {
        width: '550px',
        data: user
      }).afterClosed().subscribe(resp => {
        if (resp)
          this.loadData()
      });
    });
  }

  delete(element: any) {
    this.dialog.open(UserDialogComponent, {
      width: '550px',
      data: element.nome
    }).afterClosed().subscribe(resp => {
      if (resp) {
        this.service.remover(element.id).subscribe(() => {
          this.loadData()
        });
      }
    });
  }

  loadData() {
    this.service.listar().subscribe(resp => {
      this.dataSource = resp;
      this.dataSource.forEach(i => i.escolaridade = Escolaridade[i.escolaridade]);
    });
  }
}
