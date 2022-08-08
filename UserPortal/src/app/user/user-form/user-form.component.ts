import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { UserDto } from 'src/app/models/userDto';
import { Escolaridade } from '../../models/userDto';
import { UserDialogComponent } from '../user-dialog/user-dialog.component';
import { UserService } from '../user.service';

@Component({
  selector: 'app-user-form',
  templateUrl: './user-form.component.html',
  styleUrls: ['./user-form.component.scss']
})
export class UserFormComponent implements OnInit {
  escolaridadeList: { id: number, desc: string }[] = [
    { id: Escolaridade.Infantil, desc: Escolaridade[Escolaridade.Infantil] },
    { id: Escolaridade.Fundamental, desc: Escolaridade[Escolaridade.Fundamental] },
    { id: Escolaridade.Médio, desc: Escolaridade[Escolaridade.Médio] },
    { id: Escolaridade.Superior, desc: Escolaridade[Escolaridade.Superior] },
  ];
  maxDate: Date = new Date();
  userForm: FormGroup = new FormGroup({});

  constructor(private dialog: MatDialogRef<UserDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: UserDto,
    private formBuilder: FormBuilder,
    private service: UserService) { }

  ngOnInit(): void {
    this.userForm = this.formBuilder.group({
      id: new FormControl(0),
      nome: new FormControl('', [Validators.required]),
      sobrenome: new FormControl('', [Validators.required]),
      email: new FormControl('', [Validators.required, Validators.pattern(/.+@.+\..+/)]),
      dataNascimento: new FormControl('', [Validators.required]),
      escolaridade: new FormControl('', [Validators.required]),
    });

    if (this.data !== null) this.userForm.setValue(this.data);
  }

  dismiss() {
    this.dialog.close(false);
  }

  onSubmit() {
    if (this.data === null)
      this.service.adicionar(this.userForm.getRawValue()).subscribe();
    else
      this.service.editar(this.userForm.getRawValue()).subscribe();

    this.dialog.close(true);
  }
}
