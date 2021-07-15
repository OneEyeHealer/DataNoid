import { CdkDragDrop, moveItemInArray } from '@angular/cdk/drag-drop';
import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { FormComponent } from './form/form.component';
import { ApiData } from './_interface/ApiData.ts';
import { Exercise } from './_interface/Exercise';

const DATA: ApiData[] = [
  {
    Id: 1,
    FirstName: 'Hydrogen',
    LastName: 'Linkin',
    Email: 'example@gamil.com',
    Phone: 9876543211,
    Department: 'Other',
    JobRole: 'other',
    Address: 'NA',
  },
  {
    Id: 2,
    FirstName: 'Helium',
    LastName: 'Linkin',
    Email: 'example@gamil.com',
    Phone: 9876543211,
    Department: 'Other',
    JobRole: 'other',
    Address: 'NA',
  },
  {
    Id: 3,
    FirstName: 'Lithium',
    LastName: 'Linkin',
    Email: 'example@gamil.com',
    Phone: 9876543211,
    Department: 'Other',
    JobRole: 'other',
    Address: 'NA',
  },
  {
    Id: 4,
    FirstName: 'Beryllium',
    LastName: 'Linkin',
    Email: 'example@gamil.com',
    Phone: 9876543211,
    Department: 'Other',
    JobRole: 'other',
    Address: 'NA',
  },
  {
    Id: 5,
    FirstName: 'Boron',
    LastName: 'Linkin',
    Email: 'example@gamil.com',
    Phone: 9876543211,
    Department: 'Other',
    JobRole: 'other',
    Address: 'NA',
  },
  {
    Id: 6,
    FirstName: 'Carbon',
    LastName: 'Linkin',
    Email: 'example@gamil.com',
    Phone: 9876543211,
    Department: 'Other',
    JobRole: 'other',
    Address: 'NA',
  },
];

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  constructor(public dialog: MatDialog) {}
  OpenDialog = () => {
    const dialogRef = this.dialog.open(Dialog);
    dialogRef.afterClosed().subscribe((response) => {
      console.log(`Dialog Result: ${response}`);
    });
  };
  OpenForm = () => {
    const formRef = this.dialog.open(FormComponent);
    formRef.afterClosed().subscribe((response) => {
      console.log(response);
    });
  };
  title = 'DataNoid | All in one platform';
  displayedColumns: string[] = [
    '#',
    'Name',
    'Email',
    'Phone',
    'Department',
    'Job Roles',
    'Address',
  ];
  columnsToDisplay: string[] = this.displayedColumns.slice();
  data: ApiData[] = DATA;
}
@Component({
  selector: 'app-root',
  templateUrl: './dialog.html',
})
export class Dialog {
  exercises: Exercise[] = [
    { name: 'Exercise 1' },
    { name: 'Exercise 2' },
    { name: 'Exercise 3' },
    { name: 'Exercise 4' },
    { name: 'Exercise 5' },
    { name: 'Exercise 6' },
  ];

  drop = (event: any) => {
    console.log(event);
    moveItemInArray(this.exercises, event.previousIndex, event.currentIndex);
    console.log(
      this.moveItem(this.exercises, event.previousIndex, event.currentIndex)
    );
  };
  moveItem = (arr: any[], old_index: number, new_index: number) => {
    if (new_index >= arr.length) {
      var k = new_index - arr.length + 1;
      while (k--) {
        arr.push(undefined);
      }
    }
    arr.splice(new_index, 0, arr.splice(old_index, 1)[0]);
    return arr;
  };
}
