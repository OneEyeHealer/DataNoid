import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css'],
})
export class FormComponent implements OnInit {
  constructor(private fb: FormBuilder) {}
  FormTitle = 'Create App User';
  AppUserForm: FormGroup | any;
  ngOnInit(): void {
    this.AppUserForm = this.fb.group({
      Id: ['', { Validators: [Validators.required] }],
      FirstName: [
        '',
        {
          Validators: [
            Validators.required,
            Validators.minLength(2),
            Validators.maxLength(31),
          ],
        },
      ],
      LastName: [
        '',
        {
          Validators: [
            Validators.required,
            Validators.minLength(2),
            Validators.maxLength(31),
          ],
        },
      ],
    });
  }

  GetErrorMessage = (event: any) => {
    if (event.errors?.required) {
      return ' Feild is Required';
    }
    console.log(event);
    return;
  };
  OnAppUserFormSubmit = () => {
    console.log(this.AppUserForm.value);
  };
}
