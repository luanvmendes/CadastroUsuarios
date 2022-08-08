import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-user-dialog',
  templateUrl: './user-dialog.component.html',
  styleUrls: ['./user-dialog.component.scss']
})
export class UserDialogComponent {
  constructor(private dialog: MatDialogRef<UserDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: string) { }

  public confirm() {
    this.dialog.close(true);
  }

  public dismiss() {
    this.dialog.close(false);
  }
}
