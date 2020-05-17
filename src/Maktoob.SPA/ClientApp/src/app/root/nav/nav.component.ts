import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { IAuthService } from 'src/app/core/services/auth.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss']
})
export class NavComponent implements OnInit {

  @Output()
  SignOut = new EventEmitter<void>(true);

  constructor() { }

  ngOnInit(): void {
  }
  _SignOut(): void {
    this.SignOut.emit();
  }
}
