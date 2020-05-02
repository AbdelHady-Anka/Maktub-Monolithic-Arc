import { Component, OnInit } from '@angular/core';
import { Validators, FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core'
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  hide: boolean = true;
  selected = "en";
  constructor(public translate: TranslateService) { }
  email = new FormControl('', [Validators.required, Validators.email])
  ngOnInit() {
  }

  getErrorMessage() {
    if (this.email.hasError('required')) {
      return 'You must enter a value';
    }
    return this.email.hasError('email') ? 'Not a valid email' : '';
  }

}
