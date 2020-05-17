import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';

import { IStorageService } from '../core/services/storage.service';
import { LangState } from '../core/states/lang.state';
import { ILangFacade } from '../core/facades/lang.facade';

@Component({
  selector: 'app-root',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.scss']
})
export class AuthComponent implements OnInit {
  vm$: Observable<LangState> = this.langService.ViewModel$;

  constructor(public langService: ILangFacade) { }
  ngOnInit(): void { }
}
