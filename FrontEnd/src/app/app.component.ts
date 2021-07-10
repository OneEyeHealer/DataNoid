import { CdkDragDrop, moveItemInArray } from '@angular/cdk/drag-drop';
import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';

export interface Exercise {
  name: string;
}
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
  title = 'DataNoid | All in one platform';
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
